using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    
    //food prefab
    public GameObject FoodObject;

    public Snake snake;

    //borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start()
    {
      //spawn food every 4 seconds, starting in 3
        //InvokeRepeating("Spawn", 3, 4);

        //In my case ı rather do it with coroutine
        StartCoroutine("Spawn");
    }

    //spawn the food
    public IEnumerator Spawn()
    {
        while(true)
        {
        //x position between somewhere in the left and right border
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        //y position between somewhere in the top and bottom border
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        //Instantiate the food
        Instantiate(FoodObject, new Vector2(x, y), Quaternion.identity);

            yield return new WaitUntil(() => snake.ate);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public bool DidEat()
    {
        return snake.ate;
    }

}
