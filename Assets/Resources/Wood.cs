using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;

public class Wood : Resource, IPointerClickHandler
{
    private WoodPanel woodPanel;
    void Start()
    {
        GameObject ui = GameObject.FindGameObjectWithTag("UI");
        woodPanel = ui.GetComponent<WoodPanel>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        woodPanel.showMenu(!woodPanel.getActive());
        woodPanel.woodTarget = gameObject;
    }
}
