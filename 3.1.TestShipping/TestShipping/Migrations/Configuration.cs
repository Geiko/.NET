namespace TestShipping.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestShipping.Models.ShippingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestShipping.Models.ShippingDBContext context)
        {
            Random r = new Random();
            const int MIN_WEIGHT = 250;
            const int MAX_WEIGHT = 650;
            const int CATEGORY_LENGHT = 20;

            List<string> customers = new List<string>
            {
                "Metinvest", "Interpipe", "PrivatBank", "Arselor", "DniproAzot", "OPZ", "Stirol",
                "CherkasyAzot", "RovnoAzot", "SumyFrunzeNPO", "UTZ", "UMZ", "EnakievoMZ", "DniproKoksoHim",
                "NZFerrosplavov", "Azovstal", "Zaporogstal","CrimeaTitan", "DMK_Dzerdginskogo", "NKMZ"
            };

            List<string> carriers = new List<string>
            {
                "Carrier1", "Carrier2", "Carrier3", "Carrier4", "Carrier5", "Carrier6", "Carrier7",
                "Carrier8", "Carrier9", "Carrier10", "Carrier11", "Carrier12", "Carrier13", "Carrier14",
                "Carrier15", "Carrier16", "Carrier17", "Carrier18", "Carrier19", "Carrier20"
            };

            List<string> cities = new List<string>
            {
                "Kiev", "Dnipro", "Donetsk", "Odessa", "Lviv", "Harkiv", "Zaporogye",
                "Lviv", "KrivoyRog", "Kamenskoe", "Gorlovka", "Rivno", "Sumy", "Mariupol",
                "Poltava", "Cherkasy", "Herson", "Ternopol", "Chernigov", "Gitomir"
            };

            var shippings = new List<Shipping>();
            for (int i = 0; i < CATEGORY_LENGHT; i++)
            {
                for (int j = 0; j < CATEGORY_LENGHT; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    for (int y = 0; y < CATEGORY_LENGHT; y++)
                    {

                        shippings.Add(new Shipping
                        {
                            Month = 1,
                            Year = 2016,
                            Departure = cities[i],
                            Purpose = cities[j],
                            Customer = customers[y],
                            Carrier = carriers[i],
                            ScheduledTraffic = 1800,
                            ActualTraffic = 1700,
                            Day1Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day2Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day3Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day4Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day5Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day6Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day7Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day8Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day9Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day10Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day11Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day12Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day13Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day14Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day15Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day16Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day17Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day18Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day19Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day20Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day21Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day22Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day23Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day24Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day25Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day26Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day27Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day28Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day29Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day30Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day31Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10
                        });

                        shippings.Add(new Shipping
                        {
                            Month = 2,
                            Year = 2016,
                            Departure = cities[i],
                            Purpose = cities[j],
                            Customer = customers[y],
                            Carrier = carriers[i],
                            ScheduledTraffic = 1800,
                            ActualTraffic = 1000,
                            Day1Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day2Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day3Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day4Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day5Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day6Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day7Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day8Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day9Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day10Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day11Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day12Tons = Convert.ToDouble(r.Next(MIN_WEIGHT, MAX_WEIGHT)) / 10,
                            Day13Tons = 0,
                            Day14Tons = 0,
                            Day15Tons = 0,
                            Day16Tons = 0,
                            Day17Tons = 0,
                            Day18Tons = 0,
                            Day19Tons = 0,
                            Day20Tons = 0,
                            Day21Tons = 0,
                            Day22Tons = 0,
                            Day23Tons = 0,
                            Day24Tons = 0,
                            Day25Tons = 0,
                            Day26Tons = 0,
                            Day27Tons = 0,
                            Day28Tons = 0,
                            Day29Tons = 0,
                            Day30Tons = null,
                            Day31Tons = null
                        });

                    }
                }
            }

            shippings.ForEach(s => context.Shippings.Add(s));
            context.SaveChanges();
        }
    }
}
