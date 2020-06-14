using Magnum.FileSystem;
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
    /// Interaction logic for InputFileWindow.xaml
    /// </summary>
    public partial class InputFileWindow : Window
    {

        public InputFileWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (fileNameBox.Text.Length != 0)
            {
                FileName = fileNameBox.Text;
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("You should input file name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public string FileName { get; set; }
    }
}
