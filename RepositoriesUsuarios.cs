using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiTokens.Data;
using WebApiTokens.Models;

namespace WebApiTokens.Repositories
{
    public class RepositoriesUsuarios
    {

        UsuariosContext context;

        public RepositoriesUsuarios()
        {
            this.context = new UsuariosContext();
        }
         public List<Usuarios> GetUsuarios()
        {
            return this.context.Usuarios.ToList();
        }
        public Usuarios Buscar(int id)
        {
           var consulta = from datos in context.Usuarios
                           where datos.Id == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void InsertarUsuarios(string nombre, string password, string mail)
        {
            Usuarios user = new Usuarios();
            var consulta = (from datos in context.Usuarios select datos.Id);
            user.Id = consulta.Max() + 1;
            user.Nombre = nombre;
            user.Password = password;
            user.Funcion = "USER";
            user.Mail = mail;
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();
        }

        public Usuarios ExisteUsuario(String nombre, String pass)
        {
            var consulta = from datos in context.Usuarios
                           where datos.Nombre == nombre
                           && datos.Password == pass
                           select datos;
            return consulta.FirstOrDefault();

        }
     


    }
}