using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspSakilaBackEnd.Models;

[Table("country")]
public partial class Country
{
    public ushort CountryId { get; set; }

    public string Country1 { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
