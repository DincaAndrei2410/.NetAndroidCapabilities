using Android_Capabilities.Models;

namespace Android_Capabilities.Services
{
	public class FileService
	{
		readonly string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "location_logs.txt");

        public async Task<bool> WriteLocationToFile(LocationModel locationModel)
		{
			bool succes = false;

			try
			{
				using (var sw = new StreamWriter(filePath, true))
				{
					await sw.WriteLineAsync(locationModel.ToString());
					succes = true;
                }
			}
			catch
			{
                //log exception
            }

            return succes;
		}

		public async Task<List<LocationModel>> ReadLocationsFromFile()
		{
            var lines = new List<LocationModel>();

            try
            {
                using (var sw = new StreamReader(filePath))
                {
					while (!sw.EndOfStream)
					{
						var logLine = await sw.ReadLineAsync();
						var location = Newtonsoft.Json.JsonConvert.DeserializeObject<LocationModel>(logLine);
                        lines.Add(location);
					}
                }
            }
            catch
            {
				//log exception
            }

			return lines.OrderByDescending(l => l.DateTime).Take(50).ToList();
        }
	}
}

