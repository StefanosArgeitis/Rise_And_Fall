using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image blackScreen;
    private bool fadeIn;
    private bool fadeOut;

    public float buffertime;
    public float fadeSpeed;
    public float fadetime;

    // Update is called once per frame

    private void Start() {

        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b);
        StartCoroutine("Transfer2");
    }

    void Update()
    {
        if(fadeOut){

            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (blackScreen.color.a == 0f){
                fadeOut = false;
               
                
            }
        }
    }

    public IEnumerator Transfer2(){

        yield return new WaitForSeconds(buffertime);

        fadeOut = true;

    }
}
