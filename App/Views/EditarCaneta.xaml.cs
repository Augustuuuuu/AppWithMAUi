using App.Models;

namespace App.Views;

public partial class EditarCaneta : ContentPage
{
	public EditarCaneta()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Caneta caneta_anexada = BindingContext as Caneta;
            Caneta c = new Caneta
            {
                Id = caneta_anexada.Id,
                Fabricante = txt_Fabricante.Text,
                Cor = cor_Caneta.Text,
                Preco = Convert.ToDouble(preco_Caneta.Text),
            };

            await App.Db.Update(c);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "Ok");
            await Navigation.PopAsync(); // Voltar a tela de origem
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}