using System;
using System.Collections.Generic;

namespace back.Model;

public partial class Community
{
    public int Id { get; set; }

    public string? Foto { get; set; }

    public string? Title { get; set; }

    public string? Descrip { get; set; }

    public DateTime? Criacao { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
