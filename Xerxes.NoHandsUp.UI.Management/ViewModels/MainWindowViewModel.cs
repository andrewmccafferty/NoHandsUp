using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xerxes.NoHandsUp.Model;
using Xerxes.NoHandsUp.DataAccess;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;
using Xerxes.NoHandsUp.Common;
using Microsoft.Win32;

namespace Xerxes.NoHandsUp.UI.Management.ViewModels
{
    public class MainWindowViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        private DataProvider provider = new DataProvider();

        private ClassList classList;

        private ClassList originalClassList;
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
            }
        }

        public ClassList ClassList
        {
            get
            {
                if (this.classList == null)
                {
                    this.classList = this.provider.GetClassListObject();
                    this.originalClassList = new ClassList(this.classList);
                }

                return this.classList;
            }
        }

        public bool ChangesMade
        {
            get
            {
                return !this.ClassList.Equals(this.originalClassList);
            }
        }

        private string saveErrorMessage;

        public string SaveErrorMessage
        {
            get
            {
                return this.saveErrorMessage;
            }
            set
            {
                this.saveErrorMessage = value;
                this.RaisePropertyChanged("SaveErrorMessage");
            }
        }

        public ICommand SaveClasses
        {
            get
            {
                return new RelayCommand(
                        () => 
                        {
                            this.SaveErrorMessage = null;
                            if (!this.ClassList.IsValid)
                            {
                                MessageBox.Show("Please correct the errors shown, and then try to save again");
                            }
                            else
                            {
                                provider.SaveClasses(this.ClassList);
                                this.originalClassList = new ClassList(this.classList);
                            }
                        },
                        () =>
                        {
                            return this.ChangesMade;
                        }
                    );
            }
        }

        public ICommand OpenFolder
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        Process.Start(FilePaths.DataFolder);
                    });
            }
        }

        public ICommand ChangePupilAvatar
        {
            get
            {
                return new RelayCommand<Pupil>(p =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    bool? result = openFileDialog.ShowDialog();
                    if (result.HasValue && result.Value)
                    {
                        string filePath = openFileDialog.FileName;
                        string fileName = Path.GetFileName(filePath);
                        File.Copy(filePath, Path.Combine(FilePaths.AvatarsFolder, fileName), true);
                        p.AvatarKey = fileName;
                        p.Notify("AvatarKey");
                    }
                    
                });
            }
        }
        private ICommand deletePupilAvatar;

        public ICommand DeletePupilAvatar
        {
            get
            {
                if (this.deletePupilAvatar == null)
                {
                    this.deletePupilAvatar = new RelayCommand<Pupil>(p =>
                    {
                        p.AvatarKey = null;
                        p.Notify("AvatarKey");
                    });
                }

                return this.deletePupilAvatar;
            }
        }

        private ICommand removeClass;
        public ICommand RemoveClass
        {
            get
            {
                if (this.removeClass == null)
                {
                    this.removeClass = new RelayCommand<Class>(
                        c =>
                        {
                            if (MessageBoxResult.Yes == MessageBox.Show(string.Format("Are you sure you wish to remove the class \"{0}\"?", c.Name), "Remove class", MessageBoxButton.YesNo, MessageBoxImage.Question))
                            {
                                this.ClassList.Classes.Remove(c);
                            }
                            
                        }
                        );
                }

                return this.removeClass;
            }
        }

        private ICommand addClass;

        
        public ICommand AddClass
        {
            get
            {
                if (this.addClass == null)
                {
                    this.addClass = new RelayCommand(() =>
                        {
                            Class newClass = new Class() { HasFocus = true };
                            for (int i = 1; i <= this.PupilCountForNewClass; i++)
                            {
                                newClass.Pupils.Add(new Pupil());
                            }
                            
                            this.ClassList.Classes.Add(newClass);
                            this.CurrentClass = newClass;
                        });
                }

                return this.addClass;
            }
        }

        private int pupilCountForNewClass;
        public int PupilCountForNewClass
        {
            get
            {
                if (this.pupilCountForNewClass == 0)
                {
                    this.pupilCountForNewClass = 1;
                }

                return this.pupilCountForNewClass;
            }
            set
            {
                this.pupilCountForNewClass = value;
                this.RaisePropertyChanged("PupilCountForNewClass");
            }
        }

        private ICommand addPupilToClass;

        public ICommand AddPupilToClass
        {
            get
            {
                if (this.addPupilToClass == null)
                {
                    this.addPupilToClass = new RelayCommand<Class>(c =>
                        {
                            if (c != null)
                            {
                                Pupil newPupil = new Pupil() { HasFocus = true, Parent = c };
                                c.Pupils.Add(newPupil);
                                c.Notify("Pupils");
                                c.Notify("PupilCountDescription");
                                c.IsExpanded = true;
                            }
                        },
                        c => c != null);
                }

                return this.addPupilToClass;
            }
            
        }

        private ICommand deletePupilCommand;

        public ICommand DeletePupilCommand
        {
            get
            {
                if (this.deletePupilCommand == null)
                {
                    this.deletePupilCommand = new RelayCommand<Pupil>(this.DeletePupil);
                }

                return this.deletePupilCommand;
            }
        }

        private void DeletePupil(Pupil pupil)
        {
            pupil.Parent.Pupils.Remove(pupil);
        }
    }
}
