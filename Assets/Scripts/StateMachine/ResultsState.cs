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
        Debug.Log("ResultsState");
        ResultsUIController.instance.gameObject.SetActive(true);
        ResultsUIController.instance.UpdateResults(status);
        RecordsDataModel.LoadRecords();
        if (status == PlayerStatuses.Win)
        {
            RecordsDataModel.AddNewRecord(Player.instance.gameObject.GetInstanceID(), Player.instance.raceResult);
        }
        RecordsDataModel.SaveRecords();
        ResultsUIController.instance.UpdateTable(RecordsDataModel.RecordsData.records);
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        switch (eventItem)
        {
            case Events.EscapeButtonPressed:
                {
                    GoToMenuCommand command = new GoToMenuCommand();
                    Action postLoad = () => {
                        ResultsUIController.instance.gameObject.SetActive(false);
                        stateMachine.State = new MenuState();
                    };
                    command.Execute(postLoad, "ResultsScreen", true);
                }
                break;
            default:
                break;
        }
    }
}

