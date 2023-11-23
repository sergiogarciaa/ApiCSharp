using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCSharp.Entidades
{
    public class Acceso
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_acceso { get; set; }
        public string? codigo_acceso { get; set; }
        public string? descripcion_acceso { get; set; }

        // Collection
        public ICollection<Usuario>? Usuarios { get; set; }

        // Constructor

        public Acceso(long id_acceso, string codigo_acceso, string? descripcion_acceso)
        {
            this.id_acceso = id_acceso;
            this.codigo_acceso = codigo_acceso;
            this.descripcion_acceso = descripcion_acceso;
        }
    }
}
