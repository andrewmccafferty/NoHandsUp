using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Xerxes.NoHandsUp.UI.Messages;
using System.Windows.Input;
using Xerxes.NoHandsUp.Model;
using Xerxes.NoHandsUp.DataAccess;

namespace Xerxes.NoHandsUp.UI.ViewModels
{
    public class MainWindowViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private bool newClassSelected;

        private ClassToXmlFileMapping selectedClass;

        public ClassToXmlFileMapping SelectedClass
        {
            get
            {
                return this.selectedClass;
            }
            set
            {
                if (!object.ReferenceEquals(this.selectedClass, value))
                {
                    this.selectedClass = value;
                    this.RaisePropertyChanged("SelectedClass");
                    this.newClassSelected = true;
                }
            }
        }

        public ICommand SelectClass
        {
            get
            {
                return new GalaSoft.MvvmLight.Command.RelayCommand(() =>
                    {
                        if (this.SelectedClass != null)
                        {
                            this.newClassSelected = false;
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new DataFileChanged(this.SelectedClass.FileName));
                        }
                    },
                    () =>
                    {
                        bool canExecute = 
                            this.newClassSelected &&
                            this.SelectedClass != null && 
                            !string.IsNullOrEmpty(this.SelectedClass.FileName);
                        return canExecute;
                    });
            }
        }
    }
}
