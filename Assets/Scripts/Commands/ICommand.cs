﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface ICommand
{
    void Execute(Action postLoad, string oldSceneName, bool isAsync);
}
