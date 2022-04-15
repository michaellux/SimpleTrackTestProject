using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class BallOnTrackState : State
{
    internal BallOnTrackState()
    {
           
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        switch (eventItem)
        {
            case Events.FallingOffTheTrack:
            case Events.CrossFinishLine:
            {
                stateMachine.State = new ResultsState();
                break;
            }
            case Events.EscapeButtonPressed:
            {
               stateMachine.State = new MenuState();
               break;
            }
        }
    }
}
