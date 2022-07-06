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
    
    public partial class CIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIE()
        {
            this.CourseDetails = new HashSet<CourseDetail>();
        }
    
        public int CIEId { get; set; }
        public string Category { get; set; }
        public string Test { get; set; }
        public string Assignment { get; set; }
        public string Quizzes { get; set; }
        public string CCA { get; set; }
        public Nullable<int> CourseId { get; set; }
    
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }
    }
}