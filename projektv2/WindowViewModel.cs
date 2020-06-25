using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace projektv2
{
    public class WindowViewModel
    {
        public WindowViewModel()
        {
            Model = new RegisterViewModel();
            RegisterCommand = new RegisterCommand();
           
        }

        public RegisterViewModel Model { get; set; }
        public ICommand RegisterCommand { get; set; }
        
        
    }

    

    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Surname"));
                }
            }
        }


        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }
        private bool _agreement;

        public bool Agreement
        {
            get { return _agreement; }
            set
            {
                if (_agreement != value)
                {
                    _agreement = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsHuman"));
                }
            }
        }

        private string _errors;
        public string Errors
        {
            get { return _errors; }
            set
            {
                if (_errors != value)
                {
                    _errors = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Errors"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
