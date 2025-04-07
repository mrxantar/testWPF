using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using testWPF.Helpers;

namespace testWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для Form.xaml
    /// </summary>
    public partial class Form : Page
    {
        public static readonly Regex OnlyCyrillic = new Regex("^[а-яА-ЯёЁ\\s]+$");
        public static readonly Regex OnlyNumbers = new Regex("^[0-9]+$");
        public static readonly Regex EmailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");


        public Form()
        {
            InitializeComponent();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text.Trim();
            string number = NumberBox.Text.Trim();
            string email = EmailBox.Text.Trim();

            bool nameValid = !string.IsNullOrEmpty(name);
            bool numberValid = !string.IsNullOrEmpty(number);
            bool emailValid = EmailRegex.IsMatch(email);

            NameBox.BorderBrush = nameValid ? Brushes.Transparent : Brushes.Red;
            NumberBox.BorderBrush = numberValid ? Brushes.Transparent : Brushes.Red;
            EmailBox.BorderBrush = emailValid ? Brushes.Transparent : Brushes.Red;

            bool isValid = nameValid && numberValid && emailValid;

            if (isValid)
            {
                ErrorMessage.Visibility = Visibility.Collapsed;
                NavigationService?.Navigate(new ConfirmationPage());
            }
            else
            {
                ErrorMessage.Text = "Проверьте правильность полей.";
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }


        private void HandlePreviewTextInput(object sender, TextCompositionEventArgs e, Regex pattern)
        {
            e.Handled = !pattern.IsMatch(e.Text);
        }

        private void HandlePasting(object sender, DataObjectPastingEventArgs e, Regex pattern)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string text = (string)e.DataObject.GetData(DataFormats.Text);
                if (!pattern.IsMatch(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void NameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            HandlePreviewTextInput(sender, e, OnlyCyrillic);
        }

        private void NameBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            HandlePasting(sender, e, OnlyCyrillic);
        }

        private void NumberBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            HandlePreviewTextInput(sender, e, OnlyNumbers);
        }

        private void NumberBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            HandlePasting(sender, e, OnlyNumbers);
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
