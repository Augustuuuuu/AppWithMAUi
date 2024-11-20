using SQLite;

namespace App.Models
{
    public class Caneta
    {
        string _fabricante;
        string _cor;
        double _preco;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Fabricante 
        {
            get => _fabricante;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o Fabricante!");
                }
                _fabricante = value;
            }
         }
        public string Cor
        {
            get => _cor;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a Cor!");
                }
                _cor = value;
            }

        }
        public double Preco 
        {
            get => _preco;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Por favor, preencha o Preço!");
                }
                _preco = value;
            }
        }

        public double Total { get => Preco; }
    }
}
