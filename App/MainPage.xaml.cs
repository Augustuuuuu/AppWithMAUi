namespace App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Views.ListaCaneta());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Ok");
            
            }


        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Views.NovaCaneta());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Ok");

            }
        }
    }

}
