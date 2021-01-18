using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : BasePanel, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private void Start()
    {
        List<Vector3> vector3s = new List<Vector3> { new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0) };

        for (int i = 0; i < vector3s.Count; i++)
        {
            var dragObject = Instantiate(DragElementPrefab, scrollViewContent);
            var script = dragObject.GetComponent<DragElement>();
            script.DefaultParentTransform = scrollViewContent;
            script.DragParentTransform = transform;
            script.LinkedInGameVector = vector3s[i];
        }
    }
}