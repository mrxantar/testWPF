using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Threading;
using System.Windows.Input;
using testWPF.Helpers;

namespace testWPF.ViewModels
{
    public partial class FinalPageViewModel : ObservableObject
    {
        private readonly DispatcherTimer _timer;
        private readonly Action navigateToMainPage;

        public FinalPageViewModel(Action navigateToMainPage)
        {
            this.navigateToMainPage = navigateToMainPage;

            OpenIWTPdfCommand = new RelayCommand(() => PdfHelper.IWTOpenPdf());
            OpenREDPdfCommand = new RelayCommand(() => PdfHelper.REDOpenPdf());

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(20)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            navigateToMainPage?.Invoke();
        }

        public ICommand OpenIWTPdfCommand { get; }
        public ICommand OpenREDPdfCommand { get; }
    }
}