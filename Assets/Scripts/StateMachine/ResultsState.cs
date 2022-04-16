using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class ResultsState : State
{
    internal ResultsState(PlayerStatuses status)
    {
        Debug.Log("ResultState");
        ShowResultsCommand command = new ShowResultsCommand();
        Action postLoad = () =>
        {
            ResultsUIController.instance.UpdateResults(status);
            RecordsDataModel.LoadRecords();
            RecordsDataModel.AddNewRecord(Player.instance.gameObject.GetInstanceID(), Player.instance.raceResult);
            RecordsDataModel.SortRecords();
            RecordsDataModel.SaveRecords();
            ResultsUIController.instance.FillTable(RecordsDataModel.RecordsData.records);
        };
        command.Execute(postLoad);
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        
    }
}

