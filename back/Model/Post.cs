using System;
using System.Collections.Generic;

namespace back.Model;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Foto { get; set; }

    public string? Descrip { get; set; }

    public int? CommunityId { get; set; }

    public int? PersonId { get; set; }

    public virtual Community? Community { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual Person? Person { get; set; }
}
