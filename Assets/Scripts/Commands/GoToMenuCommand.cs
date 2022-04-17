using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GoToMenuCommand : Command
{
    public override void Execute(Action postLoad, string oldSceneName, bool isAsync)
    {
        ScenesController.instance.LoadMainScreenScene(postLoad, oldSceneName, isAsync);
    }
}
