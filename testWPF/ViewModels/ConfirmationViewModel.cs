using System.Windows.Input;
using testWPF.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media;
using System.Windows;


namespace testWPF.ViewModels
{
    public partial class ConfirmationViewModel : ObservableObject
    {
        private readonly Action navigateToFinal;

        [ObservableProperty]
        private string digit1;

        [ObservableProperty]
        private string digit2;

        [ObservableProperty]
        private string digit3;

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

        private Brush _digitsBorder = Brushes.Transparent;

        public Brush DigitsBorder
        {
            get => _digitsBorder;
            set { _digitsBorder = value; OnPropertyChanged(); }
        }

        public ICommand ConfirmCodeCommand { get; }
        public ICommand OpenIWTPdfCommand { get; }
        public ICommand OpenREDPdfCommand { get; }

        public ConfirmationViewModel(Action navigateToFinal)
        {
            this.navigateToFinal = navigateToFinal;
            ConfirmCodeCommand = new RelayCommand(ConfirmCode);
            OpenIWTPdfCommand = new RelayCommand(() => PdfHelper.IWTOpenPdf());
            OpenREDPdfCommand = new RelayCommand(() => PdfHelper.REDOpenPdf());
        }

        private void ConfirmCode()
        {
            var code = $"{Digit1}{Digit2}{Digit3}";

            if (code == "000")
            {
                navigateToFinal?.Invoke();
            }
            else
            {
                ErrorVisibility = Visibility.Visible;
                DigitsBorder = Brushes.Red;
            }
        }
    }
}
