using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using testWPF.Helpers;

namespace testWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для FinalPage.xaml
    /// </summary>
    public partial class FinalPage : Page
    {
        private DispatcherTimer _timer;

        public FinalPage()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(20);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            NavigationService?.Navigate(new MainPage());
        }

        private void IWTButton_Click(object sender, RoutedEventArgs e)
        {
            PdfHelper.IWTOpenPdf();
        }

        private void REDButton_Click(object sender, RoutedEventArgs e)
        {
            PdfHelper.REDOpenPdf();
        }
    }
}
