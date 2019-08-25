using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;


namespace ZeroTelcome.Controllers
{
    public class PackagesController : ApiController
    {
        // all packages
        public List<Packages> GetPackages()
        {
            using (ZeroTelcomeEntities3 db = new ZeroTelcomeEntities3())
            {
                return db.Packages.ToList();
            }
        }

        //one package
        [Route("api/packages/GetPackage/{id}")]
        public Packages GetPackage(int id)
        {
            using (ZeroTelcomeEntities3 db = new ZeroTelcomeEntities3())
            {
                return db.Packages.FirstOrDefault(p=>p.PackageId==id);
            }
        } 
    }
}
