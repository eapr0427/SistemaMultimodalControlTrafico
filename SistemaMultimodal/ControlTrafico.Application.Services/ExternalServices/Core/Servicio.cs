using ControlTrafico.Application.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace ControlTrafico.Application.Services.Core
{
    public class Servicio<T>
    {
        public async Task<T> MapearServicio(ServicioRest infoService, string payload = null)
        {
            T entity;
            string content = await GetInfoServicio(infoService, payload);
            entity = JsonConvert.DeserializeObject<T>(content);
            return entity;
        }

        private async Task<string> GetInfoServicio(ServicioRest infoService, string payload = null)
        {
            try
            {
                var stringresponse = string.Empty;
                var request = JsonConvert.SerializeObject(infoService.Raw);
                var content = new StringContent(request, Encoding.UTF8, infoService.ContentType);
                var client = new HttpClient
                {
                    BaseAddress = new Uri(infoService.UrlBase)
                };

                var url = $"{infoService.ServicePrefix}{infoService.Controller}";
                try
                {
                    HttpResponseMessage response = null;
                    if (payload == null)
                    {
                        response = await client.GetAsync(url);
                    }
                    else
                    {
                        response = await client.PostAsync(url, new StringContent(payload));
                    }
                    
                    if (response.IsSuccessStatusCode)
                    {
                        stringresponse = await response.Content.ReadAsStringAsync();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return stringresponse;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
