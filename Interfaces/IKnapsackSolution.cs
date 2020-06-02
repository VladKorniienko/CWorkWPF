using CWork.Entities;
using System.Collections.Generic;

namespace CWork.Interfaces
{
    public interface IKnapsackSolution
    {
        string Approach { get; set; }

        IList<Item> Items { get; set; }

        double TotalWeight { get; set; }

        double Value { get; set; }
    }
}
