using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ball;

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

        //StateMachine = new StateMachine();
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

    public void PauseRace()
    {
        HideBall();
    }

    public void ResumeRace()
    {
        ShowBall();
    }

    public void DestroyBall()
    {
        Destroy(ball);
    }

    public void ShowBall()
    {
        ball.SetActive(true);
    }

    public void HideBall()
    {
        ball.SetActive(false);
    }

    public void WriteResult()
    {
        Player.instance.raceResult = Stopwatch.instance.time.Seconds;
    }
}
