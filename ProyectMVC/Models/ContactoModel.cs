using System;
using ProyectMVC.Models;

namespace ProyectMVC.Models
{
    public class ContactoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Numero{ get; set; }
        public string Puesto{ get; set; }
        public virtual ClienteModel Cliente{get; set;} 
        public int ClienteId { get; set; }

        public ContactoModel(){

        }


    }
}