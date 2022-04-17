using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
internal class BallOnTrackState : State
{
    internal BallOnTrackState()
    {
        Debug.Log("BallOnTrackState");
        if (GameManager.instance != null)
        {
            GameManager.instance.ResumeRace();
        }
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        switch (eventItem)
        {
            case Events.BallВeganToMove:
                stateMachine.State = new RaceHasBegunState();
                break;
            case Events.EscapeButtonPressed:
                {
                    GoToMenuCommand command = new GoToMenuCommand();
                    Action postLoad = () => {
                        GameManager.instance.PauseRace();
                        stateMachine.State = new MenuState();
                    };
                    command.Execute(postLoad, "GameTrack", false);
                }
                break;
        }
    }
}
