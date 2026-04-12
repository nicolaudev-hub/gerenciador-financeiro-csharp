using MySqlConnector;
using System.Data;
public class TransacaoRepository
{
    private Conexao conexao = new Conexao();
    public void Adicionar(Transacao t)
    {
        using (var conn = conexao.ObterConexao())
        {
            conn.Open();
            string query = "INSERT INTO transacoes (descricao, valor, tipo, data, categoria_id) VALUES (@d, @v, @t, @dt, @c)";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@d", t.Descricao);
            cmd.Parameters.AddWithValue("@v", t.Valor);
            cmd.Parameters.AddWithValue("@t", t.Tipo);
            cmd.Parameters.AddWithValue("@dt", t.Data);
            cmd.Parameters.AddWithValue("@c", t.CategoriaId);

            cmd.ExecuteNonQuery();
        }
    }
    public void Deletar(int id)
    {
        using (var conn = conexao.ObterConexao())
        {
            conn.Open();
            string query = "DELETE FROM transacoes WHERE id = @id";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
    public DataTable Listar()
    {
        using (var conn = conexao.ObterConexao())
        {
            conn.Open();
            string query = "SELECT id, descricao, valor, tipo, data FROM transacoes";

            var cmd = new MySqlCommand(query, conn);
            var adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
}
