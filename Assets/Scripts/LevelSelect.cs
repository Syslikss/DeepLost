using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject LevelButtonPrefab;
    public Transform LevelSelectPanel;
    private int unlockdLevels = 5;

    // Start is called before the first frame update
    private void Start()
    {
        var levelCount = SceneManager.sceneCountInBuildSettings;
        //GetCountUnlockedLevels();
        var enumerete = 0;
        for (int i = 0; i < levelCount; i++)
        {
            var sceneName = SceneUtility.GetScenePathByBuildIndex(i);
            if (sceneName != null && sceneName.Contains("Level"))
            {
                enumerete++;
                var levelObject = Instantiate(LevelButtonPrefab, LevelSelectPanel);
                var script = levelObject.GetComponent<LevelButton>();
                script.LevelButtonInst(i, enumerete);
                if (i <= unlockdLevels)
                {
                    script.active = true;
                }
            }
        }
    }

    private void GetCountUnlockedLevels()
    {
        var path = @".\data.txt";
        var fileInf = new FileInfo(path);
        if (fileInf.Exists)
        {
            using (var sr = fileInf.OpenText())
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    unlockdLevels = int.Parse(s);
                }
            }
        }
        else
        {
            fileInf.Create();
        }
    }

    public void IncUnlockdLevels()
    {
        unlockdLevels++;
    }

    public void Exit()
    {
        Application.Quit();
    }
}