using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc170419
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0;

            ICalculatorDAO xy = new CalculatorDAO();

            do
            {
                Console.WriteLine("Enter x value");
                x = Convert.ToInt32(Console.ReadLine());
                if (x <= 0)
                {
                    break;
                }
                Console.WriteLine("Enter y value");
                y = Convert.ToInt32(Console.ReadLine());
                xy.InsertValuesIntoTablesXAndY(x, y);
            } while (x > 0);

            xy.GetOperationResult();

            xy.PrintResults();

            Console.ReadLine();
        }

        
    }
}
