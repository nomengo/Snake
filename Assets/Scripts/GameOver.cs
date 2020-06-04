using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Button rstButton;
    public GameObject gameOverWindow;

    void Start()
    {
        gameOverWindow.SetActive(false);
        rstButton = gameObject.GetComponentInChildren<Button>();
    }

    
    void Update()
    {
        if(FindObjectOfType<Snake>().isFailed == true)
        {
           gameOverWindow.SetActive(true);
        }
    }
}
