using System;
using System.Collections.Generic;

namespace back.Model;

public partial class Person
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? NickName { get; set; }

    public string? WordPass { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Foto { get; set; }

    public string? Salt { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
