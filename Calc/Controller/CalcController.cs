using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
//using Calc.Model;
using MathClass_Calc;
using Calc.View;
using Calc.Model;
using log4net;
using log4net.Config;
using System.Globalization;

namespace Calc.Controller
{
    public partial class CalcController : Window
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CalcController));
        ICalc model = new CalcModel();
        private ICalc modelDecorator;
        //private CalcModel model;
        private string currentInput;
        private double currentResult;
        private string currentOperation;

        private string content;
        InOutput inOutput = new InOutput();

        public CalcController()
        {
            InitializeComponent();
            model = new CalcModel();
            modelDecorator = new PowDecorator(model);
            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }

            currentInput = string.Empty;
            currentResult = 0;
            currentOperation = string.Empty;
            //log4net.Config.XmlConfigurator.Configure();
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                currentInput += button.Content.ToString();
                UpdateDisplay(currentInput);
                content += currentInput;
                log.Info($"Это информационное сообщение: {currentInput}");
            }
            log.Warn("Пустой вызов Digit_Click");
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
                    try
                    {
                        currentOperation = button.Content.ToString();
                        currentResult = double.Parse(currentInput);
                        UpdateDisplay(currentInput);
                        content += currentOperation;
                        currentInput = string.Empty;
                        log.Info($"Это информационное сообщение: {currentOperation}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                        Clear();
                        log.Error($"Это сообщение об ошибке {ex.Message}");
                    }
                    
                } 
            }
            log.Warn("Пустой вызов Operation_Click");
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
                log.Error($"Это сообщение об ошибке {ex.Message}");
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
                content += "=" + currentResult.ToString() + "\n";
                currentInput = string.Empty;
                currentOperation = string.Empty;
                log.Info($"Это информационное сообщение: {currentResult}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                Clear();
                log.Error($"Это сообщение об ошибке {ex.Message}");
            }
        }

        private void UpdateDisplay(string value)
        {
            txtResult.Text = value;
        }


        private void Pow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PowResult();
                currentInput = currentResult.ToString();
                UpdateDisplay(currentInput);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                Clear();
                log.Error($"Это сообщение об ошибке {ex.Message}");
            }
        }

        private void PowResult()
        {
            try
            {
                double operand2 = double.Parse(currentInput);
                currentResult = modelDecorator.PerformOperation(currentResult, operand2, currentOperation);
                currentInput = string.Empty;
                currentOperation = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                Clear();
                log.Error($"Это сообщение об ошибке {ex.Message}");
            }
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Write(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                log.Error($"Это сообщение об ошибке {ex.Message}");
            }
            
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(inOutput.Read());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            
        }

        private void Write (string content)
        {
            MessageBox.Show(inOutput.Write(content));

        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }
    }
}
