using System;

public class Transacao
{
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public string Tipo { get; set; }
    public DateTime Data { get; set; }
    public int CategoriaId { get; set; }
}