using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using testWPF.ViewModels;

namespace testWPF.Views
{
    public partial class Form : Page
    {
        public Form()
        {
            InitializeComponent();
            DataContext = new FormViewModel(() => NavigationService?.Navigate(new ConfirmationPage()));
        }

        private void NameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[а-яА-ЯёЁ\\s]+$");
        }

        private void NameBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string text = (string)e.DataObject.GetData(DataFormats.Text);
                if (!Regex.IsMatch(text, "^[а-яА-ЯёЁ\\s]+$"))
                    e.CancelCommand();
            }
            else e.CancelCommand();
        }

        private void NumberBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void NumberBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string text = (string)e.DataObject.GetData(DataFormats.Text);
                if (!Regex.IsMatch(text, "^[0-9]+$"))
                    e.CancelCommand();
            }
            else e.CancelCommand();
        }
    }
}