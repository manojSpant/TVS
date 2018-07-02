using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using TimeValue.BusinessEntities.TimeValue.Master;
using TimeValue.BusinessServices.Interfaces;
using TimeValue.BusinessServices.Services;
using TimeValue.WebAPI.ActionFilters;
using TimeValue.WebAPI.Filters;

namespace TimeValue.WebAPI.Controllers.Category
{
    [AuthorizationRequired]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectServices;

        #region "Constructor"

        /// <summary>
        /// Public constructor to initialize project service instance
        /// </summary>
        public ProjectController()
        {
            _projectServices = new ProjectService();
        }

        #endregion

        // GET api/client
        public HttpResponseMessage Get()
        {
            var project = _projectServices.GetAllProjects();
            if (project != null)
            {
                var projectEntities = project as List<ProjectEntity> ?? project.ToList();
                if (projectEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, projectEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "client not found");
        }

        // GET api/client/5
        public HttpResponseMessage Get(int id)
        {
            var project = _projectServices.GetProjectById(id);
            if (project != null)
                return Request.CreateResponse(HttpStatusCode.OK, project);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No client found for this id");
        }

        // POST api/client
        public long Post([FromBody] ProjectEntity projectEntity)
        {
            return _projectServices.CreateProject(projectEntity);
        }

        // PUT api/client/5
        public bool Put(long id, [FromBody] ProjectEntity projectEntity)
        {
            if (id > 0)
            {
                return _projectServices.UpdateProject(id, projectEntity);
            }
            return false;
        }

        // DELETE api/client/5
        public bool Delete(long id)
        {

            if (id > 0)
                return _projectServices.DeleteProject(id);
            return false;
        }
    }
}