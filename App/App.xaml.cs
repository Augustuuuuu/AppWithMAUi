using App.Views;

namespace App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Substitua AppShell por NavigationPage
            return new Window(new NavigationPage(new ListaCaneta()));
        }
    }
}
