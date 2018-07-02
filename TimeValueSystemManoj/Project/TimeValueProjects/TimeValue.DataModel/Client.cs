//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeValue.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.Projects = new HashSet<Project>();
        }
    
        public long PkClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ClientSince { get; set; }
        public Nullable<int> DefaultTicketTypeId { get; set; }
        public Nullable<long> FkGroupId { get; set; }
        public Nullable<long> FkCountryId { get; set; }
        public Nullable<long> FkCurrencyId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> OnHold { get; set; }
        public Nullable<long> FkCreatedById { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> FkCompanyId { get; set; }
        public Nullable<long> FkOrganizationId { get; set; }
        public Nullable<long> FkLanguageId { get; set; }
        public Nullable<byte> FkRecordStatusId { get; set; }
    
        public virtual ICollection<Project> Projects { get; set; }
    }
}
