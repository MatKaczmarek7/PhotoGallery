using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public enum Scene
    {
        Main=1
    }

    private void Awake()
    {
        StartCoroutine(LoadingScene(Scene.Main));
    }

    private IEnumerator LoadingScene(Scene scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync((int)scene);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
    }
}
