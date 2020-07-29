using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProbabilityCalc.Models
{
    public class CalculatorModel
    {
        [Required(ErrorMessage ="Probability 1 required")]
        [RegularExpression(@"^(0(\.\d+)?|1(\.0+)?)$",ErrorMessage ="Probability 1 must have value between 0 to 1")]
        public decimal Probability1 { get; set; }
        [Required(ErrorMessage = "Probability 2 required")]
        [RegularExpression(@"^(0(\.\d+)?|1(\.0+)?)$", ErrorMessage = "Probability 2 must have value between 0 to 1")]
        public decimal Probability2 { get; set; }
        [Required(ErrorMessage ="Function must have value")]
        public string Function { get; set; }
    }
}
