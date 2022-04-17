using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LaunchGameTrackCommand : Command
{
    public override void Execute(Action postLoad, string oldSceneName, bool isAsync)
    {
        ScenesController.instance.LoadGameTrackScene(postLoad, oldSceneName, isAsync);
    }
}
