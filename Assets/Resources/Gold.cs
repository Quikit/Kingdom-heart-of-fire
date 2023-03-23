using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Resource
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Inventory.Instance.AddGold(1);
            destroyWithTime(0);
        }
    }
}
