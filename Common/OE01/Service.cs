
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using static System.Net.WebRequestMethods;
using Telerik.SvgIcons;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Telerik.Blazor.Components;
using BlazorOE01.Pages;

namespace BlazorOE01.Common.OE01

{
    

    public class Service
    {

        bool Visible { get; set; }
        string Message { get; set; }
        async Task GenerateReport()
        {
            Message = "Generando reporte...";
            Visible = true;
            Task.Delay(6000);
        }

        public async Task CreateHandler(GridCommandEventArgs args)
        {
            string baseURL = "http://192.168.10.54:8810/Ordenes/rest/DEMOOE1Service/Invoice";


            var arsItem = (Ttinvoice)args.Item;

            var rootObject = new Rootobject
            {
                dsGeneral = new Dsgeneral
                {
                    ttinvoice = new Ttinvoice[] { arsItem }
                }
            };


            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(baseURL, rootObject);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    // await MostrarDatos();
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    var rootObject1 = JsonConvert.DeserializeObject<Ttestados>(jsonResponse);



                }
            }



        }

        public async Task UpdateHandler(GridCommandEventArgs args)
        {
            string baseURL = "http://192.168.10.54:8810/Ordenes/rest/DEMOOE1Service/Invoice";


            var arsItem = (Ttinvoice)args.Item;

            var rootObject = new Rootobject
            {
                dsGeneral = new Dsgeneral
                {
                    ttinvoice = new Ttinvoice[] { arsItem }
                }
            };


            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsJsonAsync(baseURL, rootObject);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    await MostrarDatos();
                }
            }


        }

        public async Task DeleteHandler(GridCommandEventArgs args)
        {

            var arsItem = (Ttinvoice)args.Item;
            int dr = arsItem.Invoicenum;
            int dr2 = arsItem.CustNum;
            int dr3 = arsItem.OrderNum;
            string cadena = dr.ToString();

            string baseURL = $"http://192.168.10.54:8810/Ordenes/rest/DEMOOE1Service/Invoice?wId={dr}&wId2={dr2}&wId3={dr3}";

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(baseURL);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    await MostrarDatos();
                }
            }
        }
        int txtTop { get; set; } = 0;

        public List<Ttinvoice> ttInvoices { get; set; }


        protected async Task MostrarDatos()
        {
            ttInvoices = await GetInvoice(txtTop);
        }

        private async Task<List<Ttinvoice>> GetInvoice(int itop)
        {

            GenerateReport();
            List<Ttinvoice> ttInvoices = new();
            string baseURL = "http://192.168.10.54:8810/Ordenes/rest/DEMOOE1Service/";


            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseURL);

                if (itop == 0)
                {
                    {
                        var request1 = await http.GetAsync($"Invoice");

                        if (request1.IsSuccessStatusCode)
                        {
                            var response = await request1.Content.ReadFromJsonAsync<Rootobject>();
                            ttInvoices = response.dsGeneral.ttinvoice.ToList();

                            Visible = false;
                            Message = "Tu reporte ha sido generado con exito.";

                        }

                    }
                }
                else
                {
                    {
                        var request1 = await http.GetAsync($"Invoice?itop={itop}");

                        if (request1.IsSuccessStatusCode)
                        {
                            var response = await request1.Content.ReadFromJsonAsync<Rootobject>();

                            ttInvoices = response.dsGeneral.ttinvoice.ToList();

                            Visible = false;
                            Message = "Tu registro ha sido encontrado con exito.";




                        }

                    }



                }

            }

            return ttInvoices;
        }



    }
}