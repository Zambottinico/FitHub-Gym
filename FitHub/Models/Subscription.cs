using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitHub.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate
        {
            get; set;
        }
        public int SubscriptionTypeId { get; set; }

        [ForeignKey("SubscriptionTypeId")]
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
