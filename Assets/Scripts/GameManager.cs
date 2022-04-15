using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public StateMachine StateMachine { get; set; }

    public static GameManager instance = null;
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

        StateMachine = new StateMachine();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
