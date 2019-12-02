using Productos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Productos.Data
{
    public interface IRestService
    {
        Task<List<Producto>> RefreshDataAsync();

        Task SaveProductoAsync(Producto producto, bool isNewItem);

        Task DeleteProductoAsync(string id);
    }

}
