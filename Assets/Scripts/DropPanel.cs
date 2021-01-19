using UnityEngine;
using UnityEngine.EventSystems;

public class DropPanel : BasePanel, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Transform ResultPanel;

    [SerializeField]
    private Transform ExactDragPanel;

    public override void OnDrop(PointerEventData eventData)
    {
        if (transform.GetChild(0).childCount <= 2)
        {
            base.OnDrop(eventData);
        }
    }

    public void Sum()
    {
        if (ResultPanel.childCount != 0)
        {
            return;
        }

        Transform transformChild = transform.GetChild(0);
        if (transformChild.childCount == 2)
        {
            var dragObject = Instantiate(DragElementPrefab, scrollViewContent);
            var script = dragObject.GetComponent<DragElement>();
            script.DefaultParentTransform = ResultPanel;
            script.DragParentTransform = ExactDragPanel.transform;
            script.placeholderParent = DragPanelTransform.transform;
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
        if (ResultPanel.childCount != 0)
        {
            return;
        }

        Transform teansformChild = transform.GetChild(0);
        if (teansformChild.childCount == 2)
        {
            var dragObject = Instantiate(DragElementPrefab, scrollViewContent);
            var script = dragObject.GetComponent<DragElement>();
            script.DefaultParentTransform = ResultPanel;
            script.DragParentTransform = ExactDragPanel.transform;
            script.placeholderParent = DragPanelTransform.transform;
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