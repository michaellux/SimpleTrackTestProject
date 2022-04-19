using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject ballPrefab;
    private GameObject ballOnScene;

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
    }

    void Start()
    {
        
    }

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void StartRace()
    {
        SetBallOnTrack();
        StartCoroutine(LaunchRaceCountdown());
    }

    public void StopRace()
    {
        Stopwatch.instance.StopStopwatch();
        RemoveBall();
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

    public void SetBallOnTrack()
    {
        ballOnScene = Instantiate(ballPrefab, playerTransform);
    }

    public void RemoveBall()
    {
        Destroy(ballOnScene);
    }

    public void ChangeBallMovableStatus(bool desiredStatus)
    {
        ballOnScene.GetComponent<Ball>().ChangeBallMovableStatus(desiredStatus);
    }

    public void ShowBall()
    {
        ballOnScene.SetActive(true);
    }

    public void HideBall()
    {
        ballOnScene.SetActive(false);
    }

    private IEnumerator LaunchRaceCountdown()
    {
        yield return StartCoroutine(RaceCountdown.instance.StartRaceCountdown());
        ChangeBallMovableStatus(true);
        Stopwatch.instance.StartStopwatch();
        StateMachine.instance.FindOut(Events.BallÂeganToMove);
    }

    public void WriteResult()
    {
        Player.instance.raceResult = Stopwatch.instance.time.Seconds;
    }
}
