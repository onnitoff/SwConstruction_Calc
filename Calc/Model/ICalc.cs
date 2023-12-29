using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    internal interface ICalc
    {
        double PerformOperation(double operand1, double operand2, string operation);
    }
}
