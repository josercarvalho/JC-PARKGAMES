using CommonServiceLocator.SimpleInjectorAdapter;
using JC_PARK.Aplication.Interface;
using JC_PARK.Aplication.Services;
using JC_PARK.Domain.Services;
using JC_PARK.Infra.Data.EntityConfig;
using JC_PARK.Infra.Data.Repositories;
using JC_PARK.Domain.Interfaces.Infra;
using JC_PARK.Domain.Interfaces.Repositories;
using JC_PARK.Domain.Interfaces.Services;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace JC_PARK.Infra.CrossCutting.IoC
{
    public class Bindings
    {
        /// <summary>
        /// Install-Package SimpleInjector
        /// Install-Package CommonServiceLocator -Version 1.3.0
        /// Install-Package CommonServiceLocator.SimpleInjectorAdapter
        /// </summary>
        public static void Start(Container container)
        {
            //Infrastrutura Repositorio
            container.Register<IGerenciadorDeRepositorio, GerenciadorDeRepositorio>();
            container.Register<IUnidadeDeTrabalho, UnidadeDeTrabalhoEF>();
            container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeUsuarios), typeof(RepositorioDeUsuarios), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDePerfilDeUsuario), typeof(RepositorioDePerfilDeUsuario), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDaEmpresa), typeof(RepositorioDaEmpresa), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeEventos), typeof(RepositorioDeEventos), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeDespesas), typeof(RepositorioDeDespesas), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeEventoUsuario), typeof(RepositorioDeEventoUsuario), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeClientes), typeof(RepositorioDeClientes), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeClienteEvento), typeof(RepositorioDeClienteEvento), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeEtiqueta), typeof(RepositorioDeEtiqueta), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeTipoValor), typeof(RepositorioDeTipoValor), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDeValores), typeof(RepositorioDeValores), Lifestyle.Scoped);
            container.Register(typeof(IRepositorioDePonto), typeof(RepositorioDePonto), Lifestyle.Scoped);

            //Serviços de Dominio
            container.Register(typeof(IServicoBase<>), typeof(ServicoBase<>), Lifestyle.Scoped);
            container.Register(typeof(IServicoDeUsuario), typeof(ServicoDeUsuario), Lifestyle.Scoped);
            container.Register(typeof(IServicoDaEmpresa), typeof(ServicoDaEmpresa), Lifestyle.Scoped);
            container.Register(typeof(IServicoDaEtiqueta), typeof(ServicoDaEtiqueta), Lifestyle.Scoped);
            container.Register(typeof(IServicoDeDespesas), typeof(ServicoDeDespesas), Lifestyle.Scoped);
            container.Register(typeof(IServicoDeEventos), typeof(ServicoDeEventos), Lifestyle.Scoped);
            container.Register(typeof(IServicoDeEventoUsuario), typeof(ServicoDeEventoUsuario), Lifestyle.Scoped);
            container.Register(typeof(IServicoDeCliente), typeof(ServicoDeCliente), Lifestyle.Scoped);
            container.Register(typeof(IServicoDePerfilUsuario), typeof(ServicoDePerfilUsuario), Lifestyle.Scoped);
            container.Register(typeof(IServicoDeValores), typeof(ServicoDeValores), Lifestyle.Scoped);
            container.Register(typeof(IServicoDeTipoValor), typeof(ServicoDeTipoValor), Lifestyle.Scoped);
            container.Register(typeof(IServicoDePonto), typeof(ServicoDePonto), Lifestyle.Scoped);

            //Serviços de Aplicacao
            container.Register(typeof(IAppServicoBase<>), typeof(AppServicoBase<>), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDeUsuario), typeof(AppServicoDeUsuario), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDaEmpresa), typeof(AppServicoDaEmpresa), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDeDespesa), typeof(AppServicoDeDespesa), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDaEtiqueta), typeof(AppServicoDaEtiqueta), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDeEventoUsuario), typeof(AppServicoDeEventoUsuario), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDeEventos), typeof(AppServicoDeEventos), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDeCliente), typeof(AppServicoDeCliente), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDePerfilUsuario), typeof(AppServicoDePerfilUsuario), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDeValores), typeof(AppServicoDeValores), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDeTipoValor), typeof(AppServicoDeTipoValor), Lifestyle.Scoped);
            container.Register(typeof(IAppServicoDePonto), typeof(AppServicoDePonto), Lifestyle.Scoped);

            //Service Locator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }
    }
}
