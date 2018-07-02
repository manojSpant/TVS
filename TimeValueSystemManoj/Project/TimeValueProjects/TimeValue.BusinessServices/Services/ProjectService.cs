using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TimeValue.BusinessEntities.TimeValue.Master;
using TimeValue.BusinessServices.Interfaces;
using TimeValue.DataModel;
using TimeValue.DataModel.UnitOfWork;

namespace TimeValue.BusinessServices.Services
{
    public class ProjectService : IProjectService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProjectService()
        {
            _unitOfWork = new UnitOfWork();
        } 

        public long CreateProject(ProjectEntity projectEntity)
        {
            using (var scope = new TransactionScope())
            {
                var objProject = Mapper.Map<ProjectEntity, Project>(projectEntity);

                _unitOfWork.ProjectRepository.Insert(objProject);
                _unitOfWork.Save();
                scope.Complete();
                return objProject.PkProjectId ;
            }
        }

        public bool DeleteProject(long p_longProjectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectEntity> GetAllProjects()
        {
            List<ProjectEntity> objList = new List<ProjectEntity>();

            ProjectEntity objProjectEntity = new ProjectEntity();
            objProjectEntity.ClientID = 1;
            objProjectEntity.ProjectName = "ProjectName";
            objList.Add(objProjectEntity);
            return objList;
        }

        public ProjectEntity GetProjectById(long p_longProjectId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProject(long p_longProjectId, ProjectEntity p_objProjectEntity)
        {
            throw new NotImplementedException();
        }
    }
}
