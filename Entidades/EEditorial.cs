using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EEditorial
    {
        private string claveEditorial;
        private string nombre;
        public EEditorial()
        {
        }

        public EEditorial(string claveEditorial, string nombre)
        {
            this.claveEditorial = claveEditorial;
            this.nombre = nombre;
        }

        public string ClaveEditorial { get => claveEditorial; set => claveEditorial = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
