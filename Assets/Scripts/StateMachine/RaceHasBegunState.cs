using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class RaceHasBegunState : State
{
    internal RaceHasBegunState()
    {
        Debug.Log("RaceHasBegunState");
    }
    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        GameTrackUIController.instance.gameObject.SetActive(false);

        switch (eventItem)
        {
            case Events.FallingOffTheTrack:
            {
                ShowResultsCommand command = new ShowResultsCommand();
                Action postLoad = () =>
                {
                    GameManager.instance.StopRace();
                    stateMachine.State = new ResultsState(PlayerStatuses.Lose);
                };
                command.Execute(postLoad, "GameTrack", true);
                break;
            }
            case Events.CrossFinishLine:
            {
                ShowResultsCommand command = new ShowResultsCommand();
                Action postLoad = () =>
                {
                    GameManager.instance.StopRace();
                    stateMachine.State = new ResultsState(PlayerStatuses.Win);
                };
                command.Execute(postLoad, "GameTrack", true);
                break;
            }
            default:
                break;
        }
    }
}
