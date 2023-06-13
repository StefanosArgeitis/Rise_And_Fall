using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    
    public GameObject craftcam;
    void Start()
    {
        Invoke(nameof(OnCam), 4);
    }

    public void OnCam(){
        craftcam.SetActive(true);
    }
}
