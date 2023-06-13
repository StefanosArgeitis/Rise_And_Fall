using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer : MonoBehaviour
{
    [SerializeField] private string loadLevel;

    void Start()
    {
        Invoke(nameof(backStart), 5);
    }

    void backStart(){
        SceneManager.LoadScene(loadLevel);
    }
}
