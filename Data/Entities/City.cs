using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspSakilaBackEnd.Models;

[Table("city")]
public partial class City
{
    public ushort CityId { get; set; }

    public string City1 { get; set; } = null!;

    public ushort CountryId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;
}
