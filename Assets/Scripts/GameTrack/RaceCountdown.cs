using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RaceCountdown : MonoBehaviour
{
    public static RaceCountdown instance = null;

    [SerializeField] private TextMeshProUGUI raceCountdownText;

    private readonly int countdownStartSeconds = 3;
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
    // Start is called before the first frame update
    void Start()
    {
        raceCountdownText.text = $"{countdownStartSeconds}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator StartRaceCountdown()
    {
        int counter = countdownStartSeconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            raceCountdownText.text = $"{counter}";
        }
        raceCountdownText.text = string.Empty;
        //ChangeBallMovableStatus(true);
        //Stopwatch.instance.StartStopwatch();
        //StateMachine.instance.FindOut(Events.BallÂeganToMove);
    }
}
