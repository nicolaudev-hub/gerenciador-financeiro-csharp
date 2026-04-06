using MySqlConnector;
public class Conexao
{
    private string connectionString = "server=localhost;database=financas;user=root;password=Root123;";
    public MySqlConnection ObterConexao()
    {
        return new MySqlConnection(connectionString);
    }
}
