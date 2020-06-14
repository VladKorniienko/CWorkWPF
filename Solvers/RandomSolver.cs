using CWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWork.Solvers
{
    class RandomSolver : KnapsackSolver
    {
        public RandomSolver(IList<Item> items, int capacity)
            : base(items, capacity)
        {
        }

        public override KnapsackSolution Solve()
        {
            KnapsackSolver knapsackSol = new DynamicProgrammingSolver(Items, Capacity);
            var sol = knapsackSol.Solve();
            Items = Items.OrderByDescending(i => i.Ratio).ToList();
            List<Item> editItems = new List<Item>(Items);
            var myArray = editItems.ToArray();
            var node = new Node();
            var tempNode = new Node();
            int minWeight = int.MaxValue;
            Random random = new Random();
            foreach (var item in editItems)
            {
                if (item.Weight < minWeight)
                {
                    minWeight = item.Weight;
                }
            }
            while (node.Value != sol.Value)
            {
                editItems.Clear();
                editItems = new List<Item>(Items);
                while (Capacity - tempNode.Weight >= minWeight)
                {
                    if (editItems.Count() == 0)
                    {
                        break;
                    }
                    myArray = editItems.ToArray();
                    int index = random.Next(myArray.Length);
                    var item = myArray[index];
                    minWeight = int.MaxValue;
                    foreach (var i in editItems)
                    {
                        if (i.Weight < minWeight)
                        {
                            minWeight = i.Weight;
                        }
                    }

                    if (Capacity - tempNode.Weight >= item.Weight && !tempNode.TakenItems.Contains(item))
                    {
                        tempNode.TakenItems.Add(item);
                        tempNode.Weight += item.Weight;
                        tempNode.Value += item.Value;
                        editItems.RemoveAt(index);
                    }
                }
                node = tempNode;
                tempNode = new Node();
            }
            var solution = new KnapsackSolution
            {
                Value = node.Value,
                TotalWeight = node.Weight,
                Items = node.TakenItems, 
                Capacity = Capacity,
                Approach = "Bad random Algorithm"
            };

            return solution;
        }
    }
}
