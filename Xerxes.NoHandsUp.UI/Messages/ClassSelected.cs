using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xerxes.NoHandsUp.Model;

namespace Xerxes.NoHandsUp.UI.Messages
{
    public class ClassSelected
    {
        public Class SelectedClass { get; private set; }

        public ClassSelected(Class selectedClass)
        {
            this.SelectedClass = selectedClass;
        }
    }
}
