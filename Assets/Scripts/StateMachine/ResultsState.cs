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
        };
        command.Execute(postLoad);
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        
    }
}

