using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class MenuState : State
{
    internal MenuState()
    {
        ShowResultsCommand command = new ShowResultsCommand();
        Action postLoad = () =>
        {
            ResultsUIController.instance.UpdateResults(PlayerStatuses.NotPlayingNow);
        };
        command.Execute(postLoad);
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {

    }
}

