using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Calc.Model;
using Calc.View;

namespace Calc.Controller
{
    public partial class CalcController : Window
    {
        private CalcModel model;
        private string currentInput;
        private double currentResult;
        private string currentOperation;

        public CalcController()
        {
            InitializeComponent();
            model = new CalcModel();
            currentInput = string.Empty;
            currentResult = 0;
            currentOperation = string.Empty;
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                currentInput += button.Content.ToString();
                UpdateDisplay(currentInput);
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (!string.IsNullOrEmpty(currentOperation))
                {
                    PerformCalculation();
                    currentInput = currentResult.ToString();
                    UpdateDisplay(currentInput);
                }
                else
                {
                    currentOperation = button.Content.ToString();
                    currentResult = double.Parse(currentInput);
                    UpdateDisplay(currentInput);
                    currentInput = string.Empty;
                }

                
            }
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double operand2 = double.Parse(currentInput);
                PerformCalculation();
                currentInput = currentResult.ToString();
                UpdateDisplay(currentInput);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                Clear();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            UpdateDisplay(currentInput);
        }

        private void Clear()
        {
            currentInput = string.Empty;
            currentResult = 0;
            currentOperation = string.Empty;
        }

        private void PerformCalculation()
        {
            try
            {
                double operand2 = double.Parse(currentInput);
                currentResult = model.PerformOperation(currentResult, operand2, currentOperation);
                currentInput = string.Empty;
                currentOperation = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                Clear();
            }
        }

        private void UpdateDisplay(string value)
        {
            txtResult.Text = value;
        }
    }
}
