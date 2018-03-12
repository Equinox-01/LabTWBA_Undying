using System.Windows;
using System.Windows.Controls;

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
            Result_Label.Content = "";
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

        private void ClearAllFields_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите очистить все поля ?", "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                A_TextBox.Text = B_TextBox.Text = C_TextBox.Text = "";
        }

        private void Accept_Button_Click(object sender, RoutedEventArgs e)
        {
            double a_side = double.Parse(A_TextBox.Text);
            double b_side = double.Parse(B_TextBox.Text);
            double c_side = double.Parse(C_TextBox.Text);
            string result = GetTriangleType(a_side, b_side, c_side);
            Result_Label.Content = result;
        }

        private string GetTriangleType(double a_side, double b_side, double c_side)
        {
            string result = "";
            if ((a_side == b_side) && (c_side == b_side))
                result = "Треугольник равносторонний";
            else
                result = "Треугольник неравносторонний";
            if ((a_side == b_side) || (a_side == c_side) || (b_side == c_side))
                result = "Треугольник равнобедренный";
            return result;
        }
    }
}
