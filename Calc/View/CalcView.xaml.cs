﻿using Calc.Controller;
using Calc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calc.View
{
    /// <summary>
    /// Логика взаимодействия для CalcView.xaml
    /// </summary>
    public partial class CalcView : Window
    {
        public CalcView()
        {

            //InitializeComponent();

            CalcModel model = new CalcModel();
            CalcView view = new CalcView();
           // CalcController controller = new CalcController(model, view);

           // controller.Show();
        }
    }
}
