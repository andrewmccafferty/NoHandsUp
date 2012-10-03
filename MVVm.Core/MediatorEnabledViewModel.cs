using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVm.Core
{
    public class MediatorEnabledViewModel<T>:WorkspaceViewModel
    {
        public Mediator<T> Mediator
        {
            get
            {
                return Mediator<T>.Instance;
            }
        }
    }
}
