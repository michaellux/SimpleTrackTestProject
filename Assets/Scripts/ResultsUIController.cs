using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsUIController : MonoBehaviour
{
    [SerializeField] Text resultText;
    [SerializeField] Transform tableTransform;
    [SerializeField] GameObject tableRecord;
    [SerializeField] GameObject placeRecordValueText;
    [SerializeField] GameObject playerRecordValueText;
    [SerializeField] GameObject timeRecordValueText;

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

    public void UpdateTable(List<RecordsDataModel.Record> records)
    {
        ClearOldDataFromTable();

        foreach (var record in records.OrderBy(record => record.playerFinishTime).Select((value, index) => new { index, value }))
        {
            GameObject recordPrefabInScene = Instantiate(tableRecord, tableTransform);

            GameObject placeRecordPrefabInScene = Instantiate(placeRecordValueText, recordPrefabInScene.transform);
            placeRecordPrefabInScene.GetComponent<TextMeshProUGUI>().text = $"{record.index + 1}";

            GameObject playerTextPrefabInScene = Instantiate(playerRecordValueText, recordPrefabInScene.transform);
            playerTextPrefabInScene.GetComponent<TextMeshProUGUI>().text = $"{record.value.playerId}";

            GameObject timeTextPrefabInScene = Instantiate(timeRecordValueText, recordPrefabInScene.transform);
            timeTextPrefabInScene.GetComponent<TextMeshProUGUI>().text = $"{record.value.playerFinishTime} секунд";
        }
       
    }

    public void ClearOldDataFromTable()
    {
        foreach (Transform row in tableTransform)
        {
            Destroy(row.gameObject);
        }
    }
}
