using CWork.Entities;
using CWork.Entities.Input;
using CWork.Solvers;
using OxyPlot.Wpf;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace CWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KnapsackInput input;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BaB_Click(object sender, RoutedEventArgs e)
        {
            if (input == null)
            {
                MessageBox.Show("You should choose data first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var stopwatch = new Stopwatch();
                var solver = new BranchAndBoundSolver(input.Items, input.Capacity);
                stopwatch.Start();
                var solution = solver.Solve();
                stopwatch.Stop();
                itemsGrid.DataContext = solution.Items;
                allItemsGrid.DataContext = input.Items;
                resultTextBlock.Text = "Capacity: " + solution.Capacity + ". Total value = " + solution.Value + ". Total weight = "
                                             + solution.TotalWeight + ". Time: " + stopwatch.Elapsed;
            }

        }

        private void Greedy_Click(object sender, RoutedEventArgs e)
        {
            if (input == null)
            {
                MessageBox.Show("You should choose data first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var stopwatch = new Stopwatch();
                var solver = new GreedySolver(input.Items, input.Capacity);
                stopwatch.Start();
                var solution = solver.Solve();
                stopwatch.Stop();
                itemsGrid.DataContext = solution.Items;
                allItemsGrid.DataContext = input.Items;
                resultTextBlock.Text = "Capacity: " + solution.Capacity + ". Total value = " + solution.Value + ". Total weight = "
                    + solution.TotalWeight + "." + " Time: " + stopwatch.Elapsed;
            }

        }
        private void Rand_Click(object sender, RoutedEventArgs e)
        {
            if (input == null)
            {
                MessageBox.Show("You should choose data first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var stopwatch = new Stopwatch();
                var solver = new RandomSolver(input.Items, input.Capacity);
                stopwatch.Start();
                var solution = solver.Solve();
                stopwatch.Stop();
                itemsGrid.DataContext = solution.Items;
                allItemsGrid.DataContext = input.Items;
                resultTextBlock.Text = "Capacity: " + solution.Capacity + ". Total value = " + solution.Value + ". Total weight = "
                    + solution.TotalWeight + "." + " Time: " + stopwatch.Elapsed;
            }

        }
        private void DP_Click(object sender, RoutedEventArgs e)
        {
            if (input == null)
            {
                MessageBox.Show("You should choose data first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var stopwatch = new Stopwatch();
                var solver = new DynamicProgrammingSolver(input.Items, input.Capacity);
                stopwatch.Start();
                var solution = solver.Solve();
                stopwatch.Stop();
                itemsGrid.DataContext = solution.Items;
                allItemsGrid.DataContext = input.Items;
                resultTextBlock.Text = "Capacity: " + solution.Capacity + ". Total value = " + solution.Value + ". Total weight = "
                    + solution.TotalWeight + "." + " Time: " + stopwatch.Elapsed;
            }

        }

        private void GenerateRandom_Click(object sender, RoutedEventArgs e)
        {
            input = new KnapsackInput();
            input.GenerateRandomItems();
            allItemsGrid.DataContext = input.Items;
            itemsGrid.DataContext = null;
            resultTextBlock.Text = "Result of the solution will be displayed here";
        }

        private void GenerateCoeff_Click(object sender, RoutedEventArgs e)
        {
            var coeffWindow = new DialogWindow();

            if (coeffWindow.ShowDialog() == true)
            {
                input = new KnapsackInput(coeffWindow.Capacity, coeffWindow.AmountOfItems, coeffWindow.I, coeffWindow.J);
                allItemsGrid.DataContext = input.Items;
                itemsGrid.DataContext = null;
                resultTextBlock.Text = "Result of the solution will be displayed here";
            }
        }

        private void UseSet1_Click(object sender, RoutedEventArgs e)
        {
            input = new KnapsackInput()
            {
                Capacity = 10,
                Items = new List<Item>()
                 {
                    new Item { Name = "1", Weight = 4, Value = 40 },
                    new Item { Name = "2", Weight = 7,  Value = 42 },
                    new Item { Name = "3", Weight = 5, Value = 25 },
                    new Item { Name = "4", Weight = 3, Value = 12 }
                 }
            };

            allItemsGrid.DataContext = input.Items;
            itemsGrid.DataContext = null;
            resultTextBlock.Text = "Result of the solution will be displayed here";
        }

        private void UseSet2_Click(object sender, RoutedEventArgs e)
        {
            input = new KnapsackInput()
            {
                Capacity = 16,
                Items = new List<Item>()
                {
                     new Item() { Name = "1", Value = 50, Weight = 5 },
                     new Item() { Name = "2", Value = 99, Weight = 9 },
                     new Item() { Name = "3", Value = 18, Weight = 2 },
                     new Item() { Name = "4", Value = 15, Weight = 3 },
                     new Item() { Name = "5", Value = 42, Weight = 7 }
                }
            };

            allItemsGrid.DataContext = input.Items;
            itemsGrid.DataContext = null;
            resultTextBlock.Text = "Result of the solution will be displayed here";
        }

        private void UseSet3_Click(object sender, RoutedEventArgs e)
        {
            input = new KnapsackInput()
            {
                Capacity = 41,
                Items = new List<Item>()
                 {
                    new Item { Name = "1", Weight = 12, Value = 14 },
                    new Item { Name = "2", Weight = 40,  Value = 34 },
                    new Item { Name = "3", Weight = 10, Value = 12 },
                    new Item { Name = "4", Weight = 18, Value = 13 },
                    new Item { Name = "5", Weight = 10, Value = 16 },
                    new Item { Name = "6", Weight = 12, Value = 19 },
                    new Item { Name = "7", Weight = 14, Value = 22 },
                    new Item { Name = "8", Weight = 16, Value = 25 }
                 }
            };

            allItemsGrid.DataContext = input.Items;
            itemsGrid.DataContext = null;
            resultTextBlock.Text = "Result of the solution will be displayed here";
        }

        private void InputManually_Click(object sender, RoutedEventArgs e)
        {
            var inputManuallyWindow = new InputManuallyWindow();

            if (inputManuallyWindow.ShowDialog() == true)
            {
                input = new KnapsackInput()
                {
                    Capacity = inputManuallyWindow.CapacityToAdd,
                    Items = new List<Item>(inputManuallyWindow.ItemsToAdd)
                };
                allItemsGrid.DataContext = input.Items;
                itemsGrid.DataContext = null;
                resultTextBlock.Text = "Result of the solution will be displayed here";
            }
        }

        private void InputFile_Click(object sender, RoutedEventArgs e)
        {

            var inputFileWindow = new InputFileWindow();
            if (inputFileWindow.ShowDialog() == true)
            {
                input = new KnapsackInput();

                input.ReadInput(inputFileWindow.FileName);
            }
            allItemsGrid.DataContext = input.Items;
            itemsGrid.DataContext = null;
            resultTextBlock.Text = "Result of the solution will be displayed here";
        }

        private void Plot_Click(object sender, RoutedEventArgs e)
        {
            var plotWindow = new PlotWindow();
            plotWindow.ShowDialog();
        }
        private void Plot_Click100(object sender, RoutedEventArgs e)
        {
            var plotWindow = new PlotWindow100();
            plotWindow.ShowDialog();
        }
    }
}

