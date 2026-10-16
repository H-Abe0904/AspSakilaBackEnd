using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspSakilaBackEnd.Models;
[Table("address")]
public class Address
{
    [Column("address_id")]
    public short AddressId { get; set; }

    [Column("address")] // ★ C#側のプロパティ名 Address1 を MySQLの列名 address にマッピング
    public string Address1 { get; set; } = null!;

    [Column("address2")]
    public string? Address2 { get; set; }

    [Column("district")]
    public string District { get; set; } = null!;

    [Column("city_id")]
    public short CityId { get; set; }

    [Column("postal_code")]
    public string? PostalCode { get; set; }

    [Column("phone")]
    public string Phone { get; set; } = null!;

    [Column("last_update")]
    public DateTime LastUpdate { get; set; }
}