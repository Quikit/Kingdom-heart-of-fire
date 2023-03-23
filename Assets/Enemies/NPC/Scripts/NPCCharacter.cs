using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCharacter : MonoBehaviour
{
    public float speed;
    public int despawnTime;
    public GameObject target;
    public GameObject fire;
    public bool skinLookRight;
    protected GameObject storage;
    protected int numberOfResources;

    public void flippedSkin(){
        if(gameObject.transform.position.x < fire.transform.position.x && !skinLookRight ||
           gameObject.transform.position.x > fire.transform.position.x && skinLookRight){
            const int DEGREES = 180;
            Vector3 rotate = transform.eulerAngles;
            rotate.y = DEGREES;
            transform.rotation = Quaternion.Euler(rotate);
        }
    }

    public void despawn(){
        Destroy(gameObject, despawnTime);
    }

    public GameObject getNearestTargetByTag(string tag)
    {
        Transform NPCPosition = gameObject.transform;
        GameObject[] targets =  GameObject.FindGameObjectsWithTag(tag);
        if(targets.Length == 0){
            return null;
        }
        GameObject NearestTarget = targets[0];
        foreach (GameObject target in targets){
            float DistanceNearest = Mathf.Abs(NearestTarget.transform.position.x - gameObject.transform.position.x);
            float DistanceNextNearest = Mathf.Abs(target.transform.position.x - gameObject.transform.position.x);
            if(DistanceNearest > DistanceNextNearest){
                NearestTarget = target;
            }
        }
        return NearestTarget;
    }
}
