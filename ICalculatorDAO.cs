using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc170419
{
    interface ICalculatorDAO
    {
        void InsertValuesIntoTablesXAndY(int x, int y);
        void GetOperationResult();
        void UpdateToResults(int id, double result);
        void PrintResults();

    }
}
