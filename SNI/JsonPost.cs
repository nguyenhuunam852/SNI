using Newtonsoft.Json;
using SNI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNI
{
    class rsJson
    {
        public String status;
        public String message;
    }
    class JsonPost
    {
        public static int PostAPI(DateTime date)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(FileConfig.config.reportapi);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromSeconds(30.0);

                string dt = date.Year + "/" + date.Month + "/" + date.Day;
                HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
                var rp = ReportController.getReportbyDay(date);
                var response = client.PostAsync("?apptoken=" + FileConfig.config.apptoken + "&usetoken=" + FileConfig.config.usertoken + "&totalcustomer=" + rp.amountofactivecustomer + "&totalnewcustomer=" + rp.amountofnewcustomer + "&date=" + dt + "&grouptoken=" + FileConfig.config.codeGroup, content).Result;
                var stringres = response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<rsJson>(stringres.Result);
                if (result.status == "True")
                {
                    ReportController.servercheck(date);
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
