namespace CadastroVeiculos.Domain.Entities
{
    public class Proprietario : BaseEntity
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Endereco { get; set; }
    }
}
