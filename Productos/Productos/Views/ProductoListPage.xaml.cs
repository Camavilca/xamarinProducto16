using Productos.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Productos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoListPage : ContentPage
    {
        public ProductoListPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.ProductoManager.GetTasksAsync();
        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductoPage(true)
            {
                BindingContext = new Producto
                {
                    id = Guid.NewGuid().ToString()
                }
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ProductoPage
            {
                BindingContext = e.SelectedItem as Producto
            });
        }

    }
}