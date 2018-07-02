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
    
    public partial class Project
    {
        public long PkProjectId { get; set; }
        public string Name { get; set; }
        public string ProjectCode { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> OnHold { get; set; }
        public string Www { get; set; }
        public Nullable<long> FkClientId { get; set; }
        public Nullable<long> FkDisciplineId { get; set; }
        public Nullable<long> FkCountryId { get; set; }
        public Nullable<long> FkCurrencyId { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> BudgetAmount { get; set; }
        public Nullable<int> BudgetHours { get; set; }
        public Nullable<decimal> ActualAmount { get; set; }
        public Nullable<int> ActualHours { get; set; }
        public Nullable<int> BillableHours { get; set; }
        public Nullable<decimal> BillableAmount { get; set; }
        public Nullable<decimal> CostToDate { get; set; }
        public Nullable<int> AlertOnBudgetAmount { get; set; }
        public Nullable<int> AlertOnBudgetHours { get; set; }
        public Nullable<int> PercentComplete { get; set; }
        public Nullable<System.DateTime> BeginDate { get; set; }
        public Nullable<System.DateTime> RequiredByDate { get; set; }
        public Nullable<System.DateTime> SignOffBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> FkCreatedById { get; set; }
        public Nullable<long> FkCompanyId { get; set; }
        public Nullable<long> FkOrganizationId { get; set; }
        public Nullable<long> FkLanguageId { get; set; }
        public Nullable<byte> FkRecordStatusId { get; set; }
    
        public virtual Client Client { get; set; }
    }
}