using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProbabilityCalc.Models;
using ProbabilityCalc.Repository;

namespace ProbabilityCalc.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICommonRepository commonRepository;
        public CalculatorController(ICommonRepository _commonRepository)
        {
            commonRepository = _commonRepository;
        }
        public IActionResult Index()
        {
            ViewBag.FunctionList = commonRepository.FunctionList();
            return View();
        }

        [HttpPost]
        public JsonResult CalculateProbability(CalculatorModel calculatorModel)
        {
            try
            {
                var Result = commonRepository.CalculateData(calculatorModel);
                return Json(new { IsSucess = true, Result = Result });
            }
            catch (Exception ex)
            {
                return Json(new { IsSucess = false });
            }
        }
    }
}