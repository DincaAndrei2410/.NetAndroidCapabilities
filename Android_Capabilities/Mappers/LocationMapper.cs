using System;
using Android_Capabilities.Models;

namespace Android_Capabilities.Mappers
{
	public class LocationMapper
	{
		public static LocationModel Map(Android.Locations.Location location, int pid, int uid)
		{
			var model = new LocationModel()
			{
				ProcessId = pid,
				UserId = uid,
				Latitude = location.Latitude,
				Longitude = location.Longitude,
				Altitude = location.Altitude,
				DateTime = new DateTime(1970, 1, 1).AddMilliseconds(location.Time),
				Speed = location.Speed,
				Provider = location.Provider,
			};

			return model;
		}
	}
}

