using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTrafico.ExternalServices.Core
{
    public class ServicioRest
    {
        public string ServicePrefix { get; set; }
        public string Controller { get; set; }
        public string UrlBase { get; set; }
        public string Method { get; set; }
        public string Credentials { get; set; }
        public string ContentType { get; set; }
        public string Raw { get; set; }
    }
}
