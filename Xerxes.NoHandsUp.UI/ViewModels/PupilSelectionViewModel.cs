using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xerxes.NoHandsUp.Model;
using System.Collections.ObjectModel;
using Xerxes.NoHandsUp.DataAccess;
using System.Windows.Input;
using Xerxes.NoHandsUp.UI.Messages;
using System.Diagnostics;
using System.Windows.Threading;

namespace Xerxes.NoHandsUp.UI.ViewModels
{
    public class PupilSelectionViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        public PupilSelectionViewModel()
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ClassSelected>(this, this.OnClassChanged);
        }

        private void OnClassChanged(ClassSelected message)
        {
            this.PupilClass = message.SelectedClass;
        }

        private DataProvider provider;

        private DataProvider Provider
        {
            get
            {
                if (this.provider == null)
                {
                    this.provider = new DataProvider();
                }

                return this.provider;
            }
        }

        private Class pupilClass;
        
        public Class PupilClass
        {
            get
            {
                return pupilClass;
            }
            set
            {
                this.pupilClass = value;
                this.RaisePropertyChanged("PupilClass");
            }
        }

        private Pupil selectedPupil;

        public Pupil SelectedPupil
        {
            get
            {
                return this.selectedPupil;
            }
            set
            {
                if (!object.ReferenceEquals(this.selectedPupil, value))
                {
                    this.selectedPupil = value;
                    this.RaisePropertyChanged("SelectedPupil");
                }
            }
        }

        public ICommand SelectPupil
        {
            get
            {
                return new GalaSoft.MvvmLight.Command.RelayCommand<string>(this.DoSelectPupil);
            }
        }

        public ICommand ResetPupilSelection
        {
            get
            {
                return new GalaSoft.MvvmLight.Command.RelayCommand(
                    () => 
                    {
                        this.SelectedPupil = null;
                    });
            }
        }

        private void DoSelectPupil(string level)
        {
            this.DoSelectPupil(ushort.Parse(level));
        }

        private void DoSelectPupil(ushort level)
        {
            if (this.PupilClass != null)
            {
                this.SelectedPupil = this.PupilClass.GetRandomPupil(level, this.SelectedPupil);
            }
        }
    }
}
