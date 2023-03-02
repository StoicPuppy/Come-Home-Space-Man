using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private AsyncOperation async;

    public void Load()
    {
        if(async == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
        }
    }

    public void Load(int index)
    {
        if (async == null)
        {
            async = SceneManager.LoadSceneAsync(index);
        }
    }

    public void Load(string name)
    {
        if (async == null)
        {
            async = SceneManager.LoadSceneAsync(name);
        }
    }
}
