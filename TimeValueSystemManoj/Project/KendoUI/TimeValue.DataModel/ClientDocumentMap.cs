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
    
    public partial class ClientDocumentMap
    {
        public long PkClientDocumentId { get; set; }
        public Nullable<long> FkClientId { get; set; }
        public Nullable<long> FkDocumentId { get; set; }
        public Nullable<byte> RecordStatusId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> FkCreatedById { get; set; }
        public Nullable<long> FkCompanyId { get; set; }
        public Nullable<long> FkOrganizationId { get; set; }
        public Nullable<long> FkLanguageId { get; set; }
    }
}
