using System;
using System.Collections.Generic;
using JC_PARK.Aplication.Interface;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Services;

namespace JC_PARK.Aplication.Services
{
    public class AppServicoDePonto : AppServicoBase<Ponto>, IAppServicoDePonto
    {
        private readonly IServicoDePonto _servicoDePonto;
        private readonly IServicoDeEventoUsuario _ServicoDeEventoUsuario;
        public AppServicoDePonto(IServicoDePonto servicoDePonto, IServicoDeEventoUsuario ServicoDeEventoUsuario) : base(servicoDePonto)
        {
            _servicoDePonto = servicoDePonto;
            _ServicoDeEventoUsuario = ServicoDeEventoUsuario;
        }

        public void BaterPonto(int usuario, int evento)
        {
            var ponto = BuscarUsuarioPorEvento(usuario, evento);
            if (ponto == null)
            {
                var pontoUsuario = new Ponto
                {
                    UsuarioId = usuario,
                    EventoId = evento,
                    DataCadastro = DateTime.Now.Date,
                    HoraEntrada = DateTime.Now
                };
                _servicoDePonto.Inserir(pontoUsuario);
            }
            else
            {
                ponto.HoraSaida = DateTime.Now;
                _servicoDePonto.Alterar(ponto);
            }

        }

        public Ponto BuscarPonto(int usuario, int evento, DateTime dia)
        {
            return _servicoDePonto.BuscarPonto(usuario, evento, dia);
        }

        public Ponto BuscarUsuarioPorEvento(int usuario, int evento)
        {
            return _servicoDePonto.BuscarUsuarioPorEvento(usuario, evento);
        }

        public bool ChecaSaida(int usuario, int evento, DateTime hora)
        {
            var pontobatido = _ServicoDeEventoUsuario.RecuperarPorUsuario(usuario);

            //if (pontobatido == null)
            //{
            //    return false;
            //}

            if (pontobatido.HoraSaida != null)
            {
                throw new ApplicationException("Ponto já foi batido");
                //throw new Exception("Ponto já foi batido");
            }

            if (pontobatido.HoraSaida < hora)
            {
                throw new Exception("Horário inválido. Tente mais tarde!");
            }
            return true;
        }

    }
}
