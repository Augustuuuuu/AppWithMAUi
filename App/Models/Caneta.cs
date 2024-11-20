using SQLite;

namespace App.Models
{
    public class Caneta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Fabricante { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set;}
    }
}
