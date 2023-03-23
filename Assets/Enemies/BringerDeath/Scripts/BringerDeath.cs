using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerDeath : Character
{
    private string TargetTag = "Target";


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(TargetTag).transform;
        flippedSkin();
        //player = GameObject.FindGameObjectWithTag("player").transform;
        //animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        //States();
       // flipScin();
    }

    // public void States()
    // {
       
    //     if (Vector2.Distance(transform.position, spawnPoint.position) < positionPatrole && angry == false )
    //     {
    //         chill = true;
    //         animator.SetBool("run", true);
    //     }
    //     if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
    //     {
    //         angry = true;
    //         chill = false;
    //         back = false;
    //     }
    //     if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
    //     {
    //         back = true;
    //         angry = false;
    //     }

    //     if (chill)
    //     {
    //         Chill();
    //     } else if (angry)
    //     {
    //         Angry();
    //         Attack();
    //     } else if (back)
    //     {
    //         GoBack();
    //     }
    // }

    // void Chill()
    // {
    //     float positionX = transform.position.x;
    //     float spawnPointPositionX = spawnPoint.position.x;
    //     if(positionX > spawnPointPositionX + positionPatrole)
    //     {
    //         moveingRight = false;
    //     }
    //     if(positionX < spawnPointPositionX - positionPatrole)
    //     {
    //         moveingRight = true;
    //     }

    //     if(moveingRight)
    //     {
    //         transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    //         Vector3 rotate = transform.eulerAngles;
    //         rotate.y = TURN_LEFT;
    //         transform.rotation = Quaternion.Euler(rotate);
    //     } else 
    //     {
    //         transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    //         Vector3 rotate = transform.eulerAngles;
    //         rotate.y = TURN_RIGHT;
    //         transform.rotation = Quaternion.Euler(rotate);
    //     }
    // }

    // void Angry()
    // {
    //     transform.position = Vector2.MoveTowards(transform.position, player.position, fastSpeed * Time.deltaTime);
    // }

    // void Attack()
    // {
    //     animator.SetFloat("attack", Vector2.Distance(transform.position, player.position));
    //     Debug.Log(Vector2.Distance(transform.position, player.position));
    // }

    // void GoBack()
    // {
    //     transform.position = Vector2.MoveTowards(transform.position, spawnPoint.position, speed * Time.deltaTime);
    // }

    // void Spawn()
    // {
        
    // }

    // void UnSpawn()
    // {

    // }
}
