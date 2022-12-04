using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekSeatWitchSaga
{
    class Program
    {
        public static List<int> KilledVillager = new List<int>();
        static void Main(string[] args)
        {
            List<int> FindAverage = new List<int>();
            Console.Write("Input how many people to find : ");
            int loop = Int32.Parse(Console.ReadLine());
            for(int i = 1; i <= loop; i++)
            {
                Console.Write("Input Age and Year of Death of Person "+ i.ToString() + "(separated with comma) : ");
                string AgeAndYear = Console.ReadLine().Trim();
                int[] AgeAndYear2 = Array.ConvertAll(AgeAndYear.Split(','), s => int.Parse(s));
                FindAverage.Add(GetAndFillKilledVillager(AgeAndYear2[1] - AgeAndYear2[0]));
            }
            double result = FindAverage.Average() < 0 ? -1 : FindAverage.Average();
            Console.WriteLine("So the average is : " + result);

            Console.ReadKey();
        }

        public static int GetAndFillKilledVillager(int index)
        {
            int result = 0;
            //if data invalid
            if(index < 0)
            {
                result = -1;
            }
            //fill data if the list is still empty
            else if(KilledVillager.Count() == 0)
            {
                for (int i = 0; i < index; i++)
                {
                    if (i == 0 || i == 1)
                        KilledVillager.Add(1);
                    else
                        KilledVillager.Add(KilledVillager[i - 1] + KilledVillager[i - 2]);
                }
                result = KilledVillager.Sum();
            }//fill the new data if the index is greater than current count data
            else if(index > KilledVillager.Count())
            {
                for (int i = KilledVillager.Count(); i < index; i++)
                {
                    if (i == 1)
                        KilledVillager.Add(1);
                    else
                        KilledVillager.Add(KilledVillager[i - 1] + KilledVillager[i - 2]);
                }
                result = KilledVillager.Sum();
            }//get the sum of data from first to destination index data
            else
            {
                result = KilledVillager.Where(x => x <= KilledVillager.ElementAt(index - 1)).Sum();
            }

            return result;
        }
    }
}
