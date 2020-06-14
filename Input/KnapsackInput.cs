using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CWork.Entities.Input
{
    public class KnapsackInput
    {
        public KnapsackInput()
        {
            Items = new List<Item>();
        }
        public KnapsackInput(int capacity, int amountOfItems, int i, int j)
        {
            Capacity = capacity;
            Items = new List<Item>();
            for (int y = 1; y <= amountOfItems; y++)
            {
                Items.Add(new Item(y.ToString(), i * y + 6, j * y + 1));
            }
        }

        private int _maxRandomCapacity = 100;
        private int _minRandomCapacity = 10;
        private int _maxRandomAmountOfItems = 20;
        private int _minRandomAmountOfItems = 2;
        private int _maxRandomValue = 50;
        private int _minRandomValue = 1;
        private int _maxRandomWeight = 30;
        private int _minRandomWeight = 1;

        public IList<Item> Items { get; set; }

        public int Capacity { get; set; }

        public int ExpectedResult { get; set; }

        public void GenerateRandomItems()
        {
            var random = new Random();
            Capacity = random.Next(_minRandomCapacity, _maxRandomCapacity);
            var amountOfItems = random.Next(_minRandomAmountOfItems, _maxRandomAmountOfItems);
            for (int i = 0; i < amountOfItems; i++)
            {
                Items.Add(new Item((i+1).ToString(), random.Next(_minRandomValue, _maxRandomValue), random.Next(_minRandomWeight, _maxRandomWeight)));
            }

        }
        public void ReadInput(string fileName)
           {
               var newName = "..\\..\\..\\Input\\InputSamples\\" + fileName;

               try
               {
                   using (StreamReader reader = new StreamReader(newName))
                   {
                       int count = int.Parse(reader.ReadLine());
                       for (int i = 0; i < count; i++)
                       {
                           var line = reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                           var item = new Item
                           {
                               Name = line[0],
                               Value = int.Parse(line[1]),
                               Weight = int.Parse(line[2])
                           };

                           Items.Add(item);
                       }
                       Capacity = int.Parse(reader.ReadLine());
                   }
               }
               catch (Exception e)
               {
                   Console.WriteLine("The file could not be read:");
                   Console.WriteLine(e.Message);
               }
           }
    }
}
