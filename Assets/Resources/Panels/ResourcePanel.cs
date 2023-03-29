using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePanel : MonoBehaviour
{
    public GameObject resourcePanel;
    public GameObject resourceTarget;
    public string resourceTag;
    private bool active;
    public void Start()
    {
        showMenu(false);
    }
    public void showMenu(bool flag){
       if (resourcePanel != null)
        {
            active = flag;
            if (active)
            {
                resourcePanel.SetActive(true);
            }
            else
            {
                resourcePanel.SetActive(false);
            }
       }
    }
    public bool getActive()
    {
        return active;
    }
    public void OnClickExtract(){
        markObject();
        GameObject NPC = NPCCharacter.getNearestNPCByTarget(resourceTarget);
        NPCController npcController = NPC.GetComponent<NPCController>();
        npcController.addTarget(resourceTarget);
        showMenu(false);
    }
    public void OnClickCancel()
    {
        UnMarkObject();
        showMenu(false);
    }
    private void markObject()
    {
        resourceTarget.GetComponent<Renderer>().material.color = Color.green;
        resourceTarget.GetComponent<Resource>().setMark(true);
    }
    private void UnMarkObject()
    {
        resourceTarget.GetComponent<Renderer>().material.color = Color.white;
        resourceTarget.GetComponent<Resource>().setMark(false);
    }
}
