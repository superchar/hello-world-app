

using System.ComponentModel.DataAnnotations;

namespace HelloWorld_V2.Models
{
    public class HelloWorldViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Name { get; set; }

    }
}