using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    //public enum GenderVM { Drama, Horror, Action }
    public class FichierVM
    {
        public int Id { get; set; }
     
        public string Description { get; set; }

    [Display(Name = "Fichier")]
    public string ImageUrl { get; set; }
     
     
    }
}
