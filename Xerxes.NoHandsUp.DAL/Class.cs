using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Xerxes.NoHandsUp.Model
{
    /// <summary>
    /// Represents a class of pupils
    /// </summary>
    [Serializable]
    public class Class : DataObject
    {

        private string name;

        [XmlAttribute(AttributeName = "Name")]
        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.Notify("Name");
            }
        }

        private bool hasFocus;

        [XmlIgnore]
        public bool HasFocus
        {
            get
            {
                return this.hasFocus;
            }
            set
            {
                this.hasFocus = value;
                if (value)
                {
                    this.IsExpanded = true;
                }
                this.Notify("HasFocus");
            }
        }

        private ObservableCollection<Pupil> pupils;

        [XmlArray(ElementName = "Pupils")]
        public ObservableCollection<Pupil> Pupils 
        {
            get
            {
                if (this.pupils == null)
                {
                    this.pupils = new ObservableCollection<Pupil>();
                }

                foreach (Pupil pupil in this.pupils)
                {
                    pupil.Parent = this;
                }

                return this.pupils;
            }
             
        }

        private bool isExpanded;

        [XmlIgnore]
        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }
            set
            {
                this.isExpanded = value;
                this.Notify("IsExpanded");
            }
        }

        [XmlIgnore]
        public string PupilCountDescription
        {
            get
            {
                return string.Format("({0} pupils)", this.Pupils.Count);
            }
        }
        public Class()
        {
        }

        public Class(Class cl)
        {
            this.Name = cl.Name;
            this.Pupils.Clear();
            foreach (Pupil p in cl.Pupils)
            {
                this.Pupils.Add(new Pupil(p));
            }
        }

        
        public Pupil GetRandomPupil(ushort level, Pupil currentlySelected)
        {
            Pupil result = null;
            if (level == 0)
            {
                result = this.Pupils.Where(p => currentlySelected == null || !p.Equals(currentlySelected)).NextRandom();
            }
            else
            {
                var potentials = this.Pupils.Where(p => (currentlySelected == null || !p.Equals(currentlySelected)) && p.Level == level);
                if (potentials.Count() == 0)
                {
                    result = null;
                }
                else
                {
                    result = potentials.NextRandom();
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            Class c = obj as Class;
            if (c != null)
            {
                result = this.Name == c.Name;
                if (this.Pupils.Count != c.Pupils.Count)
                {
                    result = false;
                }
                else
                {
                    foreach (Pupil p in this.Pupils)
                    {
                        result &= c.Pupils.Any(pl => pl.Equals(p));
                    }
                }
            }

            return result;
        }

        public override string this[string columnName]
        {
            get 
            {
                string result = null;
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        result = ValidationResourceKeys.NoClassName;
                    }
                }

                return result;
            }
        }

        public override bool IsValid
        {
            get
            {
                bool isValid = true;
                if (!base.IsValid)
                {
                    isValid = false;
                }
                else
                {
                    
                    foreach (Pupil pupil in this.Pupils)
                    {
                        if (!pupil.IsValid)
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                return isValid;
            }
        }
    }
}
