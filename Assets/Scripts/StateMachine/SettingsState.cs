using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SettingsState : State
{
    internal SettingsState()
    {
        SettingsUIController.instance.gameObject.SetActive(true);
    }

    protected override void ChangeState(StateMachine stateMachine, Events eventItem)
    {
        switch (eventItem)
        {
            case Events.EscapeButtonPressed:
                {
                    GoToMenuCommand command = new GoToMenuCommand();
                    Action postLoad = () => {
                        SettingsUIController.instance.gameObject.SetActive(false);
                        stateMachine.State = new MenuState();
                    };
                    command.Execute(postLoad, "SettingsScreen", true);
                }
                break;
            default:
                break;
        }
    }
}
