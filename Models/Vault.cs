using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
    public class Vault
    {
        //    id int NOT NULL AUTO_INCREMENT,
        //    name VARCHAR(255) NOT NULL,
        //    description VARCHAR(255) NOT NULL,
        //    userId VARCHAR(255),

        public int Id { get; set; }

        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

    }
}