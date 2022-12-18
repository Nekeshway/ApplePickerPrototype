using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed ;
    public float LeftAndRightEdge;
    public float chanceToChangeDirections;
    public float secondsBetweenAppleDrops;
    public float speeding;
    public float droppingApples;

    private void Start()
     {
         Invoke("DropApple" , droppingApples);
     }

    private void DropApple()
     {
         GameObject apple = Instantiate<GameObject>(applePrefab);
         apple.transform.position = transform.position;
         Invoke("DropApple" , secondsBetweenAppleDrops);
     }

    private  void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x += speed + Time.deltaTime;
        transform.position = pos;
        if (pos.x < -LeftAndRightEdge)
        {
            speed = Math.Abs(speed);
        }else if (pos.x > LeftAndRightEdge)
        {
            speed = -Math.Abs(speed);
        }else if (Random.value < chanceToChangeDirections)
        {
            speed += speeding;
        }
        
    }
}
