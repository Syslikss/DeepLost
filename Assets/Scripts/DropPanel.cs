using UnityEngine;
using UnityEngine.EventSystems;

public class DropPanel : BasePanel, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public override void OnDrop(PointerEventData eventData)
    {
        if (transform.GetChild(0).childCount <= 2)
        {
            base.OnDrop(eventData);
        }
    }

    public void Clear()
    {
        for (int i = transform.GetChild(0).childCount - 1; i >= 0; i--)
        {
            transform.GetChild(0).GetChild(i).GetComponent<DragElement>().DefaultParentTransform = DragPanelTransform.transform;
            transform.GetChild(0).GetChild(i).GetComponent<DragElement>().placeholderParent = DragPanelTransform.transform;
            transform.GetChild(0).GetChild(i).transform.SetParent(DragPanelTransform.transform);
        }
    }

    public void Sum()
    {
        Transform transformChild = transform.GetChild(0);
        if (transformChild.childCount == 2)
        {
            var dragObject = Instantiate(DragElementPrefab, scrollViewContent);
            var script = dragObject.GetComponent<DragElement>();
            script.DefaultParentTransform = scrollViewContent;
            script.DragParentTransform = scrollViewContent;
            script.LinkedInGameVector = Vector3.zero;
            for (var i = transformChild.childCount - 1; i >= 0; i--)
            {
                var elem = transformChild.GetChild(i).GetComponent<DragElement>();
                script.LinkedInGameVector += elem.LinkedInGameVector;
            }

            Clear();
        }
    }

    public void Min()
    {
        Transform teansformChild = transform.GetChild(0);
        if (teansformChild.childCount == 2)
        {
            var dragObject = Instantiate(DragElementPrefab, scrollViewContent);
            var script = dragObject.GetComponent<DragElement>();
            script.DefaultParentTransform = scrollViewContent;
            script.DragParentTransform = scrollViewContent;
            script.LinkedInGameVector = Vector3.zero;
            for (var i = teansformChild.childCount - 1; i >= 0; i--)
            {
                if (i == 0)
                    script.LinkedInGameVector += teansformChild.GetChild(i).GetComponent<DragElement>().LinkedInGameVector;
                else
                    script.LinkedInGameVector -= teansformChild.GetChild(i).GetComponent<DragElement>().LinkedInGameVector;
            }

            Clear();
        }
    }
}