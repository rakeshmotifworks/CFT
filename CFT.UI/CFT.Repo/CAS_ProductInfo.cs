//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CFT.Repo
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAS_ProductInfo
    {
        public CAS_ProductInfo()
        {
            this.CAS_FeedbackData = new HashSet<CAS_FeedbackData>();
        }
    
        public int Id { get; set; }
        public string CAS_ProductId { get; set; }
        public string Business_Unit { get; set; }
        public string Project_Name { get; set; }
        public string Customer_Name { get; set; }
        public string IEC_Contact { get; set; }
        public string Project_Team { get; set; }
        public string Function { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> ISDeleted { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Phone { get; set; }
    
        public virtual ICollection<CAS_FeedbackData> CAS_FeedbackData { get; set; }
    }
}
