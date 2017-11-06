namespace _08.Create_User.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class User
    {
        private string username;
        private string password;
        private string email;
        private int? profilePicture;
        private int? age;

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30), MinLength(4)]
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (value.Length < 4 || value.Length > 30 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username length must be 4-30 symbols!");
                }
                this.username = value;
            }
        }

        [Required]
        [RegularExpression("^(?=.*[a-z])+(?=.*[A-Z])+(?=.*[0-9])+(?=.*[!@#$%^&*()_+<>?])+.{6,50}$")]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (value.Length < 6 || value.Length > 50 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password length must be 6 symbols minimum and 50 symbols maximum long!");
                }
                if (!Regex.IsMatch(value, "^(?=.*[a-z])+(?=.*[A-Z])+(?=.*[0-9])+(?=.*[!@#$%^&*()_+<>?])+.{6,50}$"))
                {
                    throw new ArgumentException(
                        "Password must contain at least 1 lowercase letter, 1 uppercase letter, 1 digit and 1 special symbol!");
                }
                this.password = value;
            }
        }

        [Required]
        [RegularExpression("^[^_.@].+@[^.]+\\.[^.]+$")]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email is required!");
                }
                if (!Regex.IsMatch(value, "^[^_.@].+@[^.]+\\.[^.]+$"))
                {
                    throw new ArgumentException("Not valid email!");
                }
                this.email = value;
            }
        }

        [Range(1, 1000)]
        public int? ProfilePicture
        {
            get
            {
                return this.profilePicture;
            }
            set
            {
                if (value > 1000)
                {
                    throw new ArgumentException("The maximum size is 1MB!");
                }
                this.profilePicture = value;
            }
        }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 120)
                {
                    throw new ArgumentException("Age must be between 1 and 120 years");
                }
                this.age = value;
            }
        }

        public bool IsDeleted { get; set; }
    }
}