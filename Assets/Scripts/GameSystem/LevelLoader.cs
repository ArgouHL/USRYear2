using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static void NewGame(StageDataObj stageData)
    {
        StageControl.instance.SetCurrentLevel(stageData);
        SceneManager.LoadScene("GamePlay");
    }

    public static void NextWeek()
    {

        SceneManager.LoadScene("GamePlay");
    }
}
