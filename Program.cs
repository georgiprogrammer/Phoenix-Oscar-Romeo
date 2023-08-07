using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix_Oscar_Romeo
{
    class Program
    {
        static void Main(string[] args)
        {
            var otbor = new Dictionary<string, List<string>>();
            while (true)
            {
                var input = Console.ReadLine().Trim();
                if (input == "Blaze it!")
                {
                    break;
                }
                string[] red = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                if (red[0] != red[1])
                {
                    if (otbor.ContainsKey(red[0]))//има такъв капитан
                    {
                        if (!otbor[red[0]].Contains(red[1]))//не съдържа съоотборник
                        {
                            otbor[red[0]].Add(red[1]);
                        }
                    }
                    else
                    {//няма такъв капитан
                        var kList = new List<string>();
                        kList.Add(red[1]);
                        otbor.Add(red[0], kList);
                    }
                }
            }
            var kapitani = otbor.Keys.ToList();//ключове в списък
            for (int i = otbor.Count - 1; i >= 0; i--)
            {
                var n = otbor.ElementAt(i);
                var kapitan = n.Key;
                var teammate = n.Value;
                foreach (var k in kapitani)
                {
                    if (teammate.Contains(k) && otbor[k].Contains(kapitan))
                    {
                        otbor.ElementAt(i).Value.Remove(k);
                        otbor[k].Remove(kapitan);// не брои съотборника
                    }
                }
            }
            var Sorted = from entry in otbor orderby entry.Value.Count descending select entry;
            foreach (var item in Sorted)
            {
                Console.WriteLine($"{item.Key}:{item.Value.Count}");
            }


        }
        }
    }





