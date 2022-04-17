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
        GameManager.instance.StartRace();
    }
    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
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
            case Events.EscapeButtonPressed:
            {
                GoToMenuCommand command = new GoToMenuCommand();
                Action postLoad = () => {
                    GameManager.instance.PauseRace();
                    stateMachine.State = new MenuState();
                };
                command.Execute(postLoad, "GameTrack", false);
                break;
            }
        }
    }
}
