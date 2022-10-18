using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStringSplitApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestModel())
            {
                db.Database.Log = Console.WriteLine;

                var list = new[] { "nagesh", "mohan", "VAFFE" };

                var result1 = db.People
                    .Where(s => list.Contains(s.LastName))
                    .ToList();

                var joined = string.Join(",", list);

                var result2 = db.People
                    .Where(s => db.String_split(joined, ",")
                        .Any(l => l.Value == s.LastName))
                    .ToList();
                Console.ReadLine();
            }
        }
    }
}
