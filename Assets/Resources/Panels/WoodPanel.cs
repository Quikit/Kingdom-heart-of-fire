using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPanel : MonoBehaviour
{
    public GameObject woodPanel;
    public GameObject woodTarget;
    private bool active;
    public void Start()
    {
        showMenu(false);
    }
    public void showMenu(bool flag){
        active = flag;
        if (active && woodPanel != null)
        {
            woodPanel.SetActive(true);
        }
        else
        {
            woodPanel.SetActive(false);
        }
    }
    public bool getActive()
    {
        return active;
    }
    public void OnClickExtract(){
        GameObject NPC  = NPCCharacter.getNearestNPCByTarget(woodTarget);
        NPCController npcController = NPC.GetComponent<NPCController>();
        npcController.dropTargetAll();
        npcController.extractWood = true;
        npcController.target = woodTarget;
    }
    public void OnClickCancel()
    {
        GameObject NPC = NPCCharacter.getNPCByTargetPosition(woodTarget);
        if (NPC != null)
        {
            NPCController npcController = NPC.GetComponent<NPCController>();
            npcController.dropTargetAll();
        }
    }
}
