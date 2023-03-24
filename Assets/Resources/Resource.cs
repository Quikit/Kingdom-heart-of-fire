using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    // Start is called before the first frame update
    public int minVal;
    public int maxVal;

    public int destroyWithTime(float despawnTime)
    {
         Destroy(gameObject, despawnTime);
         return Random.Range(minVal, maxVal);
    }
}
