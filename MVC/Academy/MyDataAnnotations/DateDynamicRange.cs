using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
namespace Academy.MyDataAnnotations
{
    public class DateDynamicRange: ValidationAttribute
    {
        public string dateSubtractMin { get; set; }
        public string dateSubtractMax { get; set; }
        protected override ValidationResult IsValid(object? value , ValidationContext context)
        {
            DateTime _value;
            DateTime today = DateTime.Now;
            DateTime min = DateTime.MinValue;
            DateTime max = DateTime.MaxValue;
            DateTime temp;
            string partError = "";
            try
            {
                partError = "date failed parsing ";
                _value = Convert.ToDateTime(value.ToString());

                partError = "dateSubstractMax failed parsing ";
                temp = Convert.ToDateTime(dateSubtractMax);
                max = today.AddYears(-temp.Year).AddMonths(-(temp.Month-1)).AddDays(-(temp.Day-1));

                partError = "dateSubstractMin failed parsing ";
                temp = Convert.ToDateTime(dateSubtractMin);
                min = today.AddYears(-temp.Year).AddMonths(-(temp.Month-1)).AddDays(-(temp.Day-1));
            }
            catch (Exception exection)
            {
                return new ValidationResult($"{partError} \nException: {exection}");
            }
            if (_value <= min && _value >= max)
                return ValidationResult.Success;
            else
                return new ValidationResult($"Допустимые значения от {max.ToShortDateString()} до {min.ToShortDateString()}");
        }
    }
}
