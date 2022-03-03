namespace CadastroVeiculos.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public string Marca { get; set; }
        public string CpfCnpj { get; set; }
        public string Placa { get; set; }
    }
}