using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GoToSettingsCommand : Command
{
    public override void Execute(Action postLoad, string oldSceneName, bool isAsync)
    {
        ScenesController.instance.LoadSettingsScreenScene(postLoad, oldSceneName, isAsync);
    }
}
