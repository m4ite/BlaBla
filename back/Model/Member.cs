using System;
using System.Collections.Generic;

namespace back.Model;

public partial class Member
{
    public int Id { get; set; }

    public int? Cargo { get; set; }

    public int? Person { get; set; }

    public int? Community { get; set; }

    public virtual Cargo? CargoNavigation { get; set; }

    public virtual Community? CommunityNavigation { get; set; }

    public virtual Person? PersonNavigation { get; set; }
}
