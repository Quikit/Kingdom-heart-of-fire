using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : NPCCharacter
{
    public bool extractWood;
    public bool extractStone;
    public float extractionRange;
    public float timeOfDestroy;

    private bool extractComplete;
    void Start()
    {
        numberOfResources = 0;
        storage = GameObject.FindGameObjectWithTag("Storage");
        flippedSkin();
    }

    void Update()
    {
       setTarget();
       move();
    }

    void setTarget()
    {
        if(target == null)
        {
            if(extractWood)
            {
                target = getNearestTargetByTag("Wood");
            }
            else if(extractStone)
            {
                target = getNearestTargetByTag("Stone");
            }
        }
        dropTarger();
    }

    void move()
    {
        if(target != null && !extractComplete)
        {
            if(Mathf.Abs(transform.position.x - target.transform.position.x) > extractionRange) {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            } else {
                job();
            }
        } else {
            goToStorage();
        }
    }

    void job()
    {
        if(extractWood){
            numberOfResources = target.gameObject.GetComponent<Wood>().destroyWithTime(timeOfDestroy);
            extractComplete = true;
        }
        if(extractStone){
            numberOfResources = target.gameObject.GetComponent<Stone>().destroyWithTime(timeOfDestroy);
            extractComplete = true;
        }
        Debug.Log(numberOfResources);
    }

    void goToStorage()
    {
        if(extractComplete){
            if(Mathf.Abs(transform.position.x - storage.transform.position.x) > extractionRange) {
                transform.position = Vector2.MoveTowards(transform.position, storage.transform.position, speed * Time.deltaTime);
            } else {
                if(extractWood){
                    Inventory.Instance.AddWood(numberOfResources);
                    numberOfResources = 0;
                    extractComplete = false;
                }
                if(extractStone){
                    Inventory.Instance.AddStone(numberOfResources);
                    numberOfResources = 0;
                    extractComplete = false;
                }
            }
        }
    }

    void dropTarger()
    {
        if(!extractWood && !extractStone){
            target = null;
        }
    }

    public void dropTargetAll()
    {
        extractWood = false;
        extractStone = false;
        extractComplete = false;
        target = null;
    }
}
