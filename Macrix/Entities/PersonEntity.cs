using System;
using System.Xml.Serialization;
using Macrix.ViewModels;

namespace Macrix.Entities
{
    [Serializable]
    public class PersonEntity : BaseViewModel
    {
        private string firstname;
        private string lastname;
        private string street;
        private string houseNumber;
        private string flatNumber;
        private string postalCode;
        private string phoneNumber;
        private DateTime birthdate;

        [XmlIgnore]
        public bool IsChanged { get; set; }

        public override void OnPropertyChanged(string name)
        {
            IsChanged = true;
            base.OnPropertyChanged(name);
        }

        [XmlElement("Firstname")]
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        [XmlElement("Lastname")]
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        [XmlElement("Street")]
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
                OnPropertyChanged("Street");
            }
        }

        [XmlElement("HouseNumber")]
        public string HouseNumber
        {
            get
            {
                return houseNumber;
            }
            set
            {
                houseNumber = value;
                OnPropertyChanged("HouseNumber");
            }
        }

        [XmlElement("FlatNumber")]
        public string FlatNumber
        {
            get
            {
                return flatNumber;
            }
            set
            {
                flatNumber = value;
                OnPropertyChanged("FlatNumber");
            }
        }

        [XmlElement("PostalCode")]
        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }

        [XmlElement("PhoneNumber")]
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        [XmlElement("Birthdate")]
        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
                OnPropertyChanged("Birthdate");
                OnPropertyChanged("Age");
            }
        }

        [XmlIgnore]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - birthdate.Year;
                if (birthdate > today.AddYears(-age))
                    age--;

                return age;
            }
        }
    }

    [Serializable]
    [XmlRoot("PersonCollection")]
    public class PersonCollection
    {
        [XmlArray("Persons")]
        [XmlArrayItem("PersonEntity", typeof(PersonEntity))]
        public PersonEntity[] Persons { get; set; }

    }
}
