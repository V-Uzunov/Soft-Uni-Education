using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Photographer.Models
{
    class Photographer
    {
        public Photographer()
        {
            this.Albums = new HashSet<Album>();
            this.ViewerAlbums = new HashSet<Album>();
        }
        public Photographer(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.Albums = new HashSet<Album>();
            this.ViewerAlbums = new HashSet<Album>();

        }
        //Create entity photographer with username, password, email, register date and birth date. Insert sample data in database.
        public int Id { get; set; }

        private string username;
        [Required]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;
        [Required]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string email;
        [Required]
        [EmailAddress]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private DateTime? registerDate;

        public DateTime? RegisterDate
        {
            get { return registerDate; }
            set { registerDate = value; }
        }

        private DateTime? birthDate;

        public DateTime? BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public virtual ICollection<Album> Albums { get; set; }

        [InverseProperty("Viewers")]
        public virtual ICollection<Album> ViewerAlbums { get; set; }
    }
}
