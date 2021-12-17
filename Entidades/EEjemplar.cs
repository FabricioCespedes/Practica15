using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class EEjemplar
    {
        private string claveEjemplar;

        private string eLibro;

        private string eCondicion;

        private string eEstado;

        private string eEditorial;

        private string edicion;

        private  int numeroPaginas;

        public EEjemplar()
        {
        }

        public EEjemplar(string claveEjemplar, string eLibro, string eCondicion, string eEstado, string eEditorial, string edicion, int numeroPaginas)
        {
            this.claveEjemplar = claveEjemplar;
            this.eLibro = eLibro;
            this.eCondicion = eCondicion;
            this.eEstado = eEstado;
            this.eEditorial = eEditorial;
            this.edicion = edicion;
            this.numeroPaginas = numeroPaginas;
        }

        public string ClaveEjemplar { get => claveEjemplar; set => claveEjemplar = value; }
        public string ELibro { get => eLibro; set => eLibro = value; }
        public string ECondicion { get => eCondicion; set => eCondicion = value; }
        public string EEstado { get => eEstado; set => eEstado = value; }
        public string EEditorial { get => eEditorial; set => eEditorial = value; }
        public string Edicion { get => edicion; set => edicion = value; }
        public int NumeroPaginas { get => numeroPaginas; set => numeroPaginas = value; }
    }
}
