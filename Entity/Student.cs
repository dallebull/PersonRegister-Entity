namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }
    }
}
