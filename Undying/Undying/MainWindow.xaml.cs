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
            MessageBox.Show("Введите в поля длину сторон треугольника.\nДопустимый промежуток от 1 до 2^16 - 1.", "Помощь", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void A_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            A_TextBox.Text = Helper.Correct_Data_Int(A_TextBox.Text);
            A_TextBox.SelectionStart = A_TextBox.Text.Length;
            CheckTextBoxState();
        }

        private void B_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            B_TextBox.Text = Helper.Correct_Data_Int(B_TextBox.Text);
            B_TextBox.SelectionStart = B_TextBox.Text.Length;
            CheckTextBoxState();
        }

        private void C_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            C_TextBox.Text = Helper.Correct_Data_Int(C_TextBox.Text);
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
                var triangle = new Triangle(A_TextBox.Text, B_TextBox.Text, C_TextBox.Text);
                result = triangle.GetTriangleType();
            }
            catch (ArgumentException error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Введённое число слишком большое. \nДопустимый промежуток  от 1 до 2^16 - 1.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Необходимо ввести число.  Допустимый промежуток от 1; 2^16 - 1.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Result_Label.Content = result;
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
