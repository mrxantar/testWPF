using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using testWPF.Helpers;
using CommunityToolkit.Mvvm.Input;


namespace testWPF.ViewModels
{
    public class FormViewModel : INotifyPropertyChanged
    {
        private readonly Action navigateToConfirmation;

        public FormViewModel(Action navigateToConfirmation)
        {
            this.navigateToConfirmation = navigateToConfirmation;
            ConfirmCommand = new RelayCommand(Confirm);
            OpenIWTPdfCommand = new RelayCommand(() => PdfHelper.IWTOpenPdf());
            OpenREDPdfCommand = new RelayCommand(() => PdfHelper.REDOpenPdf());
        }

        private Brush _nameBorder = Brushes.Transparent;
        private Brush _numberBorder = Brushes.Transparent;
        private Brush _emailBorder = Brushes.Transparent;

        public Brush NameBorder
        {
            get => _nameBorder;
            set { _nameBorder = value; OnPropertyChanged(); }
        }

        public Brush NumberBorder
        {
            get => _numberBorder;
            set { _numberBorder = value; OnPropertyChanged(); }
        }

        public Brush EmailBorder
        {
            get => _emailBorder;
            set { _emailBorder = value; OnPropertyChanged(); }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (Regex.IsMatch(value, @"^[а-яА-ЯёЁ\s]*$"))
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _number;
        public string Number
        {
            get => _number;
            set
            {
                if (Regex.IsMatch(value, @"^[0-9]*$"))
                {
                    _number = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private Visibility _errorVisibility = Visibility.Collapsed;
        public Visibility ErrorVisibility
        {
            get => _errorVisibility;
            set
            {
                _errorVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmCommand { get; }
        public ICommand OpenIWTPdfCommand { get; }
        public ICommand OpenREDPdfCommand { get; }

        private void Confirm()
        {
            bool nameValid = !string.IsNullOrWhiteSpace(Name);
            bool numberValid = !string.IsNullOrWhiteSpace(Number);
            bool emailValid = Regex.IsMatch(Email ?? "", @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            NameBorder = nameValid ? Brushes.Transparent : Brushes.Red;
            NumberBorder = numberValid ? Brushes.Transparent : Brushes.Red;
            EmailBorder = emailValid ? Brushes.Transparent : Brushes.Red;

            ErrorVisibility = nameValid && numberValid && emailValid ? Visibility.Collapsed : Visibility.Visible;

            if (ErrorVisibility == Visibility.Collapsed)
                navigateToConfirmation?.Invoke();
            else
                ErrorVisibility = Visibility.Visible;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}