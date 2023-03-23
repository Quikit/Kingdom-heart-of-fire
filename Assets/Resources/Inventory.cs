using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int GoldCount { get; private set; }

    public int WoodCount { get; private set; }
    public int StoneCount { get; private set; }
    public static Inventory Instance { get; private set; }
    public event System.Action<Inventory> OnUpdateGold;
    public event System.Action<Inventory> OnUpdateWood;
    public event System.Action<Inventory> OnUpdateStone;
    public void AddGold (int count){
        GoldCount += count;
        if (OnUpdateGold != null)
        {
            OnUpdateGold(this);
        }
    }
    public void AddWood (int count){
        WoodCount += count;
        if (OnUpdateWood != null)
        {
            OnUpdateWood(this);
        }
    }
    public void AddStone (int count){
        StoneCount += count;
        if (OnUpdateStone != null)
        {
            OnUpdateStone(this);
        }
    }
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy(){
        Instance = null;
    }
}
