using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance = null;

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
    public void ShowResultsScreen()
    {
        SceneManager.LoadScene("ResultsScreen");
    }
}
