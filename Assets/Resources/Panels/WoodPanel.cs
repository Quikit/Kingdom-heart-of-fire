using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPanel : MonoBehaviour
{
    public GameObject woodPanel;
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
}
