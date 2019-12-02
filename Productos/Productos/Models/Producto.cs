using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Productos.Models
{

    public class Producto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
    }

}
