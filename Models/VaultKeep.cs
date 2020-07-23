namespace Keepr.Models
{
    public class DTOVaultKeep
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int VaultId  { get; set; } //References a vault
        public int KeepId { get; set; }  //References a keep
    }
}