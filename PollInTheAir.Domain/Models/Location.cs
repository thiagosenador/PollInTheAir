namespace PollInTheAir.Domain.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Location
    {
        public Location()
        {
        }

        public Location(float latitude, float longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        [Column("Latitude")]
        public float Latitude { get; set; }

        [Column("Longitude")]
        public float Longitude { get; set; }
    }
}
