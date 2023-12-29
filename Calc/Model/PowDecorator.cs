using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    internal class PowDecorator : ICalc
    {
        private readonly ICalc _calc;
        public PowDecorator(ICalc calc) 
        {
            _calc = calc;             
        }

        public double PerformOperation(double operand1, double operand2, string operation)
        {
            
                return Math.Pow(_calc.PerformOperation(operand1, operand2, operation),2);
            
        }
    }
}
