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
    private static string FolderPath
    {
        get
        {
            return string.Format("{0}/{1}",
                Application.persistentDataPath,
                "Data");
        }
    }
    private static string gameFileName = "SaveRecordsData";
    private static string fileExtentionName = ".json";
    private static string recordsSavePath = string.Format("{0}/{1}{2}", FolderPath, gameFileName, fileExtentionName);

    public static void LoadRecords()
    {
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
        }

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
        else
        {
            CreateDataFile();
            RecordsData.records = new List<Record>();
        }
    }

    async public static void SaveRecords()
    {
        using (StreamWriter writer = new StreamWriter(recordsSavePath, false))
        {
            string json = JsonConvert.SerializeObject(RecordsData.records);
            await writer.WriteLineAsync(json);
        }
    }

    public static void AddNewRecord(int playerId, int playerResult)
    {
        Record newRecord = new Record(playerId, playerResult);
        RecordsData.records.Add(newRecord);
    }

    public static void CreateDataFile()
    {
        File.Create(recordsSavePath).Close();
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



