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
using Xerxes.NoHandsUp.UI.Management.ViewModels;
using Xerxes.NoHandsUp.Model;

namespace Xerxes.NoHandsUp.UI.Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainWindowViewModel;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (this.ViewModel != null && this.ViewModel.ChangesMade)
            {
                if (MessageBoxResult.Yes == 
                        MessageBox.Show("Changes have been made, would you like to save them?", 
                                        "Save changes?", 
                                        MessageBoxButton.YesNo, 
                                        MessageBoxImage.Question))
                {
                    if (this.ViewModel.ClassList.IsValid)
                    {
                        this.ViewModel.SaveClasses.Execute(null);
                    }
                    else
                    {
                        if (MessageBoxResult.OK == MessageBox.Show("There are some errors meaning your changes cannot be saved. Either correct these errors and save again, or click Cancel to discard your changes",
                            "Correct errors?",
                            MessageBoxButton.OKCancel,
                            MessageBoxImage.Question))
                        {
                            e.Cancel = true;
                        }
                    }
                }

            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OnCloseButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void IntegerUpDown_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
            base.OnPreviewTextInput(e);
        }


        private bool AreAllValidNumericChars(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsNumber(c)) return false;
            }

            return true;
        }

        private void listOfClasses_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Class currentClass = e.NewValue as Class;
            if (this.ViewModel != null)
            {
                this.ViewModel.CurrentClass = currentClass;
            }
        }

        private void txtClassName_GotFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = e.OriginalSource as FrameworkElement;
            if (element.DataContext != null)
            {
                Class currentClass = null;
                if (element.DataContext is Class)
                {
                    currentClass = element.DataContext as Class;
                }
                else if (element.DataContext is Pupil)
                {
                    Pupil pupil = (Pupil)element.DataContext;
                    currentClass = pupil.Parent;
                }

                if (this.ViewModel != null && currentClass != null)
                {
                    this.ViewModel.CurrentClass = currentClass;
                }
            }
            
        }
    }
}
