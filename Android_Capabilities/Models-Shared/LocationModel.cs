namespace Android_Capabilities.Models
{
    public class LocationModel
	{
		public int ProcessId { get; set; }

		public int UserId { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

        public double Altitude { get; set; }

        public DateTime DateTime { get; set; }

		public float Speed { get; set; }

        public string Provider { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}

