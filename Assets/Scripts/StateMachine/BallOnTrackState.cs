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
        GameManager.instance.StartRace();
        //if (GameManager.instance != null)
        //{
        //    GameManager.instance.ResumeRace();
        //}
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        switch (eventItem)
        {
            case Events.BallВeganToMove:
                stateMachine.State = new RaceHasBegunState();
                break;
            default:
                break;
        }
    }
}
