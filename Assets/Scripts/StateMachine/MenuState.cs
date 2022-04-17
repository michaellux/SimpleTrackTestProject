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
        //GoToMenuCommand command = new GoToMenuCommand();
        //Action postLoad = () => { };
        //command.Execute(postLoad);
        //GameManager.instance.PauseRace();
        //GameManager.instance.BackToMainScreen();
        //ShowResultsCommand command = new ShowResultsCommand();
        //Action postLoad = () =>
        //{
        //    ResultsUIController.instance.UpdateResults(PlayerStatuses.NotPlayingNow);
        //};
        //command.Execute(postLoad);
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
                    command.Execute(postLoad, "MenuScreen", false);
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

