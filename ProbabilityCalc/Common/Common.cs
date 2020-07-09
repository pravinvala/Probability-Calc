using Microsoft.AspNetCore.Mvc.Rendering;
using ProbabilityCalc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProbabilityCalc.Common
{
    public class CommonVariables
    {
        #region function dropdown
        public List<SelectListItem> FunctionList()
        {
            return new List<SelectListItem> {
                new SelectListItem { Text = "Combined With", Value = "Combined_With" },
                 new SelectListItem { Text = "Either", Value = "Either" }
            };
        }
        #endregion

        #region probability calculation
        public decimal CalculateData(CalculatorModel CalculateData)
        {
            decimal Result;
            if (CalculateData.Function == "Combined_With")
                Result = CalculateData.Probability1 * CalculateData.Probability2;

            else
                Result = (CalculateData.Probability1 + CalculateData.Probability2) - (CalculateData.Probability1 * CalculateData.Probability2);

            ResultLog(CalculateData, Result);
            return Result;
        }
        #endregion

        #region probability calculation logging
        public void ResultLog(CalculatorModel CalculateData, decimal Result)
        {
            var LogFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(LogFilePath + "\\" + "Log.txt"))
                {
                    w.WriteLine(DateTime.Now.ToLongDateString() + " " +DateTime.Now.ToLongTimeString()+
                        "\t\t PB1: " + CalculateData.Probability1+
                        "\t\t PB2: " + CalculateData.Probability1+
                        "\t\t Fn: " + CalculateData.Function+
                        "\t\t RESULT: " + Result);
                }
            }
            catch (Exception ex)
            {
                //Exception Handling
            }
        }

        #endregion

    }
}
