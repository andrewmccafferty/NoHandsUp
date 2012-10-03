using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xerxes.NoHandsUp.UI.Messages
{
    public class PupilSelected
    {
        public int PupilId { get; private set; }

        public PupilSelected(int pupilId)
        {
            this.PupilId = pupilId;
        }
    }
}
