namespace CodeFirstDemo.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DateRegister { get; set; }

        public int? TermServiceID { get; set; }

        public int? KnowID { get; set; }

        [StringLength(100)]
        public string KnowOther { get; set; }

        public int? StateID { get; set; }

        public short TimeZoneId { get; set; }

        public bool AdjustDaylight { get; set; }

        public decimal TimeZoneOffSet { get; set; }

        public byte? LanguageId { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Birthday { get; set; }

        public int HoldingID { get; set; }

        [Required]
        [StringLength(50)]
        public string CPF { get; set; }

        public bool? HasImage { get; set; }

        [StringLength(12)]
        public string ResourcesVersion { get; set; }

        [StringLength(12)]
        public string PriorResourcesVersion { get; set; }

        public bool? HasValidEmail { get; set; }

        public bool? HasBouncedEmail { get; set; }

        public int? IndexCPF { get; set; }

        public bool? MobileActive { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(150)]
        public string CivilName { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastLogoutDate { get; set; }

        [StringLength(50)]
        public string CustomResourcesJS { get; set; }

        public virtual StudentRegistration StudentRegistration { get; set; }
    }
}
