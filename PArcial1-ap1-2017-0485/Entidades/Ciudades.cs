using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PArcial1_ap1_2017_0485.Entidades
{
   public class Ciudades
    {
        [Key]
        public int CuidadId { get; set; }

        public string Nombre { get; set; }

    }
}
