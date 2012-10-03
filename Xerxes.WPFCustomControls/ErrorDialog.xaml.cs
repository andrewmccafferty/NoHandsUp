using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xerxes.WPFCustomControls
{
    /// <summary>
    /// Interaction logic for ErrorDialog.xaml
    /// </summary>
    public partial class ErrorDialog : Window
    {
        public ErrorDialog(Exception ex)
        {
            InitializeComponent();
            this.DataContext = new ErrorDialogViewModel(ex);
        }

        public static void ShowError(Exception ex)
        {
            try
            {
                ErrorDialog dialog = new ErrorDialog(ex);
                dialog.ShowDialog();
            }
            catch
            {

            }
        }
    }
}
