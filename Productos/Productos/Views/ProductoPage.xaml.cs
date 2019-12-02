using Productos.Models;
using Productos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Productos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoPage : ContentPage
    {
        bool isNewItem;
        public ProductoPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (Producto)BindingContext;
            await App.ProductoManager.SaveTaskAsync(todoItem, isNewItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todoItem = (Producto)BindingContext;
            await App.ProductoManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}