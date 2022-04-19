using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesController : MonoBehaviour
{
    public static ScenesController instance = null;
    public delegate void operationsAfterLoading();

    void Start()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion
    }

    public void LoadMainScreenScene(Action postload, string oldSceneName, bool isAsyncLoad)
    {
        if (isAsyncLoad)
        {
            StartCoroutine(AsyncLoadScene("MainScreen", oldSceneName, postload));
        }
        else
        {
            SceneManager.LoadScene("MainScreen");
            postload();
        }
    }

    public void LoadGameTrackScene(Action postLoad, string oldSceneName, bool isAsyncLoad)
    {
        if (isAsyncLoad)
        {
            StartCoroutine(AsyncLoadScene("GameTrack", oldSceneName, postLoad));
        }
        else
        {
            SceneManager.LoadScene("GameTrack");
            postLoad();
        }
    }

    public void LoadResultsScreenScene(Action postLoad, string oldSceneName, bool isAsyncLoad)
    {
        if (isAsyncLoad)
        {
            StartCoroutine(AsyncLoadScene("ResultsScreen", oldSceneName, postLoad));
        }
        else
        {
            SceneManager.LoadScene("ResultsScreen");
            postLoad();
        }
    }

    //based on https://answers.unity.com/questions/1297392/how-do-i-get-a-reference-to-an-object-in-another-s.html
    public IEnumerator AsyncLoadScene(string newSceneName, string oldSceneName, Action postLoad)
    {
        yield return SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newSceneName));

        postLoad();
    }
}
