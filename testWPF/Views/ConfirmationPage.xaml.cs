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
using testWPF.Helpers;

namespace testWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationPage.xaml
    /// </summary>
    public partial class ConfirmationPage : Page
    {
        private List<TextBox> _digitBoxes;

        public ConfirmationPage()
        {
            InitializeComponent();
            _digitBoxes = new List<TextBox> { DigitBox1, DigitBox2, DigitBox3 };
        }

        private void ConfirmCode(object sender, RoutedEventArgs e)
        {
            string code = $"{DigitBox1.Text}{DigitBox2.Text}{DigitBox3.Text}";

            if (code == "000")
            {
                ErrorMessage.Visibility = Visibility.Collapsed;
                NavigationService?.Navigate(new FinalPage());
            }
            else
            {
                ErrorMessage.Text = "Неверный код.";
                ErrorMessage.Visibility = Visibility.Visible;
                HighlightCodeBoxes();
            }
        }

        private void HighlightCodeBoxes()
        {
            var borderBrush = new SolidColorBrush(Colors.Red);
            DigitBox1.BorderBrush = borderBrush;
            DigitBox2.BorderBrush = borderBrush;
            DigitBox3.BorderBrush = borderBrush;
        }

        private void DigitBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox currentBox && currentBox.Text.Length == 1)
            {
                int index = _digitBoxes.IndexOf(currentBox);
                if (index < _digitBoxes.Count - 1)
                {
                    _digitBoxes[index + 1].Focus();
                }
            }
        }

        private void DigitBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox currentBox && e.Key == Key.Back && string.IsNullOrEmpty(currentBox.Text))
            {
                int index = _digitBoxes.IndexOf(currentBox);
                if (index > 0)
                {
                    _digitBoxes[index - 1].Focus();
                }
            }
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
