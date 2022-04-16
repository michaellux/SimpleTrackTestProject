using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class RaceHasBegunState : State
{
    internal RaceHasBegunState()
    {
        GameManager.instance.StartRace();
    }
    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        switch (eventItem)
        {
            case Events.FallingOffTheTrack:
                {
                    GameManager.instance.StopRace();
                    stateMachine.State = new ResultsState(PlayerStatuses.Lose);
                    break;
                }
            case Events.CrossFinishLine:
                {
                    GameManager.instance.StopRace();
                    stateMachine.State = new ResultsState(PlayerStatuses.Win);
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
