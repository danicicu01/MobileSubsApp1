using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobileSubsApp.Models
{
    public class Subscription
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Price (Lei)")]
        public float Price { get; set; }

        [Required]
        [DisplayName("National Calls")]
        public string NationalCalls { get; set; }

        [Required]
        [DisplayName("International Calls")]
        public string InternationalCalls { get; set; }

        [Required]
        public string Internet { get; set; }

        [Required]
        public bool Roaming { get; set; }



    }
}
