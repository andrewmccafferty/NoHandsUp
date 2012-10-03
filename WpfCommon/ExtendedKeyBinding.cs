using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Xerxes.WpfCommon
{
    public class ExtendedKeyBinding
    {

        public static ICommand GetBindableCommand(DependencyObject obj)
        {

            return (ICommand)obj.GetValue(ExtendedKeyBinding.BindableCommandProperty);

        }

        public static void SetBindableCommand(DependencyObject obj, ICommand value)
        {

            obj.SetValue(ExtendedKeyBinding.BindableCommandProperty, value);

        }

        public static DependencyProperty BindableCommandProperty = DependencyProperty.RegisterAttached("BindableCommand",

        typeof(ICommand),

        typeof(ExtendedKeyBinding),

        new PropertyMetadata(null, new PropertyChangedCallback(OnBindableCommandChanged)));

        private static void OnBindableCommandChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {

            InputBinding ib = depObj as InputBinding; // BREAK POINT

            ib.Command = (ICommand)e.NewValue;

        }
    }
}
