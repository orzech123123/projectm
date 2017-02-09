using System;
using Macrix.ViewModels;

namespace Macrix.Entities
{
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
}
