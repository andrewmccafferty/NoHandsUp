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
using Xerxes.NoHandsUp.UI.ViewModels;
using System.Windows.Media.Animation;
using Xerxes.NoHandsUp.UI.Messages;

namespace Xerxes.NoHandsUp.UI
{
    /// <summary>
    /// Interaction logic for PupilSelection.xaml
    /// </summary>
    public partial class PupilSelection : UserControl
    {

        
        public PupilSelection()
        {
            InitializeComponent();
            this.DataContext = new PupilSelectionViewModel();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ClassSelected>(this, this.OnClassChanged);
        }

        private void OnClassChanged(ClassSelected message)
        {
            this.pupilList.Focus();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.pupilList.Focus();
        }
    }
}
