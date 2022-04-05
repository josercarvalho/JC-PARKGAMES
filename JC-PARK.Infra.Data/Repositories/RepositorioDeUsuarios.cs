using System.Linq;
using JC_PARK.Domain.Entities;
using JC_PARK.Domain.Interfaces.Repositories;

namespace JC_PARK.Infra.Data.Repositories
{
    public class RepositorioDeUsuarios : RepositorioBase<Usuario>, IRepositorioDeUsuarios
    {

        public Usuario CadastraUsuario(Usuario user)
        {
            user.Senha = user.Senha; // Crypto.EncryptStringAES(user.Senha, user.SenhaKey);
            return _contexto.Usuarios.Add(user);
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario == null)
                return null;

            var passDecrypt = usuario.Senha; // Crypto.DecryptStringAES(usuario.Senha, usuario.SenhaKey);

            return passDecrypt == senha ? usuario : null;
        }

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.Email == email);
            return usuario;
        }

        public Usuario RecuperarUsuarioPorNome(string nome)
        {
            //string nomeUsuario = _contexto.Usuarios.Where(u => u.Nome == nome).Select(u => u.Nome).FirstOrDefault();
            var nomeUsuario = _contexto.Usuarios.FirstOrDefault(u => u.Nome == nome);
            return nomeUsuario;
        }
    }
}
