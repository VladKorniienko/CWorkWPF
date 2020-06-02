using CWork.Entities;
using CWork.Solvers;
using System.Collections.Generic;
using System.Windows;

namespace CWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BaB_Click(object sender, RoutedEventArgs e)
        {
            var input = new KnapsackInput()
            {
                Capacity = 25,
                Items =
                                     new List<Item>()
                                         {
                                             new Item { Name = "1", Weight = 2, Value = 4 },
                                             new Item { Name = "2", Weight = 4,  Value = 7 },
                                             new Item { Name = "3", Weight = 6, Value = 10 },
                                             new Item { Name = "4", Weight = 8, Value = 13 },
                                             new Item { Name = "5", Weight = 10, Value = 16 },
                                             new Item { Name = "6", Weight = 12, Value = 19 },
                                             new Item { Name = "7", Weight = 14, Value = 22 },
                                             new Item { Name = "8", Weight = 16, Value = 25 }
                                         }
            };
            var solver = new BranchAndBoundSolver(input.Items, input.Capacity);
            var solution = solver.Solve();
            itemsGrid.DataContext = solution.Items;
            allItemsGrid.DataContext = input.Items;
            resultTextBlock.Text = "Capacity: " + solution.Capacity + ". Total value = " + solution.Value + ". Total weight = " + solution.TotalWeight + ".";
            MessageBox.Show("Task is solved!");
        }


    }
}

