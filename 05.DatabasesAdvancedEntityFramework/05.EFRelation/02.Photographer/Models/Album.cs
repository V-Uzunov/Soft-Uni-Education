using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Photographer.Models
{
    public class Album
    {
        // Each album has name, background color and information whether is public or not. One album may have many pictures. 
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            //this.Photographers = new HashSet<Photographer>();
            this.Viewers = new HashSet<Photographer>();

        }

        public Album(string name, string backgroundColor, bool isPublic)
        {
            this.name = name;
            this.backgroundColor = backgroundColor;
            this.isPublic = isPublic;
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            //this.Photographers = new HashSet<Photographer>();
            this.Viewers = new HashSet<Photographer>();

        }
        public int Id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string backgroundColor;

        public string BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        private bool isPublic;

        public bool IsPublic
        {
            get { return isPublic; }
            set { isPublic = value; }
        }
        [Index(IsUnique = true)]

        //public virtual ICollection<Photographer> Photographers { get; set; }
        public virtual Photographer Photographer { get; set; }

        [InverseProperty("ViewerAlbums")]
        public virtual ICollection<Photographer> Viewers { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

    }
