using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NPCController : NPCCharacter
{
    public bool extractWood;
    public bool extractStone;
    public float extractionRange;
    public float timeOfDestroy;
    private bool extractComplete;

    private Queue<GameObject> targets;
    private GameObject currentTarget;
    void Start()
    {
        numberOfResources = 0;
        targets = new Queue<GameObject>();
        storage = GameObject.FindGameObjectWithTag("Storage");
        calmStateController = GameObject.FindGameObjectWithTag("CalmController").GetComponent<CalmStateController>();
        flippedSkin();
    }

    void Update()
    {
        setTarget();
        move();
        setState();
        stateController();
    }

    void setTarget()
    {
         /*if(targets.Count == 0 && currentTarget == null)
         {
            if(extractWood)
            {
                targets.Enqueue(getNearestTargetByTag("Wood"));
            }
            if(extractStone)
            {
                targets.Enqueue(getNearestTargetByTag("Stone"));
            }
        }*/
        if (targets.Count != 0 && currentTarget == null)
        {
            GameObject target = targets.Peek();
            if (!target.IsDestroyed() && target.GetComponent<Resource>().getMark())
            {
                currentTarget = target;
            }
            
        }
        if (currentTarget != null && !currentTarget.GetComponent<Resource>().getMark())
        {
            currentTarget = null;
            targets.Dequeue();
        }
    }
    private void setState()
    {
       if(targets.Count == 0 && currentTarget == null && calmState == false)
       {
            calmState = true;
            calmStateTargetComplete = false;
            calmStateController.updateCalmLabel();
            calmRandomPosition = Random.Range(calmStateController.getLeftCalmLabel().transform.position.x, calmStateController.getRightCalmLabel().transform.position.x);
       } 
       else if (targets.Count != 0 || currentTarget != null)
       {
            calmState = false;
       }
    }
    private void stateController()
    {
        if (calmState)
        {
            if (!calmStateTargetComplete && Mathf.Abs(transform.position.x - calmRandomPosition) > extractionRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(calmRandomPosition, 0), lowSpeed * Time.deltaTime);
            } 
            else if(!calmStateTargetComplete) 
            {
                calmStateTargetComplete = true;
                if(sleepCalmTimer <= 0)
                {
                    sleepCalmTimer = Random.Range(0, MaxSleepCalmTimer);
                } 
            }
            if (calmStateTargetComplete)
            {
                if (sleepCalmTimer > 0)
                {
                    sleepCalmTimer -= Time.deltaTime;
                    Debug.Log("timer:" + sleepCalmTimer + " deltaTime:" + Time.deltaTime);
                } 
                else
                {
                    calmStateTargetComplete = false;
                    calmStateController.updateCalmLabel();
                    calmRandomPosition = Random.Range(calmStateController.getLeftCalmLabel().transform.position.x, calmStateController.getRightCalmLabel().transform.position.x);
                }
            }
        }
    }

    void move()
    {
        if (currentTarget != null && !extractComplete)
        {
            if (Mathf.Abs(transform.position.x - currentTarget.transform.position.x) > extractionRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
            }
            else
            {
                checkExtractTag(currentTarget);
                job();
            }
            
        } else {
            goToStorage();
        }
    }

    void job()
    {
        if(extractWood){
            numberOfResources = currentTarget.gameObject.GetComponent<Wood>().destroyWithTime(timeOfDestroy);
        }
        if(extractStone){
            numberOfResources = currentTarget.gameObject.GetComponent<Stone>().destroyWithTime(timeOfDestroy);
        }
        extractComplete = true;
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
                    extractWood = false;
                    extractComplete = false;
                    currentTarget = null;
                    targets.Dequeue();
                } else if(extractStone){
                    Inventory.Instance.AddStone(numberOfResources);
                    numberOfResources = 0;
                    extractStone = false;
                    extractComplete = false;
                    currentTarget = null;
                    targets.Dequeue();
                }
            }
        }
    }

    public void addTarget(GameObject target)
    {
        targets.Enqueue(target);
    }
    public Queue<GameObject> getTargets()
    {
        return targets;
    }
    private void checkExtractTag(GameObject target)
    {
        string tag = target.tag;
        if(tag == "Wood") {
            extractWood = true;
        }
        if (tag == "Stone"){
            extractStone = true;
        }
    }
}
