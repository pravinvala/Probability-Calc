using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProbabilityCalc.Models;
using ProbabilityCalc.Repository;

namespace ProbabilityCalc.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICommonRepository commonRepository;
        public IConfiguration config { get; }
        public CalculatorController(ICommonRepository _commonRepository, IConfiguration _config)
        {
            commonRepository = _commonRepository;
            config = _config;
        }
        public IActionResult Index()
        {
            Dictionary<string, string> FunctionList = config.GetSection("FunctionList").Get<Dictionary<string, string>>();
            ViewBag.FunctionList = FunctionList;
            return View();
        }

        [HttpPost]
        public JsonResult CalculateProbability(CalculatorModel calculatorModel)
        {
            ResultClass<decimal> result = new ResultClass<decimal>() { IsSuccess = true };
            try
            {
                result = commonRepository.CalculateData(calculatorModel);
                return Json(new { result.Message, result.IsSuccess, result.Result });
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return Json(new { result.Message, result.IsSuccess });
            }
        }
    }
}