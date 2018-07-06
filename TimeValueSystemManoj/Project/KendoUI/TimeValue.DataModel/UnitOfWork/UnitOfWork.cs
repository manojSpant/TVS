using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.DataModel.GenericRepository;

namespace TimeValue.DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private DevTimeValueEntities _context = null;
        private GenericRepository<Organization> _organizationRepository;
        private GenericRepository<Company> _companyRepository;
        private GenericRepository<Client> _clientRepository;
        private GenericRepository<Project> _projectRepository;
        private GenericRepository<Employee> _employeeRepository;
        private GenericRepository<User> _userRepository;
        private GenericRepository<Token> _tokenRepository;

        #endregion

        public UnitOfWork()
        {
            _context = new DevTimeValueEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for Organization repository.
        /// </summary>
        public GenericRepository<Organization> OrganizationRepository
        {
            get
            {
                if (this._organizationRepository == null)
                    this._organizationRepository = new GenericRepository<Organization>(_context);
                return _organizationRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Company repository.
        /// </summary>
        public GenericRepository<Company> CompanyRepository
        {
            get
            {
                if (this._companyRepository == null)
                    this._companyRepository = new GenericRepository<Company>(_context);
                return _companyRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Client repository.
        /// </summary>
        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (this._clientRepository == null)
                    this._clientRepository = new GenericRepository<Client>(_context);
                return _clientRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Project repository.
        /// </summary>
        public GenericRepository<Project> ProjectRepository
        {
            get
            {
                if (this._projectRepository  == null)
                    this._projectRepository = new GenericRepository<Project>(_context);
                return _projectRepository;
            }
        }


        /// <summary>
        /// Get/Set Property for Employee repository.
        /// </summary>
        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                    this._employeeRepository = new GenericRepository<Employee>(_context);
                return _employeeRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for User repository.
        /// </summary>
        public GenericRepository<User > UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<User>(_context);
                return _userRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Token repository.
        /// </summary>
        public GenericRepository<Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new GenericRepository<Token>(_context);
                return _tokenRepository;
            }
        }

        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var l_objOutputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    l_objOutputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        l_objOutputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", l_objOutputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool m_boolDisposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="p_boolDisposing"></param>
        protected virtual void Dispose(bool p_boolDisposing)
        {
            if (!this.m_boolDisposed)
            {
                if (p_boolDisposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.m_boolDisposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
