using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeValue.BusinessEntities.TimeValue.Master
{
  public  class ProjectEntity
    {

        public long ProjectID { get; set; }
        public String ProjectName { get; set; }

        public long ClientID { get; set; }

    }
}
