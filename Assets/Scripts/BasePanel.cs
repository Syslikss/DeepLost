using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasePanel : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject DragPanelTransform;
    public GameObject DragElementPrefab;
    public Transform scrollViewContent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        if (eventData.pointerDrag == null)
            return;

        DragElement d = eventData.pointerDrag.GetComponent<DragElement>();
        if (d != null)
            d.placeholderParent = transform.GetChild(0).transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        if (eventData.pointerDrag == null)
            return;

        DragElement d = eventData.pointerDrag.GetComponent<DragElement>();
        if (d != null && d.placeholderParent == transform.GetChild(0).transform)
            d.placeholderParent = d.DefaultParentTransform;
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
        DragElement d = eventData.pointerDrag.GetComponent<DragElement>();
        if (d != null)
        {
            d.DefaultParentTransform = transform.GetChild(0).transform;
        }
    }
}