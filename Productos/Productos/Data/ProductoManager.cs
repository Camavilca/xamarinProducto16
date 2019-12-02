using Productos.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Data
{
    public class ProductoManager
    {
        IRestService restService;

        public ProductoManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Producto>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Producto producto, bool isNewItem = false)
        {
            return restService.SaveProductoAsync(producto, isNewItem);
        }

        public Task DeleteTaskAsync(Producto producto)
        {
            return restService.DeleteProductoAsync(producto.id);
        }

    }
}
