using App.ViewModels;
using App.Views;

namespace App
{
    public partial class App : Application
    {
        static SQLiteDataBase _db;

        public static SQLiteDataBase Db
        {
            get
            {
                if (_db == null)
                {// Fazendo a busca pelo caminho do db em multiplataformas
                    string caminho = Path.Combine( 
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"banco_sqlite_compras.db3");

                    _db = new SQLiteDataBase(caminho);
                }

                return _db;
            }
        }
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new ListaCaneta()));
        }
    }
}
