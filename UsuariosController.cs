using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTokens.Models;
using WebApiTokens.Repositories;

namespace WebApiTokens.Controllers
{
    public class UsuariosController : ApiController
    {
        RepositoriesUsuarios repo;

        public UsuariosController()
        {
            this.repo = new RepositoriesUsuarios();
        }

     
        public List<Usuarios> GetUsuarios()
        {
            return this.repo.GetUsuarios();
        }
        [Authorize]
        public Usuarios GetUsuario(int id)
        {
            return this.repo.Buscar(id);
        }
        [Authorize]
        //[Route("api/InsertUsuario")]
        public void Post(Usuarios u)
        {

            this.repo.InsertarUsuarios(u.Nombre,u.Password, u.Mail);
        }
        //public void InsertarUsuario(string nombre, string password, string mail)
        //{

        //     this.repo.InsertarUsuarios(nombre, password, mail);
        //}

    }
}
