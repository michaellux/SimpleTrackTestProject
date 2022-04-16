using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
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

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void StartRace()
    {
        Stopwatch.instance.StartStopwatch();
    }

    public void StopRace()
    {
        Stopwatch.instance.StopStopwatch();
        DestroyBall();
        WriteResult();
    }

    public void DestroyBall()
    {
        Destroy(ball);
    }

    public void WriteResult()
    {
       Player.instance.raceResult = Stopwatch.instance.time.Seconds;
    }
}
