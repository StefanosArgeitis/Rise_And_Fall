using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [Header ("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float groundDrag;
    public float reduceTime;
    private bool isMoving = false;
    public float stepHeight;
    public float stepSmooth;



    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
    bool crouching = false;
    private RaycastHit roofHit;

    
    [Header("Keybinds")]
    public KeyCode crouchkey = KeyCode.C;


    [Header ("CheckForGround")]
    public float playerHeight;
    public float E_ground;
    public LayerMask is_ground;
    public bool Grounded;
    public bool edge;
    public float airMultiplier;


    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;
    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;

    private Coroutine reduceForce;
    [SerializeField] public LightBulbMini Mini_game;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);


        startYScale = transform.localScale.y;
    }

    void FixedUpdate()
    {
        if (Mini_game.pause_char){
            return;
        }
        MovePlayer();
        StepClimb();
        Vector3 speed = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    }


     private void Update()
    {
        /// Checks ground
        Grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, is_ground);
        ///Grounded = Physics.CheckSphere(GroundCheck.position, groundDistance, is_ground);

        P_Inputs();
        Speed_Control();

        if (edge){
            Grounded = true;
        }

        if (Grounded){

            edge = false;
            rb.drag = groundDrag;

        }else{

            rb.drag = 0;

            // Checks if player is not stuck on an edge
            if (rb.velocity.y < 0){
                edge = EdgeCheck();
            } else{
                edge = false;
            }

        }
        
    }

    private bool EdgeCheck(){

        RaycastHit hit;
        Vector3 ray_pos = transform.position + Vector3.down;

        Vector3 front = transform.forward * E_ground;
        Vector3 back = -transform.forward * E_ground;
        Vector3 right = transform.right * E_ground;
        Vector3 left = -transform.right * E_ground;

        Ray front_ray = new Ray(ray_pos, front);
        Ray back_ray = new Ray(ray_pos, back);
        Ray right_ray = new Ray(ray_pos, right);
        Ray left_ray = new Ray(ray_pos, left);

        if (Physics.Raycast (front_ray, out hit, E_ground, is_ground)){
            return true;
        }

        if (Physics.Raycast (back_ray, out hit, E_ground, is_ground)){
            return true;
        }

        if (Physics.Raycast (right_ray, out hit, E_ground, is_ground)){
            return true;
        }
        
        if (Physics.Raycast (left_ray, out hit, E_ground, is_ground)){
            return true;
        }

        return false;
    }

    private void OnDrawGizmos() {

        Vector3 ray_pos = transform.position + Vector3.down;

        Vector3 front = transform.forward * E_ground;
        Vector3 back = -transform.forward * E_ground;
        Vector3 right = transform.right * E_ground;
        Vector3 left = -transform.right * E_ground;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray_pos, front);
        Gizmos.DrawRay(ray_pos, back);
        Gizmos.DrawRay(ray_pos, right);
        Gizmos.DrawRay(ray_pos, left);
    }

    private void P_Inputs(){

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    
        /// Crouching
        if(Input.GetKeyDown(crouchkey)){

            /// Cannot crouch if there is not enough space 
            if(crouching && !Physics.Raycast(transform.position, Vector3.up, out roofHit, playerHeight * 0.75f + 0.3f)){

                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
                crouching = false;

            } else {

                transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
                rb.AddForce(Vector3.down * 7f, ForceMode.Impulse);
            
                crouching = true;
            }
            
            
        }
        

    }    


    private void MovePlayer(){

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        /// Is on ground
        if (Grounded){

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        } else if (!Grounded){

         /// Is not grounded
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Force);
        }

        // Check if the player is currently moving
        isMoving = moveDirection.magnitude > 0;

        // If the player has stopped moving, start reducing the force being applied
        if (!isMoving && reduceForce == null){

            reduceForce = StartCoroutine(ReduceForceOverTime());
        }

        // If the player has started moving again, stop reducing the force being applied
        else if (isMoving && reduceForce != null)
        {
            StopCoroutine(reduceForce);
            reduceForce = null;
            rb.velocity = Vector3.zero;
        }

    }

    void StepClimb(){

        if (verticalInput + horizontalInput != 0){

            RaycastHit hitLower;

            if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.6f, is_ground)){

             RaycastHit hitUpper;

             if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f, is_ground)){

                rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
                }
            }

            RaycastHit hitLower45;

            if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(1.5f,0,1), out hitLower45, 0.6f, is_ground)){

                RaycastHit hitUpper45;

                if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(1.5f,0,1), out hitUpper45, 0.2f, is_ground)){

                    rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
                }

            }

            RaycastHit hitLowerMinus45;

            if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f,0,1), out hitLowerMinus45, 0.6f, is_ground)){

                RaycastHit hitUpperMinus45;

                if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f,0,1), out hitUpperMinus45, 0.2f, is_ground)){

                    rb.position -= new Vector3(0f, -stepSmooth * Time.deltaTime, 0f);
                }

            }

        }
    }

    
    private IEnumerator ReduceForceOverTime(){

        float t = 0;
        while (t < reduceTime){

            t += Time.deltaTime;
            float factor = 1 - (t / reduceTime);
            rb.velocity = rb.velocity * factor;
            yield return null;
        }
    }

    private void Speed_Control(){

        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVelocity.magnitude > moveSpeed){

        Vector3 limitVelocity = flatVelocity.normalized * moveSpeed;
        rb.velocity = new Vector3(limitVelocity.x, rb.velocity.y, limitVelocity.z);

        }
       

    }

}
