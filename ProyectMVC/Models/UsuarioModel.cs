using System;
using ProyectMVC.Models;

namespace ProyectMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string telefono { get; set; }
        public string PuestoTrabajo { get; set; }
        public bool privilegios{get; set;}
        public string cedula{get; set;}
        public string contrasena{get; set;}

        public UsuarioModel(){

        }


    }
}