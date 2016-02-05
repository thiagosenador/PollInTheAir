namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Location
    {
        [Required]
        [Column("Latitude")]
        public float Latitude { get; set; }

        [Required]
        [Column("Longitude")]
        public float Longitude { get; set; }
    }
}
