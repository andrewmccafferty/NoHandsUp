using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xerxes.WPFCustomControls
{
    public class ErrorDialogViewModel
    {
        private Exception ex;

        public string Error 
        {
            get
            {
                return ex.ToString();
            }

        }

        public ErrorDialogViewModel(Exception ex)
        {
            this.ex = ex;
        }
    }
}
