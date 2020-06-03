using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CWork
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public int Capacity
        {
            get
            {
                int result;
                bool isDone = int.TryParse(capacityBox.Text, out result);
                return result;
            }
        }
        public int AmountOfItems
        {
            get
            {
                int result;
                bool isDone = int.TryParse(amountBox.Text, out result);
                return result;
            }
        }
        public int I
        {

            get
            {
                int result;
                bool isDone = int.TryParse(iCoeffBox.Text, out result);
                return result;
            }
        }
        public int J
        {
            get
            {
                int result;
                bool isDone = int.TryParse(jCoeffBox.Text, out result);
                return result;
            }
        }
    }
}
