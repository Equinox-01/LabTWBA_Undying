using System;
using System.Windows;
using System.Windows.Controls;

namespace Undying
{
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
            MessageBox.Show("Введите в поля длину сторон треугольника.\nДопустимый промежуток (0; 1,7 × 10^308].", "Помощь", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void A_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            A_TextBox.Text = Helper.Correct_Data_Double(A_TextBox.Text);
            A_TextBox.SelectionStart = A_TextBox.Text.Length;
            CheckTextBoxState();
        }

        private void B_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            B_TextBox.Text = Helper.Correct_Data_Double(B_TextBox.Text);
            B_TextBox.SelectionStart = B_TextBox.Text.Length;
            CheckTextBoxState();
        }

        private void C_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            C_TextBox.Text = Helper.Correct_Data_Double(C_TextBox.Text);
            C_TextBox.SelectionStart = C_TextBox.Text.Length;
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
            string result = "";
            try
            {
                double a_side = double.Parse(A_TextBox.Text);
                double b_side = double.Parse(B_TextBox.Text);
                double c_side = double.Parse(C_TextBox.Text);
                if ((a_side <= 0) || (b_side <= 0) || (c_side <= 0))
                    throw new ArgumentException();
                result = GetTriangleType(a_side, b_side, c_side);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Введённое число меньше либо равно нулю. \nДопустимый промежуток (0; 1,7 × 10^308].", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Введённое число слишком большое. \nДопустимый промежуток (0; 1,7 × 10^308].", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Необходимо ввести число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Result_Label.Content = result;
        }

        private string GetTriangleType(double a_side, double b_side, double c_side)
        {
            string result = "";
            if ((a_side == b_side) && (c_side == b_side))
                result = "Треугольник равносторонний.";
            else
            {
                result = "Треугольник неравносторонний.";
                if ((a_side == b_side) || (a_side == c_side) || (b_side == c_side))
                    result = "Треугольник равнобедренный.";
            }
            return result;
        }

        private void A_TextBox_PreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            Helper.LeaveControl(sender as TextBox);
        }

        private void B_TextBox_PreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            Helper.LeaveControl(sender as TextBox);
        }

        private void C_TextBox_PreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            Helper.LeaveControl(sender as TextBox);
        }
    }
}
