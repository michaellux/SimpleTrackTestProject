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
                resultText.text = "Вы выиграли";
                break;
            case PlayerStatuses.Lose:
                resultText.text = "Вы проиграли";
                break;
            case PlayerStatuses.NotPlayingNow:
                resultText.text = "Таблица рекордов";
                break;
            default:
                break;
        }
    }
}
