namespace App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {

                string nomeCaneta = txt_Caneta.Text;
                double precoCaneta = Convert.ToDouble(txt_Preco.Text);
                string msg = "";
                if (precoCaneta < 5)
                {
                    msg = "Caneta BARATA";
                }
                else
                {
                    msg = "Caneta Cara";
                }
                DisplayAlert("Adicionado", msg, "Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Fechar");
            }
        } // Fecha método

    }// Fecha Class

}// Fecha namespace
