using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ShowResultsCommand : Command
{
    public override void Execute()
    {
        MenuController.instance.ShowResultsScreen();
    }
}

