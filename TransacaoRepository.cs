using MySqlConnector;
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
} 