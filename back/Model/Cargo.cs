using System;
using System.Collections.Generic;

namespace back.Model;

public partial class Cargo
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public bool? EditMembers { get; set; }

    public bool? AddPost { get; set; }

    public bool? CreateCargo { get; set; }

    public bool? EditCommunity { get; set; }

    public bool? DeleteCommunity { get; set; }

    public int? Community { get; set; }

    public virtual Community? CommunityNavigation { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
