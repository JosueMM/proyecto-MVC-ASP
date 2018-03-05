using System;
using ProyectMVC.Models;

namespace ProyectMVC.Models
{
    public class SupportModel
    {
        public int Id { get; set; }
        public string Problema { get; set; }
        public string Detalle { get; set; }
        public string Estado{ get; set; }
        public virtual ClienteModel Cliente{get; set;} 
        public int ClienteId { get; set; }

        public SupportModel(){

        }


    }
}