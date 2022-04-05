using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Domain.Interfaces.Repositories
{
    public interface IRepositorioDeEventoUsuario : IRepositorioBase<EventoUsuario>
    {
        EventoUsuario RecuperarPorUsuario(int usuario);
        void DesativaUsuario(int usuario, int evento);
        bool RemoverUsuario(int usuario, int evento);
        IEnumerable<EventoUsuario> BuscarEventos(int usuario);
        IEnumerable<EventoUsuario> BuscarUsuarios(int evento);
    }
}
