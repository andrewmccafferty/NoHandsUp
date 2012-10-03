using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Xerxes.NoHandsUp.Model
{
    public static class RandomizingExtensions
    {
        public static T NextRandom<T>(this IEnumerable<T>  source)
        {
            Random gen = GetRandomGenerator();
            int maxValue = source.Count();
            var value = gen.Next(0, maxValue);
            
            return source.Skip(value).Take(1).First();
        }

        public static List<T> ShuffleList<T>(this IEnumerable<T> source)
        {
            return source.ToList();

            //List<T> shuffledList = new List<T>();

            //Random gen = GetRandomGenerator();
            //while (source.Count() > 0)
            //{
            //    int maxValue = source.Count();
            //    int index = gen.Next(0, maxValue);
            //    shuffledList.Add(source.ElementAt(index));
                
            //    source.RemoveAt(index);
            //}

            //return shuffledList;
        }

        private static Random GetRandomGenerator()
        {
            Random gen = new Random((int)DateTime.UtcNow.Ticks);
            return gen;
        }

    }
}
