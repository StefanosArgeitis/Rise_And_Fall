using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlaxWheel : MonoBehaviour, IInteractable
{
    public Image blackScreen;
    private bool fadeIn;
    private bool fadeOut;

    public float buffertime;
    public float fadeSpeed;
    public float fadetime;
    private bool transfering;
    [SerializeField] private string loadLevel;

    //[SerializeField] 
    public string interactionPrompt => throw new System.NotImplementedException();


    void Update(){
        
        if(fadeIn){

            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 1f){
                fadeIn = false;
            }
        }
        
        if(fadeOut){

            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 0f){
                fadeOut = false;
               
                
            }
        }

    }

    void IInteractable.Interact()
    {
        p_Transfer();
    }

    public void p_Transfer(){

        if (!transfering){
            StartCoroutine("Transfer1");
        }
    }

    public IEnumerator Transfer1(){

        transfering = true;

        yield return new WaitForSeconds(buffertime);

        fadeIn = true;

        yield return new WaitForSeconds(fadetime);

        SceneManager.LoadScene(loadLevel);
        //fadeOut = true;
        transfering = false;

    }

    
    
}
