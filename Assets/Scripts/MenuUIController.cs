using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public static MenuUIController instance = null;
    void Awake()
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchGameTrack()
    {
        ScenesController.instance.LoadGameTrackScene();
    }

    public void ShowResults()
    {
        ScenesController.instance.LoadResultsScreenScene(() => { }, "MainScreen");
    }
}
