namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Location
    {
        [Column("Latitude")]
        public float Latitude { get; set; }

        [Column("Longitude")]
        public float Longitude { get; set; }
    }
}
