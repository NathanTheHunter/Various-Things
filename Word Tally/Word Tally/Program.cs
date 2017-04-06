using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Word_Tally
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText("passage.txt");
            data = data.ToLower();

            for (int n = 0; n >= data.Length; n++) {
                if (Convert.ToInt32(data[n]) < Convert.ToInt32("a") || Convert.ToInt32(data[n]) > Convert.ToInt32("z") || Convert.ToInt32(data[n]) != Convert.ToInt32(" ")) {
                    data.Remove(data[n], 1);
                }
                string[] List = data.Split(' ');
                Dictionary<string, int> dit = new Dictionary<string, int>();
                for (int i = 0; i <= List.Length; i++) {
                    if (dit.ContainsKey(List[i]) == false)
                    {
                        dit.Add(List[i], 1);
                    }
                    else if (dit.ContainsKey(List[i]) == true) {
                        int count;
                        dit.TryGetValue(List[i], out count);
                        count++;
                        dit.Remove(List[i]);
                        dit.Add(List[i], count);
                    }                    
                }
            }
            StreamWriter sw = new StreamWriter("tallies.txt");
            sw.WriteLine("WORD---------------------COUNT");
            sw.WriteLine("------------------------------");
        }
    }
}
