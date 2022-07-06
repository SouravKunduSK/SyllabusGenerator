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
    
    public partial class LearningPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LearningPlan()
        {
            this.CourseDetails = new HashSet<CourseDetail>();
            this.LPAssessmentStrategies = new HashSet<LPAssessmentStrategie>();
            this.LPCLOes = new HashSet<LPCLO>();
            this.LPTeachingStrategies = new HashSet<LPTeachingStrategie>();
        }
    
        public int PlanId { get; set; }
        public Nullable<int> WeekId { get; set; }
        public string Topics { get; set; }
        public string LearningOutcome { get; set; }
        public Nullable<int> TeachingStrategieId { get; set; }
        public Nullable<int> AssessmentStrategieId { get; set; }
        public Nullable<int> CLOId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> LPAssessmentStrategieId { get; set; }
        public Nullable<int> LPTeachingStrategieId { get; set; }
        public Nullable<int> LPCLOId { get; set; }
    
        public virtual AssessmentStrategie AssessmentStrategie { get; set; }
        public virtual CLO CLO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }
        public virtual TeachingStrategie TeachingStrategie { get; set; }
        public virtual Week Week { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPAssessmentStrategie> LPAssessmentStrategies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPCLO> LPCLOes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPTeachingStrategie> LPTeachingStrategies { get; set; }
    }
}
