using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public bool IsPrivate { get; set; }
        public int Views { get; set; }
        public int Shares { get; set; }
        public int Keeps { get; set; }

    }
    public class VaultKeep : Keep //from TimsFinalTacos, was originally Called ViewModel
    {
        public int VaultKeepId { get; set; }
    }
}