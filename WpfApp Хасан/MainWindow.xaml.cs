using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_Хасан 
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

        private void btnMerge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> list1 = GetNumbersFromTextBox(txtList1);
                List<int> list2 = GetNumbersFromTextBox(txtList2);

                List<int> mergedList = ListUtils.MergeSortedLists(list1, list2);

                txtMergedList.Text = string.Join(" ", mergedList);
                txtResult.Text = "Слияние успешно выполнено!";
            }
            catch (Exception ex)
            {
                txtResult.Text = $"Ошибка: {ex.Message}";
            }
        }

        private List<int> GetNumbersFromTextBox(TextBox textBox)
        {
            return textBox.Text.Split(' ').Select(int.Parse).ToList();
        }
    }

    public static class ListUtils
    {
        public static List<int> MergeSortedLists(List<int> list1, List<int> list2)
        {
            List<int> mergedList = new List<int>();
            int i = 0, j = 0;

            while (i < list1.Count && j < list2.Count)
            {
                if (list1[i] <= list2[j])
                {
                    mergedList.Add(list1[i]);
                    i++;
                }
                else
                {
                    mergedList.Add(list2[j]);
                    j++;
                }
            }

            // Добавляем оставшиеся элементы из list1
            while (i < list1.Count)
            {
                mergedList.Add(list1[i]);
                i++;
            }

            // Добавляем оставшиеся элементы из list2
            while (j < list2.Count)
            {
                mergedList.Add(list2[j]);
                j++;
            }

            return mergedList;
        }
    }
}