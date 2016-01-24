using System.ComponentModel.DataAnnotations.Schema;

namespace PollInTheAir.Domain.Models
{
    [ComplexType]
    public class Location
    {
        [Column("Latitude")]
        public float Latitude { get; set; }

        [Column("Longitude")]
        public float Longitude { get; set; }
    }
}
