using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;

namespace Xerxes.WPFCustomControls
{
    public class TreeViewWithFixedTabNavigation : TreeView
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 && e.Key == Key.Tab)
                return;

            base.OnKeyDown(e);
        }
    }
}
