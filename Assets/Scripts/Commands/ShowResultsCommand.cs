using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ShowResultsCommand : Command
{
    public override void Execute(Action postLoad, string oldSceneName, bool isAsync)
    {
        ScenesController.instance.LoadResultsScreenScene(postLoad, oldSceneName, isAsync);
    }
}

