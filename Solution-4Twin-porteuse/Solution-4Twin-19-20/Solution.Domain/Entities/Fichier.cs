using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    //public enum Gender { Drama,Horror,Action}
    public class Fichier
    {
        public int Id { get; set; }
     
        public string Description { get; set; }
       
        public string ImageUrl { get; set; }
 
        // foreign key
       /* public int? ProducerId { get; set; } // ? nullable
        [ForeignKey("ProducerId")]
        public virtual Producer Productor { get; set; }
        //prop de navig*/
       
    }
}
