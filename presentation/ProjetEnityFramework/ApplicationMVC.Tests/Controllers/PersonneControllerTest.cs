using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApplicattionMVC.Controllers;
using ApplicattionMVC.Models;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationMVC.Tests.Controllers
{
    [TestClass]
    public  class PersonneControllerTest
    {
        [TestMethod]    
        public void Edittest()
        {
            AutoMapper.Mapper.CreateMap<Personne, PersonneEditer>();
            // on commence le test pour  Edit 
            // on vq verifier si avec on choisi un id on aura la personne correspondante
            var controller = new PersonneController(); // instancier la classe aue nous testons 
            //on recupere le resutlat en le typant ViewResult
            var result = controller.Edit(1) as ViewResult; // pour acceder au model contenu dans le resultat renvoyer par ;on action
           var model = result.Model as PersonneEditer; // la variable view ressult nous permet d'acceder au model 
            // on verifie
            Assert.AreEqual(1, model.Id, "je n'edite  pas cette personne");
        }

    }
}
