using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Xerxes.NoHandsUp.Model
{
    [Serializable]
    public class ClassList : DataObject
    {
        [XmlArray]
        public ObservableCollection<Class> Classes
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            bool result = true;
            ClassList list = obj as ClassList;
            if (list != null)
            {
                if (list.Classes.Count != this.Classes.Count)
                {
                    result = false;
                }
                else
                {
                    foreach (Class c in this.Classes)
                    {
                        result &= list.Classes.Any(cl => cl.Equals(c));
                    }
                }
            }

            return result;
        }

        public ClassList()
        {
            this.Classes = new ObservableCollection<Class>();
        }

        public ClassList(ClassList list)
        {
            this.Classes = new ObservableCollection<Class>();
            foreach (Class cl in list.Classes)
            {
                this.Classes.Add(new Class(cl));
            }

        }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                foreach (Class cl in this.Classes)
                {
                    if (!cl.IsValid)
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
