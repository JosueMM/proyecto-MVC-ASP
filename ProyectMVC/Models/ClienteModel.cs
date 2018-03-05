using System;
using ProyectMVC.Models;

namespace ProyectMVC.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Juridica { get; set; }
        public string Direccion { get; set; }
        public string Numero{ get; set; }
        public virtual SectorModel Sector{get; set;} 
        public int SectorId { get; set; }

        public ClienteModel(){

        }


    }
}