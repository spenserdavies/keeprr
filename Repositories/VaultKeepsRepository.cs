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

        internal DTOVaultKeep GetById(int id, string userId)
        {
            string sql = "SELECT * FROM vaultkeeps WHEER id = @id AND userId = @userId";
            return _db.QueryFirstOrDefault<DTOVaultKeep>(sql, new { id, userId });
        }
        internal int Create(DTOVaultKeep newDTOVaultKeep)
        {
            string sql = @"
                INSERT INTO vaultkeeps
                (vaultId, keepId)
                VALUES
                (@VaultId, @KeepId);
                SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newDTOVaultKeep);
        }

        internal void Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id AND userId = @UserId";
            _db.Execute(sql, new { id, userId });
        }

        internal IEnumerable<VaultKeep> GetKeepsByVaultId(int id, string userId)
        {
            string sql = @"
                 SELECT 
                    k.*,
                    vk.id as vaultKeepId
                 FROM vaultkeeps vk
                 INNER JOIN keeps k ON k.id = vk.keepId 
                 WHERE (vaultId = @vaultId AND vk.userId = @userId) ";
            return _db.Query<VaultKeep>(sql, new { id, userId });
        }
    }
}