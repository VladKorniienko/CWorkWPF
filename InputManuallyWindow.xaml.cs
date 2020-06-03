using CWork.Entities;
using Magnum.Extensions;
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
    /// Interaction logic for InputManuallyWindow.xaml
    /// </summary>
    public partial class InputManuallyWindow : Window
    {
        private List<Item> _itemsToAdd = new List<Item>();
        private int _capacity;
        public InputManuallyWindow()
        {
            InitializeComponent();
            finishButton.IsEnabled = false;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

            int.TryParse(capacityBox.Text, out _capacity);
            this.DialogResult = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (valueBox.Text.Length != 0 && weightBox.Text.Length != 0)
            {
                int value, weight;
                int.TryParse(valueBox.Text, out value);
                int.TryParse(weightBox.Text, out weight);
                _itemsToAdd.Add(new Item(nameBox.Text, value, weight));
                amountCount.Text = "Current ammount of items: " + _itemsToAdd.Count;
                if (_itemsToAdd.Count >= 2)
                    finishButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("You should choose data first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public List<Item> ItemsToAdd { get { return _itemsToAdd; } }
        public int CapacityToAdd { get { return _capacity; } }
    }
}
