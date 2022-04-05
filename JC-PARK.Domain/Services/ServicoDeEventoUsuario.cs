using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace JC_PARK.Domain.Services
{
    public class ServicoDeEventoUsuario : ServicoBase<EventoUsuario>, IServicoDeEventoUsuario
    {
        private readonly IRepositorioDeEventoUsuario _repositorioDeEventoUsuario;

        public ServicoDeEventoUsuario(IRepositorioDeEventoUsuario repositorio) 
            : base(repositorio)
        {
            _repositorioDeEventoUsuario = repositorio;
        }

        public void DesativaUsuario(int usuario, int evento)
        {
            _repositorioDeEventoUsuario.DesativaUsuario(usuario, evento);
        }

        public EventoUsuario RecuperarPorUsuario(int id)
        {
            return _repositorioDeEventoUsuario.RecuperarPorUsuario(id);
        }

        public bool RemoverUsuario(int usuario, int evento)
        {
            return _repositorioDeEventoUsuario.RemoverUsuario(usuario, evento);
        }
        public IEnumerable<EventoUsuario> BuscarEventos(int usuario)
        {
            return _repositorioDeEventoUsuario.BuscarEventos(usuario);
        }

        public IEnumerable<EventoUsuario> BuscarUsuarios(int evento)
        {
            return _repositorioDeEventoUsuario.BuscarUsuarios(evento);
        }
    }
}
