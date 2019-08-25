using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace ZeroTelcome.Controllers
{
    public class ClientsController : ApiController
    {

        //all clients
        public List<Clients> GetAllClients()
        {
            using (ZeroTelcomeEntities3 db = new ZeroTelcomeEntities3())
            {
                return db.Clients.ToList();
            }               
        }
        //one client
        [Route("api/clients/GetClient/{id}")]
        public Clients GetClient(string id)
        {
            using (ZeroTelcomeEntities3 db = new ZeroTelcomeEntities3())
            {
                return db.Clients.FirstOrDefault(c => c.Id == id);
            }
        }
        //packages of one client
        public HttpResponseMessage GetClientPackages(Clients LoggedInClient)
        {
            using (ZeroTelcomeEntities3 db = new ZeroTelcomeEntities3())
            {
                if (db.Clients.FirstOrDefault(c => c.Id == LoggedInClient.Id).Lines != null)
                {
                    var ClientLines = db.Packages.FirstOrDefault(p => p.PackageId == LoggedInClient.Lines);

                    return Request.CreateResponse(HttpStatusCode.OK, "Your line" + ClientLines);

                }
                else if(db.Clients.FirstOrDefault(c => c.Id == LoggedInClient.Id).Lines == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You dont have lines");

                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You need to log in ");


            }
        }

        //register client
        public HttpResponseMessage RegistrationPost(Clients NewClient)
        {
            using (ZeroTelcomeEntities3 db = new ZeroTelcomeEntities3()) {
               if( db.Clients.Any(x => x.Id == NewClient.Id))
                {
                   return Request.CreateErrorResponse(HttpStatusCode.BadRequest , "Id is already exist");
                }
                else
                {
                    db.Clients.Add(NewClient);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, NewClient.FirstName + "Has been creatd");
                }
            }
        }

        //customer adding line
        public HttpResponseMessage PutPackage(int Packageid, [FromBody]Clients UpdateClient)
        {
            using (ZeroTelcomeEntities3 db = new ZeroTelcomeEntities3())
            {

                if (UpdateClient.Isbuisness == false && UpdateClient.Lines == null)
                {
                    UpdateClient.Lines = db.Packages.FirstOrDefault(p => p.PackageId == Packageid).PackageId;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Your current line is" + UpdateClient.Lines );
                }

                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You cant add package");
                }
               

            }

        }

        // delete client
        public HttpResponseMessage DeleteClinet(string id)
        {
            using (ZeroTelcomeEntities3 db = new ZeroTelcomeEntities3())
            {
                Clients client = db.Clients.FirstOrDefault(c => c.Id == id);
                if (client != null)
                {
                    db.Clients.Remove(client);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "The client has been removed");

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Not found " );

                }

            }
        }
    }
}
