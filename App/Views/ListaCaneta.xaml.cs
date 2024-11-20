using System.Collections.ObjectModel;
using System.Transactions;
using App.Models;

namespace App.Views;

public partial class ListaCaneta : ContentPage
{

	ObservableCollection<Caneta> lista = new ObservableCollection<Caneta>();
	public ListaCaneta()
	{
		InitializeComponent();

		listaProdutos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
		try
		{
			List<Caneta> tmp = await App.Db.GetAll();

			tmp.ForEach(x => lista.Add(x)); // Toda vez que a tela aparecer ele consulta o SQlite
		}
        catch (Exception ex)
        {
           await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NovaCaneta());

		}catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "Ok");
		}
    }

    private async void txt_Search_TextChanged(object sender, TextChangedEventArgs e)
	{
		try
		{
			string q = e.NewTextValue;

			lista.Clear();
			List<Caneta> tmp = await App.Db.Search(q);

			tmp.ForEach(x => lista.Add(x)); // Toda vez que a tela aparecer ele consulta o SQlite
		}catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		try
		{
			double soma = lista.Sum(i => i.Total);
			string msg = $"O total é {soma:C}";
			DisplayAlert("Total de Produtos", msg, "Ok");
		}
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			MenuItem selecionado = sender as MenuItem;
			Caneta c = selecionado.BindingContext as Caneta;
			bool confirm = await DisplayAlert("Tem certeza?", $"Remover {c.Fabricante}", "Sim", "Não");

			if (confirm)
			{
				await App.Db.Delete(c.Id);
				lista.Remove(c);
			}
		}
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void listaProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		try
		{
			Caneta c = e.SelectedItem as Caneta;
			Navigation.PushAsync(new Views.EditarCaneta
			{
				BindingContext = c,

			});

		}
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}