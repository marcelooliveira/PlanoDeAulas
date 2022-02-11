namespace CodeFirstDemo.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentRegistration")]
    public partial class StudentRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Required]
        public string IDNumber { get; set; }

        public DateTime IDIssuanceDate { get; set; }

        [Required]
        public string IDIssuer { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public string MotherName { get; set; }

        [Required]
        public string CountryOfBirth { get; set; }

        [Required]
        public string StateOfBirth { get; set; }

        [Required]
        public string CityOfBirth { get; set; }

        [Required]
        public string CollegeDegreeCourse { get; set; }

        [Required]
        public string CollegeDegreeTitle { get; set; }

        [Required]
        public string CollegeDegreeCountry { get; set; }

        [Required]
        public string CollegeDegreeState { get; set; }

        [Required]
        public string CollegeDegreeCity { get; set; }

        [Required]
        public string CollegeDegreeInstitution { get; set; }

        public DateTime CollegeDegreeDate { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string Disability { get; set; }

        public DateTime? GraduationDate { get; set; }

        public DateTime DateRegister { get; set; }

        public DateTime? DateAcceptance { get; set; }

        public DateTime? AckStudentCanSendDocs { get; set; }

        public virtual User User { get; set; }
    }
}
