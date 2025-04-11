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
using testWPF.ViewModels;

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
            DataContext = new ConfirmationViewModel(() => NavigationService?.Navigate(new FinalPage()));
            _digitBoxes = new List<TextBox> { DigitBox1, DigitBox2, DigitBox3 };
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
    }
}
