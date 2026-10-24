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
        [ForeignKey(nameof(Direction))]
        public int direction { get; set; }

        [DisplayName("Дата старта группы")]
        public DateOnly? start_date { get; set; }

        [DisplayName("Время старта группы")]
        public TimeOnly? start_time { get; set; }

        [DisplayName("Учебные дни")]
        [Column(TypeName = "TINYINT")]
        public int? learning_days { get; set; }



        //Calculated properties:
        [DisplayName("Учебные дни")]
        public string LearningDaysDescription 
        {
            get 
            {
                string output = "";
                if ((learning_days & 1) > 0)    output += "Пн "; 
                if ((learning_days & 1<<1) > 0) output += "Вт "; 
                if ((learning_days & 1<<2) > 0) output += "Ср "; 
                if ((learning_days & 1<<3) > 0) output += "Чт "; 
                if ((learning_days & 1<<4) > 0) output += "Пт "; 
                if ((learning_days & 1<<5) > 0) output += "Сб "; 
                if ((learning_days & 1<<6) > 0) output += "Вс ";
                
                return output;
            }
        }
        //Navigation properties:
        public Direction Direction { get; set; }

    }
}
