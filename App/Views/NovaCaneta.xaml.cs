using App.Models;

namespace App.Views;

public partial class NovaCaneta : ContentPage
{
	public NovaCaneta()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			Caneta c = new Caneta
			{
				Fabricante = txt_Fabricante.Text,
				Cor = cor_Caneta.Text,
				Preco = Convert.ToDouble(preco_Caneta.Text),
			};

			await App.Db.Insert(c);
			await DisplayAlert("Sucesso!", "Registro Inserido", "Ok");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Ok");
		}
    }
}