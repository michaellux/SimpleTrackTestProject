using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsUIController : MonoBehaviour
{
    [SerializeField] Text resultText;

    public static ResultsUIController instance = null;
    // Start is called before the first frame update
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

        resultText.text = "Таблица рекордов";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateResults(PlayerStatuses status)
    {
        UpdateResultText(status);
    }

    public void UpdateResultText(PlayerStatuses status)
    {
        switch (status)
        {
            case PlayerStatuses.Win:
                resultText.text = $"Вы выиграли. Результат: {Player.instance.raceResult} секунд";
                break;
            case PlayerStatuses.Lose:
                resultText.text = "Вы проиграли";
                break;
            case PlayerStatuses.NotPlayingNow:
                resultText.text = "Таблица рекордов";
                break;
            default:
                resultText.text = "Таблица рекордов";
                break;
        }
    }
}
