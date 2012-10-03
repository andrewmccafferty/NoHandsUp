using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xerxes.NoHandsUp.Model
{
    public class PupilEqualityComparer : IEqualityComparer<Pupil>
    {
        public bool Equals(Pupil x, Pupil y)
        {
            bool equals = x.FirstName == y.FirstName && x.LastName == y.LastName;
            return equals;
        }

        public int GetHashCode(Pupil obj)
        {
            return obj.GetHashCode();
        }
    }
}
