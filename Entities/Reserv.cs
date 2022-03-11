﻿using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Reserv
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Fullname { get; set; } = null!;
        [MaxLength(200)]
        public string? EmailAddress { get; set; } 
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = null!;
        public DateTime ReservDate { get; set; }
        [MaxLength(300)]
        public string? Message { get; set; }
        public int? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public int? ReservCategoryId { get; set; }
        public virtual ReservCategory  ReservCategory{ get; set; }
    }
}
