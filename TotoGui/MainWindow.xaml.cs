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

namespace TotoGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<char> CorrectCharacters = new List<char>()
        {
            '1', '2', 'X'
        };

        public MainWindow()
        {
            InitializeComponent();
            SetDefaults();
        }

        private void SetDefaults()
        {
            InputBox.Text = "12X12X12X12X12";
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = InputBox.Text;

            IncorrectCountBox.IsChecked = value.Length < 14;
            IncorrectCountBox.Content = $"Nem megfelelő a karakterek száma ({value.Length})";

            var incorrectCharacters = value.Where(it => !CorrectCharacters.Contains(it)).ToList();
            IncorrectCharacterBox.IsChecked = incorrectCharacters.Count > 0;
            IncorrectCharacterBox.Content = $"Helytelen karakter az eredményekben ({string.Join(";", incorrectCharacters)})";

            SaveButton.IsEnabled = !((bool)IncorrectCharacterBox.IsChecked || (bool)IncorrectCountBox.IsChecked);

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Don't have to do anything
        }
    }
}
