using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Transform placeholderParent = null;

    [SerializeField]
    private Transform defaultParentTransform;

    private Transform dragParentTransform;
    private Vector3 linkedInGameVector;
    private bool onMove = false;
    private GameObject placeholder = null;
    private GameObject starShip;
    private Text text;

    [SerializeField]
    private Sprite arrow;

    public Transform DefaultParentTransform
    {
        get { return defaultParentTransform; }
        set
        {
            if (value != null)
            {
                defaultParentTransform = value;
            }
        }
    }
    public Transform DragParentTransform
    {
        get { return dragParentTransform; }
        set
        {
            if (value != null)
            {
                dragParentTransform = value;
            }
        }
    }
    public Vector3 LinkedInGameVector
    {
        get { return linkedInGameVector; }
        set
        {
            if (value != null)
            {
                value.x = Math.Abs(value.x) > 3 ? 3 * Math.Sign(value.x) : value.x;
                value.y = Math.Abs(value.y) > 3 ? 3 * Math.Sign(value.y) : value.y;
                linkedInGameVector = value;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        CreatePlaceholder();

        placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());
        placeholderParent = DefaultParentTransform;
        transform.SetParent(DragParentTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        onMove = true;
        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onMove = false;

        transform.SetParent(DefaultParentTransform);
        Destroy(placeholder);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        return;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!onMove)
            starShip.GetComponent<StarShipController>().Move(LinkedInGameVector);
    }

    public void Start()
    {
        starShip = GameObject.FindGameObjectWithTag("Player");
        text = gameObject.transform.GetChild(0).GetComponent<Text>();
        text.text = $"X: {linkedInGameVector.x} ; Y: {linkedInGameVector.y}";
        gameObject.transform.GetChild(1).GetComponent<Image>().sprite = arrow;
        gameObject.transform.GetChild(1).transform.eulerAngles = -1 * new Vector3(0, 0,
                                                                      57.295782f * Mathf.Atan2(
                                                                                   linkedInGameVector.x,
                                                                                   linkedInGameVector.y));
    }

    private void CreatePlaceholder()
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent(transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;
    }
}