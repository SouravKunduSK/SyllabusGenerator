//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SyllabusGenerator.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LessonPlan
    {
        public int PlanId { get; set; }
        public string Timeline { get; set; }
        public string Topics { get; set; }
        public string LearningOutcome { get; set; }
        public Nullable<int> CourseId { get; set; }
        public string Assessment { get; set; }
        public string Teaching { get; set; }
        public string CLOName { get; set; }
        public string Outcomes { get; set; }
    }
}