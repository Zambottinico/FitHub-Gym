using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitHub.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime AttendanceDate { get; set; }

        

        [ForeignKey("Member")]
        public int MemberId { get; set; }

        public virtual Member Member { get; set; }
    }
}
