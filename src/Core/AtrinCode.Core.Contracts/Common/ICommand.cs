﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Contracts.Common
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand> where TCommand:ICommand
   {
        void Handle(TCommand command);
    }
}
