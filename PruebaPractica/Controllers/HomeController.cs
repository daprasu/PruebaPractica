using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaPractica.Models;

namespace PruebaPractica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var bd = new PruebaPracticaEntities())
            {
                List<UsuarioCLS> ListaUsuario = (from Usuario in bd.Usuario
                                                where Usuario.Bhabilitado==true
                                                select new UsuarioCLS
                                                {
                                                    Id = Usuario.Id,
                                                    Nombre = Usuario.Nombre,
                                                    Apellidos = Usuario.Apellidos,
                                                    FechaNacimiento = Usuario.FechaNacimiento,
                                                    TelefonoCelular = Usuario.TelefonoCelular
                                                }).ToList();
                return View(ListaUsuario);
            }
        }
        // se redirige del boton agregar a la vista//
        public ActionResult Agregar()
        {
            return View();
        }
        // vuelve de la vista Agregar con la informacion registrada por metodo post//
        [HttpPost]
        public ActionResult Agregar(UsuarioCLS UsuarioNuevo)
        {
            if (!ModelState.IsValid)
            {
                return View(UsuarioNuevo);
            }
            using(var bd=new PruebaPracticaEntities())
            {
                Usuario oUsuario = new Usuario();
                oUsuario.Nombre = UsuarioNuevo.Nombre;
                oUsuario.Apellidos = UsuarioNuevo.Apellidos;
                oUsuario.FechaNacimiento = UsuarioNuevo.FechaNacimiento;
                oUsuario.TelefonoCelular = UsuarioNuevo.TelefonoCelular;
                oUsuario.Bhabilitado = true;
                bd.Usuario.Add(oUsuario);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // se redirige del boton Editar a la vista//
        public ActionResult Editar(int Id)
        {
            using (var bd = new PruebaPracticaEntities())
            {
                // se muestra en la vista de editar la informacion para el id del usuario que se escogio//

                Usuario oUsuario = bd.Usuario.Where(p => p.Id.Equals(Id)).First();
                UsuarioCLS UsuarioEditar = new UsuarioCLS();
                UsuarioEditar.Id = oUsuario.Id;
                UsuarioEditar.Nombre = oUsuario.Nombre;
                UsuarioEditar.Apellidos = oUsuario.Apellidos;
                UsuarioEditar.FechaNacimiento = oUsuario.FechaNacimiento;
                UsuarioEditar.TelefonoCelular = oUsuario.TelefonoCelular;
                return View(UsuarioEditar);
            }
        }
        // vuelve de la vista Editar con la informacion registrada por metodo post//
        [HttpPost]
        public ActionResult Editar(UsuarioCLS UsuarioEditado)
        {
            if (!ModelState.IsValid)
            {
                return View(UsuarioEditado);
            }
            using(var bd=new PruebaPracticaEntities())
            {
                Usuario oUsuario = bd.Usuario.Where(p => p.Id.Equals(UsuarioEditado.Id)).First();
                oUsuario.Nombre = UsuarioEditado.Nombre;
                oUsuario.Apellidos = UsuarioEditado.Apellidos;
                oUsuario.FechaNacimiento = UsuarioEditado.FechaNacimiento;
                oUsuario.TelefonoCelular = UsuarioEditado.TelefonoCelular;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int idusuario)
        {
            using (var bd=new PruebaPracticaEntities())
            {
                Usuario UsuarioEliminar=bd.Usuario.Where(p=>p.Id.Equals(idusuario)).First();
                UsuarioEliminar.Bhabilitado = false;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       
    }
}