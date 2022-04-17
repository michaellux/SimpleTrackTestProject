using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class RecordsDataModel : MonoBehaviour
{
    private static string recordsSavePath = "Assets/Data/SaveRecordsData.json";
    //[SerializeField] private static RecordsData recordsData = new RecordsData();
    public static void LoadRecords()
    {
        if (File.Exists(recordsSavePath))
        {
            string json = File.ReadAllText(recordsSavePath);
            Debug.Log("Json" + json);
            if (!string.IsNullOrEmpty(json) && json != "[]")
            {
                RecordsData.records = JsonConvert.DeserializeObject<List<Record>>(json);
            }
            else
            {
                RecordsData.records = new List<Record>();
            }
        }
    }

    public static void SaveRecords()
    {
        string json = JsonConvert.SerializeObject(RecordsData.records);
        File.WriteAllText(recordsSavePath, json);
    }

    public static void AddNewRecord(int playerId, int playerResult)
    {
        Record newRecord = new Record(playerId, playerResult);
        RecordsData.records.Add(newRecord);
    }

    public static void SortRecords()
    {
        RecordsData.records.OrderBy(record => record.playerFinishTime);
    }

    [System.Serializable]
    public static class RecordsData
    {
        public static List<Record> records = new List<Record>();
    }

    [System.Serializable]
    public class Record
    {
        public int playerId;
        public int playerFinishTime;

        public Record(int playerId, int playerFinishTime)
        {
            this.playerId = playerId;
            this.playerFinishTime = playerFinishTime;
        }
    }
}



