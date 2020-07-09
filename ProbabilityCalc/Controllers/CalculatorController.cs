using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProbabilityCalc.Models;

namespace ProbabilityCalc.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            var calculatorModel = new CalculatorModel();
            var CommonVariables = new Common.CommonVariables();
            ViewBag.FunctionList = CommonVariables.FunctionList();
            return View(calculatorModel);
        }

        [HttpPost]
        public JsonResult CalculateProbability(CalculatorModel calculatorModel)
        {
            try
            {
                var CommonVariables = new Common.CommonVariables();
                var Result = CommonVariables.CalculateData(calculatorModel);
                var CalculatedData = calculatorModel.Probability1;
                return Json(new { IsSucess = true, Result = Result });
            }
            catch (Exception ex)
            {
                return Json(new { IsSucess = false });
            }
        }
    }
}