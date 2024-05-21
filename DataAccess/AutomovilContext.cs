using DataAccess.Interfaces;
using Infrastructure.Models;
using MySql.Data.MySqlClient;

namespace DataAccess;

public class AutomovilContext : IRepository{
    private readonly string _conn_string;

    public AutomovilContext(string conn_string)
    {
        
        _conn_string =conn_string;
    }

    public void InsertData(IEnumerable<Automovil> automoviles){
        
        using (var connection = new MySqlConnection(_conn_string))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandText = 
                        "insert into Automovil values (@Id, @Modelo, @Descripcion,@Precio,@Kilometraje,@Marca)";
                        try
                        {
                            foreach (var item in automoviles)
                            {
                                command.Parameters.AddWithValue("@Id", item.Id);
                                command.Parameters.AddWithValue("@Modelo", item.Modelo);
                                command.Parameters.AddWithValue("@Descripcion",item.Descripcion);
                                command.Parameters.AddWithValue("@Precio",item.Precio);
                                command.Parameters.AddWithValue("@Kilometraje",item.Kilometraje);
                                command.Parameters.AddWithValue("@Marca",item.Marca.Id);
                                command.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            connection.Close();
                            throw;
                        }
                    }
                }
            }
    }
}