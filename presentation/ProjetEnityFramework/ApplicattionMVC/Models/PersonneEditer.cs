using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ApplicattionMVC.Models
{
    public class PersonneEditer //:IValidatableObject
    {
     
        public int? Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Range(0,100)]
        public int? Age { get; set; }
        [Required]
        public string Email { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var resultat = new List<ValidationResult>();    
        //    if (String.IsNullOrWhiteSpace(Email) == false && Email.EndsWith(".com")== false)
        //    {
        //        var erreur = new ValidationResult(
        //            "que les mqil finissant par .com",
        //            new List<string> { "Email"});

        //        resultat.Add(erreur);
        //    }
            
        //}
    }
}
