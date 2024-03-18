using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneName: MonoBehaviour
{
    public string SceneName;

    public void GoToSceneX()
    {
        SceneManager.LoadScene(SceneName);
    }
}
