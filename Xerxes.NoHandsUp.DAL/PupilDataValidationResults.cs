using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xerxes.NoHandsUp.Model
{
    public class PupilDataValidationResults
    {
        public IEnumerable<string> Errors { get; private set; }

        public bool IsValid { get; private set; }

        public PupilDataValidationResults(bool isValid, IEnumerable<string> errors)
        {
            this.IsValid = isValid;
            this.Errors = errors;
        }
    }
}
