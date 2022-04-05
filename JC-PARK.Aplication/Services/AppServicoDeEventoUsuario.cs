using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;
using JC_PARK.Aplication.Interface;
using System;
using System.Collections.Generic;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDeEventoUsuario : AppServicoBase<EventoUsuario>, IAppServicoDeEventoUsuario
    {
        private readonly IServicoDeEventoUsuario _servicoDeEventoUsuario;

        public AppServicoDeEventoUsuario(IServicoBase<EventoUsuario> serviceBase, IServicoDeEventoUsuario servicoDeEventoUsuario) 
            : base(serviceBase)
        {
            _servicoDeEventoUsuario = servicoDeEventoUsuario;
        }

        public void DesativaUsuario(int usuario, int evento)
        {
            _servicoDeEventoUsuario.DesativaUsuario(usuario, evento);
        }

        public EventoUsuario RecuperarPorUsuario(int id)
        {
            return _servicoDeEventoUsuario.RecuperarPorUsuario(id);
        }

        public bool RemoverUsuario(int usuario, int evento)
        {
            return _servicoDeEventoUsuario.RemoverUsuario(usuario, evento);
        }
        public IEnumerable<EventoUsuario> BuscarEventos(int usuario)
        {
            return _servicoDeEventoUsuario.BuscarEventos(usuario);
        }

        public IEnumerable<EventoUsuario> BuscarUsuarios(int evento)
        {
            return _servicoDeEventoUsuario.BuscarUsuarios(evento);
        }
    }
}
