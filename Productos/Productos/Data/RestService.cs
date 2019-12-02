using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Productos.Models;

namespace Productos.Data
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public List<Producto> Productos { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Producto>> RefreshDataAsync()
        {
            Productos = new List<Producto>();

            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));


            try
            {
                var response = await _client.GetAsync(uri);

                Debug.WriteLine("response _________________________");
                Debug.WriteLine(response);
                Debug.WriteLine("_________________________ response");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Productos = JsonConvert.DeserializeObject<List<Producto>>(content);
                    Debug.WriteLine("CANTIDAD _________________________");
                    Debug.WriteLine(content);
                    Debug.WriteLine(Productos);
                    Debug.WriteLine("_________________________ CANTIDAD");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }




            return Productos;

        }

        public async Task SaveProductoAsync(Producto producto, bool isNewItem)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));
            Debug.WriteLine("uri _________________________");
            Debug.WriteLine(uri);
            Debug.WriteLine("_________________________ uri");


            try
            {

                producto.id = "";
                var json = JsonConvert.SerializeObject(producto);

                Debug.WriteLine("json _________________________");
                Debug.WriteLine(json);
                Debug.WriteLine("_________________________ json");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

        }

        public async Task DeleteProductoAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

        }
    }
}
