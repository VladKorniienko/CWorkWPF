using CWork.Entities.Input;
using CWork.Solvers;
using OxyPlot;
using System.Collections.Generic;
using System.Diagnostics;

namespace CWork
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            this.Title = "Red - Branch&Bound algorithm\nGreen - Randomized algorithm\nPurple - Greedy algoritm";
            this.timeResultsBaB1000 = new List<DataPoint>();
            this.timeResultsRand1000 = new List<DataPoint>();
            this.timeResultsGreedy1000 = new List<DataPoint>();
            this.timeResultsBaB = new List<DataPoint>();
            this.timeResultsRand = new List<DataPoint>();
            this.timeResultsGreedy = new List<DataPoint>();
            SolveMultiple1000();
            SolveMultiple100();
        }
        private void SolveMultiple1000()
        {
            KnapsackInput input;
            for (int i = 0; i < 1000; i++)
            {
                input = new KnapsackInput();
                input.GenerateRandomItems();
                var stopwatch = new Stopwatch();
                var solverBaB = new BranchAndBoundSolver(input.Items, input.Capacity);
                var solverRand = new RandomSolver(input.Items, input.Capacity);
                var solverGreedy = new GreedySolver(input.Items, input.Capacity);
                stopwatch.Start();
                solverBaB.Solve();
                stopwatch.Stop();
                timeResultsBaB1000.Add(new DataPoint(i, stopwatch.Elapsed.TotalMilliseconds));
                stopwatch.Restart();
                solverRand.Solve();
                stopwatch.Stop();
                timeResultsRand1000.Add(new DataPoint(i, stopwatch.Elapsed.TotalMilliseconds));
                stopwatch.Restart();
                solverGreedy.Solve();
                stopwatch.Stop();
                timeResultsGreedy1000.Add(new DataPoint(i, stopwatch.Elapsed.TotalMilliseconds));
            }
        }
        private void SolveMultiple100()
        {
            KnapsackInput input;
            for (int i = 0; i < 100; i++)
            {
                input = new KnapsackInput();
                input.GenerateRandomItems();
                var stopwatch = new Stopwatch();
                var solverBaB = new BranchAndBoundSolver(input.Items, input.Capacity);
                var solverRand = new RandomSolver(input.Items, input.Capacity);
                var solverGreedy = new GreedySolver(input.Items, input.Capacity);
                stopwatch.Start();
                solverBaB.Solve();
                stopwatch.Stop();
                timeResultsBaB.Add(new DataPoint(i, stopwatch.Elapsed.TotalMilliseconds));
                stopwatch.Restart();
                solverRand.Solve();
                stopwatch.Stop();
                timeResultsRand.Add(new DataPoint(i, stopwatch.Elapsed.TotalMilliseconds));
                stopwatch.Restart();
                solverGreedy.Solve();
                stopwatch.Stop();
                timeResultsGreedy.Add(new DataPoint(i, stopwatch.Elapsed.TotalMilliseconds));
            }
        }
        public List<DataPoint> timeResultsBaB1000 { get; set; }

        public List<DataPoint> timeResultsRand1000 { get; set; }
        public List<DataPoint> timeResultsGreedy1000 { get; set; }
        public List<DataPoint> timeResultsBaB { get; set; }
        public List<DataPoint> timeResultsRand { get; set; }
        public List<DataPoint> timeResultsGreedy { get; set; }
        public PlotModel MyModel { get; private set; }
        public string Title { get; private set; }
    }
}
