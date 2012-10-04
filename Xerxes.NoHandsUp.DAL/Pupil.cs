using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Xerxes.NoHandsUp.Model
{
    [Serializable]
    public class Pupil : DataObject
    {
        [XmlAttribute(AttributeName = "firstName")]
        public string FirstName
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "lastName")]
        public string LastName { get; set; }

        [XmlAttribute(AttributeName = "level")]
        public ushort Level { get; set; }

        [XmlAttribute(AttributeName = "avatarKey")]
        public string AvatarKey
        {
            get;
            set;
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
                this.Notify("HasFocus");
            }
        }

        public Pupil()
        {
        }

        public Pupil(Pupil pupil)
        {
            this.FirstName = pupil.FirstName;
            this.LastName = pupil.LastName;
            this.Level = pupil.Level;
            this.AvatarKey = pupil.AvatarKey;
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        public override bool Equals(object obj)
        {
            bool result = true;
            Pupil pupil = obj as Pupil;
            if (pupil != null)
            {
                result = this.FirstName == pupil.FirstName &&
                        this.LastName == pupil.LastName &&
                        this.Level == pupil.Level &&
                        this.AvatarKey == pupil.AvatarKey;
            }

            return result;
        }

        [XmlIgnore]
        public Class Parent
        {
            get;
            set;
        }

        public override string this[string columnName]
        {
            get 
            {
                string result = null;
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(this.FirstName))
                    {
                        result = ValidationResourceKeys.NoPupilFirstName;
                    }
                }
                else if (columnName == "LastName")
                {
                    if (string.IsNullOrEmpty(this.LastName))
                    {
                        result = ValidationResourceKeys.NoPupilLastName;
                    }
                }
                else if (columnName == "Level")
                {
                    if (this.Level > 5)
                    {
                        result = ValidationResourceKeys.InvalidLevel;
                    }
                }
                return result;
            }
        }
    }
}
