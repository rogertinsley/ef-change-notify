using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Artist
    {
        public Artist()
        {
            this.Albums = new List<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
