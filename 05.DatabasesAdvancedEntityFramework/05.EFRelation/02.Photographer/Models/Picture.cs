using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Photographer.Models
{
    public class Picture
    {
        // Each picture has title, caption (string) and path on the file system
        public Picture()
        {
            this.Albums = new HashSet<Album>();

        }

        public Picture(string title, string caption, string path)
        {
            this.title = title;
            this.caption = caption;
            this.path = path;
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string caption;

        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public virtual ICollection<Album> Albums { get; set; }
    }
}