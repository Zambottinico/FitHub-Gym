using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitHub.Models
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Dni {  get; set; }
        public int SubscriptionId { get; set; }

        [ForeignKey("SubscriptionId")]
        public virtual Subscription Subscription { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
