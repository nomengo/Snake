using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button upBtn;
    public Button downBtn;
    public Button rightBtn;
    public Button leftBtn;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton(buttonName: upBtn.ToString()))
        {
            FindObjectOfType<Snake>().dir = Vector2.up; 
        }
        if (Input.GetButton(buttonName: downBtn.ToString()))
        {
            FindObjectOfType<Snake>().dir = -Vector2.up;
        }
        if (Input.GetButton(buttonName: rightBtn.ToString()))
        {
            FindObjectOfType<Snake>().dir = Vector2.right;
        }
        if (Input.GetButton(buttonName: leftBtn.ToString()))
        {
            FindObjectOfType<Snake>().dir = -Vector2.right;
        }
    }
}
