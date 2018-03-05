using System;
using ProyectMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectMVC.Models
{
    public class ReunionModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]


        public DateTime Dia { get; set; }
        public virtual UsuarioModel Usuario {get; set;}
        public int UsuarioId {get; set;}
        public bool presencial {get; set;}
        public virtual ClienteModel Cliente {get; set;}
        public int ClienteId {get; set;}
        



        public ReunionModel(){

        }


       


    }
}