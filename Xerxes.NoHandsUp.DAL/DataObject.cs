using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace Xerxes.NoHandsUp.Model
{
    public abstract class DataObject : INotifyPropertyChanged, IDataErrorInfo
    {
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Error
        {
            get 
            {
                return null;
            }
        }


        public virtual string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        public virtual bool IsValid
        {
            get
            {
                bool isValid = true;
                PropertyInfo[] properties = this.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (this[property.Name] != null)
                    {
                        isValid = false;
                        break;
                    }
                }

                return isValid;
            }
        }
        
    }
}
