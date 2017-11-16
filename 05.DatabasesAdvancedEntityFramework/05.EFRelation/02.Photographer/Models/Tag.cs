using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Photographer.Models
{
    public class Tag
    {

        public Tag()
        {
            this.Albums = new HashSet<Album>();

        }


        public Tag(string name)
        {
            this.tagName = name;
            this.Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }

        private string tagName;
        [StringLength(50)]
        [Index(IsUnique = true)]
        [IndexAttribute("TagName", IsUnique = true)]
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
