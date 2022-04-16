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

    public void LaunchGameTrack()
    {
        SceneManager.LoadScene("GameTrack");
    }

    public void ShowResultsScreen(Action postLoad)
    {
        //SceneManager.LoadScene("ResultsScreen");
        StartCoroutine(AsyncLoadScene("ResultsScreen", "GameTrack", postLoad));
        
    }

    // https://answers.unity.com/questions/1297392/how-do-i-get-a-reference-to-an-object-in-another-s.html
    public IEnumerator AsyncLoadScene(string newSceneName, string oldSceneName, Action postLoad)
    {
        Debug.Log("AsyncLoadScene");
        yield return SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(newSceneName));

        postLoad();

        yield return new WaitForEndOfFrame();
        SceneManager.UnloadSceneAsync(oldSceneName);
    }
}
