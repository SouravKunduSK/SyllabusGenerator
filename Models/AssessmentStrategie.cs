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
    
    public partial class AssessmentStrategie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssessmentStrategie()
        {
            this.CourseDetails = new HashSet<CourseDetail>();
            this.LearningPlans = new HashSet<LearningPlan>();
            this.LPAssessmentStrategies = new HashSet<LPAssessmentStrategie>();
        }
    
        public int AssessmentStrategieId { get; set; }
        public string Strategies { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LearningPlan> LearningPlans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LPAssessmentStrategie> LPAssessmentStrategies { get; set; }
    }
}