using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class ResultsState : State
{
    internal ResultsState()
    {
        ShowResultsCommand command = new ShowResultsCommand();
        command.Execute();
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        
    }
}

