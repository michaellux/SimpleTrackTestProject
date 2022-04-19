using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class MenuState : State
{
    internal MenuState()
    {
        Debug.Log("MenuState");
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        switch (eventItem)
        {
            case Events.PlayButtonPressed:
                {
                    LaunchGameTrackCommand command = new LaunchGameTrackCommand();
                    Action postLoad = () =>
                    {
                        stateMachine.State = new BallOnTrackState();
                    };
                    command.Execute(postLoad, "MainScreen", true);
                    break;
                }
            case Events.ResultsButtonPressed:
                {
                    ShowResultsCommand command = new ShowResultsCommand();
                    Action postLoad = () =>
                    {
                        stateMachine.State = new ResultsState(PlayerStatuses.NotPlayingNow);
                    };
                    command.Execute(postLoad, "MainScreen", true);
                    break;
                }
            default:
                break;
        }
    }
}

