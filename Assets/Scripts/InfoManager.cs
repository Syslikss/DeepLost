using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoManager : MonoBehaviour
{
    [SerializeField]
    private GameObject InfoPanel;

    public void ShowInfo()
    {
        InfoPanel.SetActive(true);
    }

    public void HideInfo()
    {
        InfoPanel.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}