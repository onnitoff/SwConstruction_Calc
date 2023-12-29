using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calc.Controller
{
    class InOutput
    {
        public InOutput() { }

        public string Read()
        {
            string filePath = "some.txt";
            try
            {
                string content = File.ReadAllText(filePath);
                return content;
            }
            catch (Exception ex)
            {
                return "reading error\n" + ex.Message;
                
            }
            
        }

        public string Write(string content)
        {
            string filePath = "some.txt";
            try
            {
                File.WriteAllText(filePath, content);
                return "Write was a success";
            }
            catch (Exception ex)
            {
                return "write error\n" + ex.Message;

            }
        }
    }
}
