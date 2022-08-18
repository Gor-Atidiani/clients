using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;



namespace ApplicattionMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //declarer la coversion  de  DAL.Personne  en Applicatio.ModelPersonne
            AutoMapper.Mapper.CreateMap<DAL.Personne, ApplicattionMVC.Models.PersonneEditer>();

            // personneEdit en DAL.Personne
            AutoMapper.Mapper.CreateMap<ApplicattionMVC.Models.PersonneEditer, DAL.Personne>();


        }
    }
}
