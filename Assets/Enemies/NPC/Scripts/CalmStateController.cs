using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CalmStateController : MonoBehaviour
{
    private string tagName = "CalmLabel";
    private GameObject leftCalm;
    private GameObject rightCalm;

    public void updateCalmLabel()
    {
        GameObject[] allCalmStates = GameObject.FindGameObjectsWithTag(tagName);
        leftCalm = allCalmStates[0];
        rightCalm = allCalmStates[0];
        foreach (GameObject calmState in allCalmStates)
        {
            if(calmState.transform.position.x < leftCalm.transform.position.x)
            {
                leftCalm = calmState;
            }
            if(calmState.transform.position.x > rightCalm.transform.position.x)
            {
                rightCalm = calmState;
            }
        }
    }

    public GameObject getLeftCalmLabel()
    {
        return leftCalm;
    }
    public GameObject getRightCalmLabel()
    {
        return rightCalm;
    }
}
