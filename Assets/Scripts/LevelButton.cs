using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, IPointerDownHandler
{
    public Text text;
    private int SceneIndex { get; set; }
    private string SceneName { get; set; }

    public bool active = false;

    // Start is called before the first frame update
    public void LevelButtonInst(int sceneIndex, int textIndex)
    {
        text = gameObject.transform.GetChild(0).GetComponent<Text>(); text.text = $"1";
        text.text = $"1";
        SceneIndex = sceneIndex;
        text.text = $"{textIndex}";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (active)
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }
}