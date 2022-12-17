using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 0.01f;
    public float LeftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

     void Start()
     {
         Invoke("DropApple" , 1f);
     }

     void DropApple()
     {
         GameObject apple = Instantiate<GameObject>(applePrefab);
         apple.transform.position = transform.position;
         Invoke("DropApple" , secondsBetweenAppleDrops);
     }

    void FixedUpdate()
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
            speed += -0.01f;
        }
        
    }
}
