using App.Models;
using SQLite;

namespace App.ViewModels
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        public SQLiteDataBaseHelper(string path) 
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Caneta>().Wait();
        }

        public Task<int> Insert(Caneta c)
        {
            return _conn.InsertAsync(c);
        }

        public Task<List<Caneta>> Update(Caneta c)
        {
            string sql = "UPDATE Caneta SET Cor=?, Preco=?, Fabricante=? WHERE Id=?";
            return _conn.QueryAsync<Caneta>(
                sql, c.Cor, c.Fabricante, c.Preco, c.Id // Mostrando para o return qual os parametros da string SQL
                );
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Caneta>().DeleteAsync(i => i.Id == id); // Selecionando a id que queremos deletar 
        }

        public Task<List<Caneta>> GetAll()
        {
            return _conn.Table<Caneta>().ToListAsync();
        }

        public Task<List<Caneta>> Search(string q)// q de query
        {
            string sql = "SELECT * Caneta WHERE Fabricante LIKE '%" + q + "%'";
            return _conn.QueryAsync<Caneta>(sql);
        } 


    }
}
