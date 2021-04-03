using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class LoginVM
    {
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}