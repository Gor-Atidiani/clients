using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using ApplicattionMVC.Models;
using AutoMapper;
using DAL;

namespace ApplicattionMVC.Controllers
{
    public class PersonneController : Controller
    {
        // GET: Personne
        private masterEntities contextEF = new masterEntities();
        public ActionResult Liste()
        {
            List<Personne> personnes = contextEF.Personnes.ToList();    
            return View(personnes);
        }


        // Creer une nouvelle action 
        /*
         * 
         */
        [HttpGet]
        public ActionResult Edit(int? id)//(int id)
        {
            // on a rendu l'id nullabe
            //on verifie la personne exsite grace a son id
            if (id.HasValue)
            {
                Personne personne = contextEF.Personnes.Single(p => p.Id == id);


                /** pour trouver la seul personne personne chercher atrevers son id
                // convertir les proprite de ma class DAL.Personne en Personneediter
                // utilisation de Automapper
                **/

                PersonneEditer personneEditer = Mapper.Map<PersonneEditer>(personne);

                return View(personneEditer);
            }
            else
            {    

                // pas de id => creation
                return View( new PersonneEditer());  
            }
           
        }





        // recuper les modificqtion fourni dans Edit 
         [HttpPost]
         public ActionResult Edit(PersonneEditer personne)
        {
            //verifier si le modeslstate est valide 
            if (!ModelState.IsValid)
            {
                return View(personne);
            }

            if (personne.Id.HasValue)
            {

                Personne personneDB = contextEF.Personnes.Single(p => p.Id == personne.Id);

                /*
                 * on part d'une personnEditer pour retrouver une personne co;prise par ma DAL 
                 * */
                // une fois que les donne son valide on repasse a la converssion des valeur PersonneEiter en DAL Personne
                personneDB = Mapper.Map<PersonneEditer, Personne>(personne, personneDB);
            }
            else
            {
               // creer une nouvelle personne et la convertir
                var nouvellePersonne = Mapper.Map<Personne>(personne);

                // recuper l'id ax de bdd et on l'incrimente
                int idMax = contextEF.Personnes.Max(p => p.Id);
                nouvellePersonne.Id = idMax + 1;

                contextEF.Personnes.Add(nouvellePersonne);
            }
          
            // on sauvegarde en utilisant le contextEF  ET ENREGISTRER DANS BDD
            contextEF.SaveChanges();
            // ON REDERIGE L'UTILISQTEUR VERS LA LISTE

            return RedirectToAction("Liste");
        }


        [HttpPost]
        public  JsonResult Delete(int id)
        {
            Personne personne = contextEF.Personnes.Single(p => p.Id==id); // recuper l'id
            contextEF.Personnes.Remove(personne); // on supprime
            contextEF.SaveChanges(); // et on sauvegarde 
            return Json(new {Suppression = "OK"});
        }

    }

} 