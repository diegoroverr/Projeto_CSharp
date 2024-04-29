namespace Aplicacao.Models
{    
    public class Reserva 
    {
        public int Id { get; set; }
        public int Quarto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int NumeroDaReserva { get; set; }
    }
}