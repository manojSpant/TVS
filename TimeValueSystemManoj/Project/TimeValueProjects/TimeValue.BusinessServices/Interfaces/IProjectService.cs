using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;

namespace TimeValue.BusinessServices.Interfaces
{
   public interface IProjectService
    {
        ProjectEntity GetProjectById(long p_longProjectId);
        IEnumerable<ProjectEntity> GetAllProjects();
        long CreateProject(ProjectEntity p_objProjectEntity);
        bool UpdateProject(long p_longProjectId, ProjectEntity p_objProjectEntity);
        bool DeleteProject(long p_longProjectId);
    }
}
