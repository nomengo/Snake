using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    void Start()
    {
        scoreText = gameObject.GetComponentInChildren<Text>();
    }

    
    void Update()
    {
        scoreText.text = FindObjectOfType<Snake>().takenFoodCount.ToString();
    }
}
