using Microsoft.AspNetCore.Mvc.Rendering;
using ProbabilityCalc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProbabilityCalc.Repository
{
    public interface ICommonRepository
    {
        ResultClass<decimal> CalculateData(CalculatorModel CalculateData);
        void ResultLog(CalculatorModel CalculateData, decimal Result);
    }


    public class CommonRepository : ICommonRepository
    {

        #region probability calculation
        public ResultClass<decimal> CalculateData(CalculatorModel CalculateData)
        {
            ResultClass<decimal> result = new ResultClass<decimal>() { IsSuccess = false };
            if (CalculateData.Probability1 == 0 || CalculateData.Probability1 < 0 || CalculateData.Probability1 > 1)
                result.Message = "Probability 1 must have value between 0 to 1";
            else if (CalculateData.Probability2 == 0 || CalculateData.Probability2 < 0 || CalculateData.Probability2 > 1)
                result.Message = "Probability 2 must have value between 0 to 1";
            else if (CalculateData.Function == "")
                result.Message = "Please select function";
            else
            {
                if (CalculateData.Function == "Combined_With")
                {
                    result.Result = CalculateData.Probability1 * CalculateData.Probability2;
                    result.IsSuccess = true;
                }

                else
                {
                    result.Result = (CalculateData.Probability1 + CalculateData.Probability2) - (CalculateData.Probability1 * CalculateData.Probability2);
                    result.IsSuccess = true;
                }
            }

            ResultLog(CalculateData, result.Result);
            return result;
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
                    w.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() +
                        "\t\t PB1: " + CalculateData.Probability1 +
                        "\t\t PB2: " + CalculateData.Probability1 +
                        "\t\t Fn: " + CalculateData.Function +
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
