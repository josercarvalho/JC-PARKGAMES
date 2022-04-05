using System;

namespace JC_PARK.Web.MVC.ViewModels
{
    public class EventoUsuarioVM
    {
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public bool Ativo { get; set; }
    }
}