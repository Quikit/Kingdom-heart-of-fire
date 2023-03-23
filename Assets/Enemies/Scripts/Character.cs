using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public float fastSpeed;
    public Transform spawnPoint;
    public int despawnTime;
    protected Transform target;
    public bool skinLookRight;
    public bool patroller;
    public float patrollDistance;
    public void move(){
        if(!patroller){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void attack(){
        
    }

    public void flippedSkin(){
        if(gameObject.transform.position.x < target.position.x && !skinLookRight ||
           gameObject.transform.position.x > target.position.x && skinLookRight){
            const int DEGREES = 180;
            Vector3 rotate = transform.eulerAngles;
            rotate.y = DEGREES;
            transform.rotation = Quaternion.Euler(rotate);
        }
    }

    public void despawn(){
        Destroy(gameObject, despawnTime);
    }
}
