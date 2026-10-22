using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Academy.MyDataAnnotations;
namespace Academy.Models
{
    public class Human
    {
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Фамилия")]
        public string last_name { get; set; }
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Имя")]
        public string first_name { get; set; }
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Отчество")]
        public string? middle_name { get; set; }
        [DateDynamicRange(dateSubtractMax = "0100-01-01" , dateSubtractMin = "0015-01-01")]
        [DisplayName("Дата рождения")]
        public DateOnly birth_date { get; set; }
        public string? email { get; set; }
        [DisplayName("Тел. номер")]
        public string? phone { get; set; }
        public byte[]? photo { get; set; }

        // Calculated properties

        [DisplayName("ФИО")]
        public string FullName { get => $"{last_name} {first_name} {middle_name}"; }
    }
}
