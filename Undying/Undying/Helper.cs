﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Undying
{
    public static class Helper
    {

        private static StringBuilder Replacement(StringBuilder indata, int i)
        {
            for (int j = i + 1; j < indata.Length; j++)
                indata[j - 1] = indata[j];
            return indata;
        }

        public static void LeaveControl(TextBox sender)
        {
            if (sender.Text != "")
            {
                if (sender.Text == "0")
                    sender.Text = "";
            }
        }

        private static bool ContainNumbers(char indata)
        {
            char[] number_set = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < number_set.Length; i++)
                if (number_set[i] == indata)
                    return true;
            return false;
        }

        public static void CorrectNotRelevantWriting(StringBuilder indata)
        {
            StringBuilder output = new StringBuilder("");
            if (indata.ToString() != "")
                if (indata[indata.Length - 1] != ',')
                {
                    output.Insert(0, (int.Parse(indata.ToString())).ToString(), 1);
                    if (indata.Length >= 2)
                        if (indata[0] == '0')
                        {
                            indata = Replacement(indata, 0);
                            indata.Length -= 1;
                        }
                }
        }

        public static string Correct_Data_Int(string indata)
        {
            if (indata == "")
                return indata;
            StringBuilder tmp = new StringBuilder(indata);
            for (int i = 0; i < tmp.Length; i++)
            {
                bool isModified = false;
                if (!(ContainNumbers(tmp[i])))
                {
                    tmp = Replacement(tmp, i);
                    isModified = true;
                }
                if (isModified)
                {
                    tmp.Remove(tmp.Length - 1, 1);
                    i--;
                }
            }
            try
            {
                CorrectNotRelevantWriting(tmp);
            }
            catch (OverflowException)
            {
                tmp = new StringBuilder("");
                MessageBox.Show("Введенное число слишком большое.\nДопустимый промежуток от 1 до 2^16 - 1.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                tmp = new StringBuilder("");
                MessageBox.Show("Введённы символы. Введите число.\nДопустимый промежуток от 1 до 2^16 - 1.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return tmp.ToString();
        }
        public static string Correct_Data_Double(string indata)
        {
            if (indata == "")
                return indata;
            StringBuilder tmp = new StringBuilder(indata);
            int comma_n = 0;
            for (int i = 0; i < tmp.Length; i++)
            {
                bool isModified = false;
                if (!((ContainNumbers(tmp[i])) || (tmp[i] == ',')))
                {
                    tmp = Replacement(tmp, i);
                    isModified = true;
                }
                if (tmp[i] == ',')
                {
                    comma_n++;
                    if (comma_n > 1)
                    {
                        tmp = Replacement(tmp, i);
                        isModified = true;
                        comma_n--;
                    }
                    if (tmp.Length < 2)
                    {
                        tmp = Replacement(tmp, i);
                        isModified = true;
                        comma_n--;
                    }
                    if ((tmp[i] == ',') && (i == 0))
                    {
                        tmp = Replacement(tmp, i);
                        isModified = true;
                        comma_n--;
                    }
                }
                if (isModified)
                {
                    tmp.Remove(tmp.Length - 1, 1);
                    i--;
                }
            }
            try
            {
                CorrectNotRelevantWriting(tmp);
            }
            catch (OverflowException)
            {
                tmp = new StringBuilder("");
                MessageBox.Show("Введённое число слишком большое.\nДопустимый промежуток (0; 1,7 × 10^308].", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return tmp.ToString();
        }
    }
}
