using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspSakilaBackEnd.Models;

[Table("staff")]
public partial class Staff
{
   [Column("staff_id")]
    public byte StaffId { get; set; }
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

   [Column("address_id")]
    public ushort AddressId { get; set; } // 実際の外部キー列

    public byte[]? Picture { get; set; }

    public string? Email { get; set; }

    public byte StoreId { get; set; }

    public bool? Active { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime LastUpdate { get; set; }

   [ForeignKey("AddressId")]
    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Store Store { get; set; } = null!;

    [NotMapped]
    public virtual Store? StoreNavigation { get; set; }
}
