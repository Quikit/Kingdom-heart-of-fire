using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCUI : MonoBehaviour
{
    public Image NPCState;
    public float TriggerMenuRendering;
    private Transform Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        showMenu();
    }

    void showMenu(){
        // if(NPCController.NCPBoxCollider2D.transform.position.x + TriggerMenuRendering > Player.transform.position.x)
        // {
        //     Vector2 position = NPCController.NCPBoxCollider2D.transform.position;
        //     position.y += 1;
        //     Instantiate(NPCState, position, Quaternion.identity);
        //     Debug.Log("Отрисовал кнопку");
        // } 
        // else
        // {
        //     Destroy(NPCState);
        //     Debug.Log("Убрал кнопку");
        // }
    }
}
