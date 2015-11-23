using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Repo.Model
{
    public class CAS_ProductInfoVM
    {
        public int Id { get; set; }
        public string CAS_ProductId { get; set; }
        public string Business_Unit { get; set; }
        public string Project_Name { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Phone { get; set; }
        public string IEC_Contact { get; set; }
        public string Project_Team { get; set; }
        public string Function { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> ISDeleted { get; set; }

        public virtual ICollection<CAS_FeedbackDataVM> CAS_FeedbackData { get; set; }
    }
}
