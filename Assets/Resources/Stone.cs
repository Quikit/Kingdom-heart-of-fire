using UnityEngine;
using UnityEngine.EventSystems;

public class Stone : Resource, IPointerClickHandler
{
    private ResourcePanel resourcePanel;
    void Start()
    {
        GameObject ui = GameObject.FindGameObjectWithTag("UI");
        resourcePanel = ui.GetComponent<ResourcePanel>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (resourcePanel.resourceTarget == gameObject && resourcePanel.getActive() == true)
        {
            resourcePanel.showMenu(false);
        }
        else
        {
            resourcePanel.showMenu(true);
            resourcePanel.resourceTarget = gameObject;
            resourcePanel.resourceTag = gameObject.tag;
        }
    }
}
