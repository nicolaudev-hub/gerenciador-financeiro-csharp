using MySqlConnector;
public class Conexao
{
    private string connectionString = "Server=localhost;Database=financas;Uid=root;Pwd=Root123;Charset=utf8;";
    public MySqlConnection ObterConexao()
    {
        return new MySqlConnection(connectionString);
    }
}
