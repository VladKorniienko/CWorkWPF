﻿using CWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CWork.Solvers
{
    public class GreedySolver : KnapsackSolver
    {

        public GreedySolver(IList<Item> items, int capacity)
            : base(items, capacity)
        {
        }


        public override KnapsackSolution Solve()
        {
            Items = Items.OrderByDescending(i => i.Ratio).ToList();
            var node = new Node();
            foreach (var item in Items)
            {
                if (node.Weight <= Capacity)
                {
                    if (Capacity - node.Weight >= item.Weight)
                    {
                        node.TakenItems.Add(item);
                        node.Weight += item.Weight;
                        node.Value += item.Value;
                    }
                }
              
            }
            var solution = new KnapsackSolution
            {
                Value = node.Value,
                TotalWeight = node.Weight,
                Items = node.TakenItems,
                Capacity = Capacity,
                Approach = "Greedy Algorithm"
            };

            return solution;
        }
    }
}
