using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Model
{
    internal class CalcModel
    {
        public double PerformOperation(double operand1, double operand2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (operand2 != 0)
                        return operand1 / operand2;
                    else
                        throw new DivideByZeroException("Cannot divide by zero");
                default:
                    throw new InvalidOperationException("Invalid operation");
            }
        }
    }
}
