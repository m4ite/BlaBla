using System;
using System.Collections.Generic;

namespace back.Model;

public partial class Like
{
    public int Id { get; set; }

    public int? Person { get; set; }

    public int? Post { get; set; }

    public virtual Person? PersonNavigation { get; set; }

    public virtual Post? PostNavigation { get; set; }
}
