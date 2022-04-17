using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] TextMeshProUGUI raceCountdownText;

    private readonly int countdownStartSeconds = 3;

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

    void Start()
    {
        raceCountdownText.text = $"{countdownStartSeconds}";
    }

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void StartRace()
    {
        StartCoroutine(RaceCountdown());
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

    public void ChangeBallMovableStatus(bool desiredStatus)
    {
        ball.GetComponent<Ball>().ChangeBallMovableStatus(desiredStatus);
    }

    public void ShowBall()
    {
        ball.SetActive(true);
    }

    public void HideBall()
    {
        ball.SetActive(false);
    }

    private IEnumerator RaceCountdown()
    {
        int counter = countdownStartSeconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            raceCountdownText.text = $"{counter}";
        }
        raceCountdownText.text = string.Empty;
        ChangeBallMovableStatus(true);
        Stopwatch.instance.StartStopwatch();
        StateMachine.instance.FindOut(Events.BallÂeganToMove);
    }

    public void WriteResult()
    {
        Player.instance.raceResult = Stopwatch.instance.time.Seconds;
    }
}
