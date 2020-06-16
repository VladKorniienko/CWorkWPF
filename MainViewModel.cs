using CWork.Entities.Input;
using CWork.Solvers;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CWork
{
    public class MainViewModel
    {
        public MainViewModel()
        {

            this.timeResultsBaB1000 = new List<DataPoint>();
            this.timeResultsRand1000 = new List<DataPoint>();
            this.timeResultsGreedy1000 = new List<DataPoint>();
            this.timeResultsDynamic1000 = new List<DataPoint>();
            this.timeResultsBaB = new List<DataPoint>();
            this.timeResultsRand = new List<DataPoint>();
            this.timeResultsGreedy = new List<DataPoint>();
            this.timeResultsDynamic = new List<DataPoint>();
            SolveMultiple1000();
            SolveMultiple100();
            this.Title = "Red - Branch&Bound algorithm\nGreen - Randomized algorithm\nPurple - Greedy algorithm\nOrange - Dynamic algorithm\nAverage: G-"
                + timeAverageGreedy + " D-" + timeAverageDynamic + " R-" + timeAverageRand + " B&B-" + timeAverageBaB;
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
                var solverDynamic = new DynamicProgrammingSolver(input.Items, input.Capacity);
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
                stopwatch.Restart();
                solverDynamic.Solve();
                stopwatch.Stop();
                timeResultsDynamic1000.Add(new DataPoint(i, stopwatch.Elapsed.TotalMilliseconds));
            }
            timeAverageGreedy = Math.Round((timeResultsGreedy1000.Sum(x => x.Y) / 1000), 4);
            timeAverageRand = Math.Round((timeResultsRand1000.Sum(x => x.Y) / 1000), 4);
            timeAverageBaB = Math.Round((timeResultsBaB1000.Sum(x => x.Y) / 1000), 4);
            timeAverageDynamic = Math.Round((timeResultsDynamic1000.Sum(x => x.Y) / 1000), 4);
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
                var solverDynamic = new DynamicProgrammingSolver(input.Items, input.Capacity);
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
                stopwatch.Restart();
                solverDynamic.Solve();
                stopwatch.Stop();
                timeResultsDynamic.Add(new DataPoint(i, stopwatch.Elapsed.TotalMilliseconds));
            }
            timeAverageGreedy = Math.Round((timeResultsGreedy.Sum(x => x.Y) / 100), 4);
            timeAverageRand = Math.Round((timeResultsRand.Sum(x => x.Y) / 100), 4);
            timeAverageBaB = Math.Round((timeResultsBaB.Sum(x => x.Y) / 100), 4);
            timeAverageDynamic = Math.Round((timeResultsDynamic.Sum(x => x.Y) / 100), 4);
        }
        public List<DataPoint> timeResultsBaB1000 { get; set; }

        public List<DataPoint> timeResultsRand1000 { get; set; }
        public List<DataPoint> timeResultsGreedy1000 { get; set; }
        public List<DataPoint> timeResultsDynamic1000 { get; set; }
        public List<DataPoint> timeResultsDynamic { get; set; }
        public List<DataPoint> timeResultsBaB { get; set; }
        public List<DataPoint> timeResultsRand { get; set; }
        public List<DataPoint> timeResultsGreedy { get; set; }
        public double timeAverageRand { get; set; }
        public double timeAverageBaB { get; set; }
        public double timeAverageDynamic { get; set; }
        public double timeAverageGreedy { get; set; }
        public PlotModel MyModel { get; private set; }
        public string Title { get; private set; }
    }
}
