using System;
using System.Linq;

namespace _06.Heist
{
    // Really happy with class development and use of exception

    class Program
    {
        static void Main(string[] args)
        {
            int[] goodsPrice = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int jewelPrice = goodsPrice[0];
            int goldUnitPrice = goodsPrice[1];

            CareerInCrime CareerInCrime = new CareerInCrime(jewelPrice, goldUnitPrice);

            while (true)
            {
                try
                {
                    CareerInCrime.PerformHeist(new Heist(Console.ReadLine()));
                }
                catch (JailTimeException)
                {
                    break;
                }
                catch (HeistIsEmptyStringException)
                {
                    Console.WriteLine("A heist can't be an empty string. Please, input a valid heist.");
                }
                catch (HeistIsNullException)
                {
                    Console.WriteLine("A heist can't be the null reference. Please, input a valid heist.");
                }
                catch(Exception)
                {
                    Console.WriteLine("Something went wrong. Please, input a valid heist.");
                }
            }

            if (CareerInCrime.Balance >= 0)
                Console.WriteLine($"Heists will continue. Total earnings: {CareerInCrime.Balance}.");
            else
                Console.WriteLine($"Have to find another job. Lost: {Math.Abs(CareerInCrime.Balance)}.");
        }

        class Heist
        {
            public string loot;
            public int expenses;

            public Heist(string heist)
            {
                if (heist == "Jail Time") throw new JailTimeException();
                else if (heist == string.Empty) throw new HeistIsEmptyStringException();
                else if (heist == null) throw new HeistIsNullException();
                else
                {
                    string[] heistResult = heist.Split();
                    this.loot = heistResult[0];
                    this.expenses = int.Parse(heistResult[1]);
                }
            }
        }

        class JailTimeException : Exception { }
        class HeistIsEmptyStringException : Exception { }
        class HeistIsNullException : Exception { }

        class CareerInCrime
        {
            int jewelPrice;
            int goldUnitPrice;

            public int totalEarnings;
            public int totalExpenses;

            public CareerInCrime(int jewelPrice, int goldUnitPrice)
            {
                this.jewelPrice = jewelPrice;
                this.goldUnitPrice = goldUnitPrice;
            }

            public int Balance
            {
                get { return totalEarnings - totalExpenses; }
            }

            public void PerformHeist(Heist heist)
            {
                this.totalExpenses += heist.expenses;

                foreach (char item in heist.loot)
                {
                    switch (item)
                    {
                        case '%':
                            this.totalEarnings += jewelPrice;
                            break;
                        case '$':
                            this.totalEarnings += goldUnitPrice;
                            break;

                        default: break;
                    }
                }
            }

        }


    }
}
