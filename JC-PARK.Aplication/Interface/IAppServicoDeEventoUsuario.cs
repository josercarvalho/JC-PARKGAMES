using JC_PARK.Domain.Entities;
using System.Collections.Generic;

namespace JC_PARK.Aplication.Interface
{
    public interface IAppServicoDeEventoUsuario : IAppServicoBase<EventoUsuario>
    {
        EventoUsuario RecuperarPorUsuario(int id);
        void DesativaUsuario(int usuario, int evento);
        bool RemoverUsuario(int usuario, int evento);
        IEnumerable<EventoUsuario> BuscarEventos(int usuario);
        IEnumerable<EventoUsuario> BuscarUsuarios(int evento);

    }
}
