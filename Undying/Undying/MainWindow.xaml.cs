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

namespace Undying
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckTextBoxState()
        {
            Accept_Button.IsEnabled = ((A_TextBox.Text != "") && (B_TextBox.Text != "") && (C_TextBox.Text != ""));
            if ((A_TextBox.Text != "") || (B_TextBox.Text != "") || (C_TextBox.Text != ""))
                ClearAllFields_Button.IsEnabled = true;
            if ((A_TextBox.Text == "") && (B_TextBox.Text == "") && (C_TextBox.Text == ""))
                ClearAllFields_Button.IsEnabled = false;
        }

        private void Help_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Введите в поля длину сторон треугольника.", "Помощь", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void A_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxState();
        }

        private void B_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxState();
        }

        private void C_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBoxState();
        }
    }
}
