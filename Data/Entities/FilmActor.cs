using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspSakilaBackEnd.Models;

[Table("film_actor")]
public partial class FilmActor
{
    public ushort ActorId { get; set; }

    public ushort FilmId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Actor Actor { get; set; } = null!;

    public virtual Film Film { get; set; } = null!;
}
