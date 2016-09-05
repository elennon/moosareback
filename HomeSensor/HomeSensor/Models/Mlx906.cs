using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace HomeSensor.Models
{
    public class Mlx906 : Reading
    {
		//[DllImport("libtester.so", EntryPoint="frog")]
		[DllImport("eye2cso.so", EntryPoint="main")]

		static extern string frog(string message);
		static extern string main();

        public Guid _id { get; set; }
        public DateTime _time { get; set; }
        public double Tambi { get; set; }
        public double Tobj { get; set; }

        private static HttpClient client = new HttpClient();

		public void GetMlx9062()
		{
			string r = "";
  			try {
				var ft = main ();
				string hu = ft.ToString();
			} catch (Exception ex) {
				r = ex.Message;
			}

		}

        public async Task PostReading(Mlx906 rd)
        {
            client = new HttpClient();
            try
            {
                string resourceAddress = "http://192.168.43.49/moosareback/api/mlx906";
                //var gg = await client.GetStringAsync(resourceAddress);
                //Console.WriteLine("plop:  " + gg);
                string postBody = Common.JsonSerializer(rd);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync(resourceAddress, new StringContent(postBody, Encoding.UTF8, "application/json"));
                //Console.WriteLine("response:  " + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error:  " + ex.Message);
                string error2 = ex.Message;
            }
        }

		public async Task GetMlx906()
        {
            double val = 0;
            try
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "sh"; //"/etc/php5/cli/php.ini";
                start.Arguments = "/home/pi/src/eye2c";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                string line = "";
                
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            try
                            {
                                var ft = line;
                            }
                            catch (Exception ex)
                            {
                                string h = ex.Message;
                            }
                        }
                    }
                }
                //await PostReading(sdp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error:  " + ex.Message);
                string error2 = ex.Message;
            }
        }
    }
}
