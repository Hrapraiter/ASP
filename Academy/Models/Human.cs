using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Human
    {
        [Required]
        [StringLength(maximumLength:50 , MinimumLength = 2)]
        [RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Фамилия содержит недопустимые символы")]
        public string last_name { get; set; }
        [Required]
        [StringLength(maximumLength:50 , MinimumLength = 2)]
        [RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Имя содержит недопустимые символы")]
        public string first_name { get; set; }
        [StringLength(maximumLength:50 , MinimumLength = 2)]
        [RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Отчество содержит недопустимые символы")]
        public string? middle_name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateOnly), "1950-01-01", "2020-01-01")]
        public DateOnly birth_date { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public byte[]? photo { get; set; }

        //Calculated properties;
        public string FullName 
        {
            get => $"{last_name} {first_name} {middle_name}";
        }
        public int Age 
        {
            get => (int)((DateOnly.FromDateTime(DateTime.Now).DayNumber - birth_date.DayNumber)/365.25);
        }
    }
}
