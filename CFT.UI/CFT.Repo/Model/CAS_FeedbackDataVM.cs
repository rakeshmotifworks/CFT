﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Repo.Model
{
    public class CAS_FeedbackDataVM
    {
        public int Id { get; set; }
        public Nullable<int> CAS_ProdInfo_FK { get; set; }
        public string Quality { get; set; }
        public string Adherence_To_Schedule { get; set; }
        public string Alternate_Solutions_Value_addition { get; set; }
        public string Effectiveness_of_Communication { get; set; }
        public string Independent_project_execution_Customers_Efforts { get; set; }
        public string Overall_Satisfaction { get; set; }
        public string Additional_Comments_Issues_Concerns_Suggestions { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public virtual CAS_ProductInfo CAS_ProductInfo { get; set; }
    }
}
