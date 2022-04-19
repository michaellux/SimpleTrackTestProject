using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//based on https://www.youtube.com/watch?v=HLz_k6DSQvU
public class Stopwatch : MonoBehaviour
{
    private bool stopwatchActive = false;
    private float currentTime;
    public TimeSpan time { get; set; }
    public int startMinutes;

    [SerializeField] private Text digitalScoreboardText;

    public static Stopwatch instance = null;

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
        #endregion
    }

    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive)
        {
            currentTime += Time.deltaTime;
        }
        time = TimeSpan.FromSeconds(currentTime);
        digitalScoreboardText.text = $"{time.Seconds}";
    }

    public void StartStopwatch()
    {
        stopwatchActive = true;
    }

    public void StopStopwatch()
    {
        stopwatchActive = false;
    }
}
