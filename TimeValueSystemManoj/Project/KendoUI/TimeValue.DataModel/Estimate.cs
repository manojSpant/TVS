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
    
    public partial class Estimate
    {
        public long PkEstimateId { get; set; }
        public string EstimateNumber { get; set; }
        public string Description { get; set; }
        public Nullable<byte> FkEstimateForId { get; set; }
        public Nullable<long> FkClientId { get; set; }
        public Nullable<long> FkProjectId { get; set; }
        public Nullable<long> FkPhaseId { get; set; }
        public Nullable<long> FkApprovedById { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> FkCreatedById { get; set; }
        public Nullable<long> FkCompanyId { get; set; }
        public Nullable<long> FkOrganizationId { get; set; }
        public Nullable<long> FkLanguageId { get; set; }
        public Nullable<byte> FkRecordStatusId { get; set; }
    }
}
