﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace _2374___InplaceCheckEditTemplate {
    public class PersonsViewModel {
        ObservableCollection<Person> persons;
        
        public PersonsViewModel() {
            List<string> Names = new List<string> { "Alex", "Effy", "Alice", "Tony", "Den", "John", "Donald", "Brian", "Andrew", "Lisa", "Matthew" };
            persons = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++) {
                persons.Add(new Person(Names[i], "Last name " + i, i % 3 == 0, i + 21, 170 + i, 75 + i));
            }
        }

        public ObservableCollection<Person> Persons {
            get {
                return persons;
            }
        }
    }

    public class Person : INotifyPropertyChanged, IDataErrorInfo {
        const string lastNamePropertyName = "LastName";
        const string firstNamePropertyName = "FirstName";
        const string isMarriedPropertyName = "IsMarried";
        const string agePropertyName = "Age";
        const string heightPropertyName = "Height";
        const string weightPtropertyName = "Weight";

        string firstName;
        string lastName;
        bool isMarried;
        int age;
        int height;
        int weight;
        PersonPropertiesValidator Validator = new PersonPropertiesValidator();

        public Person(string firstName, string lastName, bool isMarried, int age, int height, int weight) {
            FirstName = firstName;
            LastName = lastName;
            IsMarried = isMarried;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public string FirstName {
            get {
                return firstName;
            }
            set {
                Validator.IsNameValid(value, firstNamePropertyName);
                firstName = value;
                RaisePropertyChanged(firstNamePropertyName);
            }
        }

        public string LastName {
            get {
                return lastName;
            }
            set {
                Validator.IsNameValid(value, lastNamePropertyName);
                lastName = value;
                RaisePropertyChanged(lastNamePropertyName);
            }
        }

        public bool IsMarried {
            get {
                return isMarried;
            }
            set {
                isMarried = value;
                RaisePropertyChanged(isMarriedPropertyName);
            }
        }

        public int Age {
            get {
                return age;
            }
            set {
                Validator.IsAgeValid(value, agePropertyName);
                age = value;
                RaisePropertyChanged(agePropertyName);
            }
        }

        public int Height {
            get {
                return height;
            }
            set {
                height = value;
                RaisePropertyChanged(heightPropertyName);
            }
        }

        public int Weight {
            get {
                return weight;
            }
            set {
                weight = value;
                RaisePropertyChanged(weightPtropertyName);
            }
        }

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IDataErrorInfo members
        public string Error {
            get {
                return Validator.DataError;
            }
        }

        public string this[string columnName] {
            get {
                if (Validator.DataErrors.ContainsKey(columnName))
                    return Validator.DataErrors[columnName];
                else
                    return null;
            }
        }
        #endregion
    }

    public class PersonPropertiesValidator {
        string dataError = "";
        Dictionary<string, string> dataErrors = new Dictionary<string, string>();

        public bool IsNameValid(string value, string propertyName) {
            if (string.IsNullOrEmpty(value)) {
                dataErrors[propertyName] = "Full name is required.";
                return false;
            } else {
                ClearPropertyErrors(propertyName);
                return true;
            }
        }

        public bool IsAgeValid(int value, string propertyName) {
            if (value <= 0) {
                dataErrors[propertyName] = "Age validation failed.";
                return false;
            } else {
                ClearPropertyErrors(propertyName);
                return true;
            }
        }

        public string DataError {
            get {
                return dataError;
            }
        }

        public Dictionary<string, string> DataErrors {
            get {
                return dataErrors;
            }
        }

        void ClearPropertyErrors(string propertyName) {
            if (dataErrors.ContainsKey(propertyName))
                dataErrors.Remove(propertyName);
        }
    }
}
