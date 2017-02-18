using System;
using System.Collections.Generic;

namespace Virgil
{
    public partial class Topic
    {
        public Topic()
        {
            this.Links = new List<Link>();
            this.Media = new List<Medium>();
            this.References = new List<Reference>();
        }

        public int id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string BodyGerman { get; set; }
        public string BackColor { get; set; }
        public string TextColor { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Reference> References { get; set; }
    }
}
