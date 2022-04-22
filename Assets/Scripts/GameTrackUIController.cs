using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTrackUIController : MonoBehaviour
{
    public static GameTrackUIController instance = null;

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

    public void SetUIAccordingToInputMode()
    {
        if (InputManager.instance.GetCurrentInputMode() == InputModes.Touch)
        {
            gameObject.SetActive(true);
        }
        else if (InputManager.instance.GetCurrentInputMode() == InputModes.Accelerometer)
        {
            gameObject.SetActive(false);
        }
    }
}
