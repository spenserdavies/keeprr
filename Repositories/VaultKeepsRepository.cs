using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal DTOVaultKeep GetById(int id)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @id"; //NOTE STOP MISPELLING SQL statements
            return _db.QueryFirstOrDefault<DTOVaultKeep>(sql, new { id});
        }

        internal IEnumerable<VaultKeepVM> GetByUserId(string userId)
        {
            string sql = @"
                SELECT
                k.*,
                vk.id as vaultkeepId
                FROM vaultkeeps vk
                INNER JOIN keeps k on k.id = vk.keepId
                WHERE userId = @userId";
            return _db.Query<VaultKeepVM>(sql, new { userId });
        }

        internal DTOVaultKeep Create(DTOVaultKeep newDTOVaultKeep)
        {
            string sql = @"
                INSERT INTO vaultkeeps
                (vaultId, keepId, userId)
                VALUES
                (@VaultId, @KeepId, @UserId);
                SELECT LAST_INSERT_ID();";
            newDTOVaultKeep.Id = _db.ExecuteScalar<int>(sql, newDTOVaultKeep);
            return newDTOVaultKeep;
        }
        internal void Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id AND userId = @UserId";
            _db.Execute(sql, new { id }); // TODO might have to put userId in the new object?
        }

        public IEnumerable<VaultKeepVM> GetKeepsByVaultId(int vaultId, string userId)
        {
            string sql = @"
                 SELECT 
                    k.*,
                    vk.id as vaultKeepId
                 FROM vaultkeeps vk
                 INNER JOIN keeps k ON k.id = vk.keepId 
                 WHERE (vaultId = @vaultId AND vk.userId = @userId) ";
            return _db.Query<VaultKeepVM>(sql, new { vaultId, userId }); //changed id to vaultId
        }
    }
}