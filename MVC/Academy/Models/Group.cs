using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Group
    {
        [Key]
        public int group_id { get; set; }
        [Required]
        [DisplayName("Название группы")]
        [StringLength(maximumLength:10 , MinimumLength = 2)]
        public string group_name { get; set; }
        [Column(TypeName = "TINYINT")]
        [DisplayName("Направление обучения")]
        public int direction { get; set; }
        [DisplayName("Дата старта группы")]
        public DateOnly? start_date { get; set; }
        [DisplayName("Время старта группы")]
        public TimeOnly? start_time { get; set; }
        [DisplayName("Учебные дни")]
        [Column(TypeName = "TINYINT")]
        public int? learning_days { get; set; }

        //Calculated properties:
        

    }
}
