using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Users
{
    public class Users
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }



        //•	Username – Text with length between 4 and 30 symbols.Required.

        [StringLength(30, MinimumLength = 4)]

        [Required]



        public string Username { get; set; }



        //•	Password – Required field.Text with length between 6 and 50 symbols.Should contain at least:

        //o   1 lowercase letter

        //o   1 uppercase letter

        //o   1 digit

        //o	1 special symbol (!, @, #, $, %, ^, &, *, (, ), _, +, <, >, ?)

        //[StringLength(50, MinimumLength = 6)]

        [Required]

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,50}$")]

        [DataType(DataType.Password)]

        public string Password { get; set; }



        //•	E-mail – Required field. Text that is considered to be in format<user>@<host> where:

        //o<user> is a sequence of letters and digits, where '.', '-' and '_' can appear between them (they cannot appear at the beginning or at the end of the sequence). 

        //o<host> is a sequence of at least two words, separated by dots '.' (dots cannot appear at the beginning or at the end of the sequence)

        [EmailAddress]

        [Required]

        public string eMail { get; set; }



        //•	ProfilePicture – Image file with size maximum of 1MB

        [MaxLength(8388608)]

        public byte[] ProfilePicture { get; set; }



        //•	RegisteredOn – Date and time of user registration

        public DateTime RegisteredOn { get; set; }



        //•	LastTimeLoggedIn – Date and time of the last time the user logged in

        public DateTime LastTimeLoggedIn { get; set; }



        //•	Age –  number in range[1, 120]

        [Range(1, 120)]

        public int Age { get; set; }



        //•	IsDeleted – Shows whether the user is deleted or not

        public bool IsDeleted { get; set; }
    }
}
