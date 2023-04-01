using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCharacter : MonoBehaviour
{
    public float speed;
    public float lowSpeed;
    public int despawnTime;
    public GameObject fire;
    public bool skinLookRight;
    protected GameObject storage;
    protected int numberOfResources;

    public float MaxSleepCalmTimer;
    protected float sleepCalmTimer;
    protected bool calmStateTargetComplete;
    protected bool calmState;
    protected float calmRandomPosition;
    protected CalmStateController calmStateController;

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

    public static GameObject getNearestNPCByTarget(GameObject target)
    {
        Transform targetPostiton = target.transform;
        GameObject[] NPCs = GameObject.FindGameObjectsWithTag("WorkerNPC");
        if (NPCs.Length == 0)
        {
            return null;
        }
        ArrayList ListNPCWitoutJob = new ArrayList();
        // Поиск всех безработных NPC
        foreach (GameObject NPC in NPCs)
        {
            NPCController NPCController = NPC.GetComponent<NPCController>();
            if(NPCController.getTargets().Count == 0)
            {
                ListNPCWitoutJob.Add(NPC);
            }
        }
        // Выбор пближайшего безработного NPC
        if (ListNPCWitoutJob.Count != 0)
        {
            GameObject NearestNPCWitoutJob = (GameObject)ListNPCWitoutJob[0];
            foreach (GameObject NPCWitoutJob in ListNPCWitoutJob)
            {
                float DistanceNearest = Mathf.Abs(targetPostiton.transform.position.x - NearestNPCWitoutJob.transform.position.x);
                float DistanceNextNearest = Mathf.Abs(targetPostiton.transform.position.x - NPCWitoutJob.transform.position.x);
                if (DistanceNearest > DistanceNextNearest)
                {
                    NearestNPCWitoutJob = NPCWitoutJob;
                }
            }
            return NearestNPCWitoutJob;
        } else {
        // Выбор NPC с наименьшей загруженностью
            GameObject NearestNPC = NPCs[0];
            foreach (GameObject NPC in NPCs)
            {
                NPCController NearestNPCController = NearestNPC.GetComponent<NPCController>();
                NPCController NextNPCController = NPC.GetComponent<NPCController>();
                float DistanceNearest = Mathf.Abs(targetPostiton.transform.position.x - NearestNPC.transform.position.x);
                float DistanceNextNearest = Mathf.Abs(targetPostiton.transform.position.x - NPC.transform.position.x);
                if (NextNPCController.getTargets().Count <= NearestNPCController.getTargets().Count)
                {
                    NearestNPC = NPC;
                }
            }
            return NearestNPC;
        }
    }
    //public static GameObject getNPCByTargetPosition(GameObject target)
    //{
    //    GameObject[] NPCs = GameObject.FindGameObjectsWithTag("WorkerNPC");
     //   if (NPCs.Length == 0)
    //    {
    //        return null;
    //    }
     //   foreach (GameObject NPC in NPCs)
      //  {
      //      GameObject NPCTarget = NPC.GetComponent<NPCController>().target;
    //
      //      if (NPCTarget != null)
       //     {
      ////          float targetX = target.transform.position.x;
     ///           float targetY = target.transform.position.y;
        //        if (targetX == NPCTarget.transform.position.x && targetY == NPCTarget.transform.position.y)
        //        {
       //             return NPC;
       //         }
       //     }
       // }
      //  return null;
   // }
}
