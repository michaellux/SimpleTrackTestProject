using System.Collections;
using System.Collections.Generic;

public class StateMachine
{
    internal State State { get; set; }

    public StateMachine()
    {
        State = new BallOnTrackState();
    }

    public void FindOut(Events eventItem)
    {
        State.HandleButton(this, eventItem);
    }
}
