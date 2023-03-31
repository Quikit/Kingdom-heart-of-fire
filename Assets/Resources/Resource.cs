using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    // Start is called before the first frame update
    public int minVal;
    public int maxVal;
    private bool activeMark;

    public int destroyWithTime(float despawnTime)
    {
        activeMark = false;
        Destroy(gameObject, despawnTime);
        return Random.Range(minVal, maxVal);
    }

    public void setMark(bool flag)
    {
        activeMark = flag;
    }
    public bool getMark()
    {
        return activeMark;
    }
}
