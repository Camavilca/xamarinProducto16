using Xamarin.Forms;

namespace Productos
{
    public static class Constants
    {
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://vast-mesa-46138.herokuapp.com" : "https://vast-mesa-46138.herokuapp.com";
        public static string TodoItemsUrl = BaseAddress + "/api/notes/{0}";
    }

}
