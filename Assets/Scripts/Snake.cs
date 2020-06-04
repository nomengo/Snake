using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Snake : MonoBehaviour
{
    public GameObject tailPrefab;
    public SpawnFood foodSpawner;

    //did snake ate something
    public bool ate = false;
    public bool isFailed = false;

    public int takenFoodCount;

    //Keep track of tail
    List<Transform> tail = new List<Transform>();

    //current movement direction
    Vector2 dir = Vector2.right;

    private void Start()
    {
        takenFoodCount = 0;
        StartCoroutine("Move");
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = -Vector2.up;
        }
    }


    private IEnumerator Move()
    {
        while (true)
        {
            //save current position
            Vector2 gap = transform.position;

            //move head into the new direction
            transform.Translate(dir);

            //insert new element into the gap
            if (ate)
            {
                //load prefab into the world
                GameObject P = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);

                //keep track of it in our tail list
                tail.Insert(0, P.transform);

                //reset the flag 
                ate = false;
            }

            //do we have a tail?
            if(tail.Count > 0)
            {
                //move last tail element to where the head was
                tail.Last().position = gap;

                //add to front of the list remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Food")
        {
            //get longer in next move call
            ate = true;

            //remove the food
            Destroy(coll.gameObject);

            //update the food counter
            takenFoodCount++;
        }
        //collided with tail or border
        else
        {
            StopCoroutine("Move");
            foodSpawner.StopAllCoroutines();

            isFailed = true;

            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
        }
    }
}
