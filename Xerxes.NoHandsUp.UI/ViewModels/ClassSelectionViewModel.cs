using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xerxes.NoHandsUp.Model;
using Xerxes.NoHandsUp.DataAccess;
using System.Windows.Input;
using Xerxes.NoHandsUp.UI.Messages;
using GalaSoft.MvvmLight.Command;


namespace Xerxes.NoHandsUp.UI.ViewModels
{
    public enum ClassSelectionMode
    {
        ReadyForSelection,
        SelectionMade
    }

    public class ClassSelectionViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private ClassSelectionMode selectionMode = ClassSelectionMode.ReadyForSelection;

        public ClassSelectionMode SelectionMode
        {
            get
            {
                return this.selectionMode;
            }
            set
            {
                this.selectionMode = value;
                this.RaisePropertyChanged("SelectionMode");
            }
        }

        private DataProvider provider = new DataProvider();

        private IEnumerable<Class> allClasses;

        public IEnumerable<Class> AllClasses
        {
            get
            {
                if (this.allClasses == null)
                {
                    this.allClasses = this.provider.GetAllClasses();
                    if (this.allClasses.Count() == 1)
                    {
                        this.CurrentClass = this.allClasses.First();
                    }
                }

                return this.allClasses;
            }
        }

        private Class currentClass;

        public Class CurrentClass
        {
            get
            {
                return this.currentClass;
            }
            set
            {
                this.currentClass = value;
                this.RaisePropertyChanged("CurrentClass");
                if (this.currentClass != null)
                {
                    this.SelectionMode = ClassSelectionMode.SelectionMade;
                    GalaSoft.MvvmLight.Messaging.Messenger.Default.Send(new ClassSelected(this.currentClass));
                }
            }
        }

        public bool CanChangeClass
        {
            get
            {
                return this.AllClasses.Count() > 1 && this.SelectionMode != ClassSelectionMode.ReadyForSelection;
            }
        }

        public ICommand GoToReadyForSelection
        {
            get
            {
                return new RelayCommand(
                            () => 
                            {
                                this.SelectionMode = ClassSelectionMode.ReadyForSelection;
                            },
                            () =>
                {
                    return this.CanChangeClass;
                });
            }

        }
    }
}
