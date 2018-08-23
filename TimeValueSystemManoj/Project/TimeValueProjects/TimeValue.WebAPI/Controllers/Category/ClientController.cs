using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

using TimeValue.BusinessEntities;
using TimeValue.BusinessEntities.TimeValue.Master;
using System.Net;
using TimeValue.BusinessServices.Interfaces;
using TimeValue.BusinessServices.Services;
using System.Data;

namespace TimeValue.WebAPI.Controllers.Category
{
    
    public class ClientController : ApiController
    {
        private readonly IClientService _clientServices;

        #region "Constructor"

        /// <summary>
        /// Public constructor to initialize client service instance
        /// </summary>
        public ClientController()
        {
            _clientServices = new ClientService();

            DataTable dt = GetTable();

            dynamic data = from  dr in GetTable().AsEnumerable ()
                       where dr.Field<int>("Dosage") == 25
                       select dr.Field<string>("Drug") ;


            var d = data;


            // Select more than one fields.
            var Fields = from dr in GetTable().AsEnumerable()
                         select new {
                             Dosage = String.Concat( dr.Field<int>("Dosage").ToString () , "1-1", dr.Field<string>("Patient")),
                             Drug = dr.Field<string>("Drug") + "-" + dr.Field<string>("Patient")
                         };

            data = Fields;


            // 


        }


        public  DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }

        #endregion

        // GET api/client
        public HttpResponseMessage Get()
        {
            var client = _clientServices.GetAllClients();
            if (client != null)
            {
                var clientEntities = client as List<ClientEntity> ?? client.ToList();
                if (clientEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, clientEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "client not found");
        }

        // GET api/client/5
        public HttpResponseMessage Get(int id)
        {
            var client = _clientServices.GetClientById(id);
            if (client != null)
                return Request.CreateResponse(HttpStatusCode.OK, client);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No client found for this id");
        }

        // POST api/client
        public long Post([FromBody] ClientEntity clientEntity)
        {
            return _clientServices.CreateClient(clientEntity);
        }

        // PUT api/client/5
        public bool  Put(long id, [FromBody] ClientEntity clientEntity)
        {
            if (id > 0)
            {
                return _clientServices.UpdateClient(id, clientEntity);
            }
            return false;
        }

        // DELETE api/client/5
        public bool  Delete(long  id)
        {

            if (id > 0)
                return _clientServices.DeleteClient(id);
            return false;
        }

    }
}