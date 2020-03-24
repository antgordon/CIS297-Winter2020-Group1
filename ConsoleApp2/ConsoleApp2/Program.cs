using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Beverage 
    {
        public string Name { get; private set; }
        public double VolumeInMilliters { get; private set; }
        protected Beverage() { }
        protected Beverage(string name, double ML) 
        {
            Name = name;
            VolumeInMilliters = ML;
        }
        public override string ToString()
        {
            string nameAndML = $"Name: + {Name}  Volume(ML) {VolumeInMilliters}";

            
            return nameAndML;
        }
    }
    public class AlcoholicBeverage : Beverage
    {
        public double AlcoholByVolumePercentage {get; private set; }
        AlcoholicBeverage(string name, double ML, double percentage)
        {
            AlcoholByVolumePercentage = percentage;
        }
        public override string ToString()
        {
            string nameAndML = $"Name: + {Name}  Volume(ML) {VolumeInMilliters}, Alcohol Percentage By Volume: {AlcoholByVolumePercentage}";


            return nameAndML;
        }

    }
    interface IRockPaperScissors {
        string Shoot();
    }

    class onlyReturnsRock : IRockPaperScissors
    {
        public string Shoot()
        {
            int ranNum;
            Random random = new Random();
            ranNum = random.Next(1, 4);
            if(ranNum == 1)
            return "Rock";
            if (ranNum == 2)
                return "Paper";
            if (ranNum == 3)
                return "Scissors";
            else throw new Exception("Unkown Error");
        }
    }

    class Program
    {
        public List<int> filter_out_evens(List<int> numbers)
        {
            List<int> oddList = new List<int>();
            
            foreach (int num in numbers)
            {
                if (num % 2 != 0)
                    oddList.Add(num);
            }

            return oddList;
        }
        static void Main(string[] args)
        {
            
            //things

        }
    }
}
