using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public Text GoldCount;
    public Text WoodCount;
    public Text StoneCount;
    public void Start(){
        Inventory.Instance.OnUpdateGold += UpdateUI;
        Inventory.Instance.OnUpdateStone += UpdateUI;
        Inventory.Instance.OnUpdateWood += UpdateUI;
    }
    public void UpdateUI(Inventory inventory){
        GoldCount.text = inventory.GoldCount.ToString();
        WoodCount.text = inventory.WoodCount.ToString();
        StoneCount.text = inventory.StoneCount.ToString();
    }
}
