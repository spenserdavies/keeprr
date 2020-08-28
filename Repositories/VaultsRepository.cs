using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Vault> GetByUserId(string userId)
        {
            string sql = "SELECT * FROM vaults WHERE userId = @userId";
            return _db.Query<Vault>(sql, new { userId });
        }

        internal Vault GetById(int id)
        {
            string sql = "SELECT * FROM vaults WHERE id = @id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }

        internal Vault Create(Vault newVault) //NOTE this still doesnt work? should be same as keep..
        {
            string sql = @"
            INSERT INTO vaults
            (name, description, userId)
            VALUES
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID();"; //semicolon in the sql maybe?
            newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
            return newVault;
        }

        internal IEnumerable<Vault> Get(string userId)
        {
            string sql = "SELECT * FROM vaults WHERE userId = @userId";
            return _db.Query<Vault>(sql, new { userId });
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaults WHERE id = @id AND userId = @userId";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}