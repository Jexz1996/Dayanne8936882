using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC_PARCIAL2.Models
{
    public class Usuarios
    {

        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string HIJOS { get; set; }
        public bool LIBROS{ get; set; }
        public string LIBROS_VALUE { get; set; }
        public bool MUSICA { get; set; }
        public string MUSICA_VALUE { get; set; }
        public bool DEPORTES { get; set; }
        public string DEPORTES_VALUE { get; set; }
        public bool OTROS { get; set; }
        public string OTROS_VALUE { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}