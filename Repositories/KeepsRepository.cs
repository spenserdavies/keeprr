using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get() //Get All Public
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }
        internal IEnumerable<Keep> GetByUserId(string userId) //Get All From User
        {
            string sql = "SELECT FROM keeps WHERE userId = @userId";
            return _db.Query<Keep>(sql, new { userId });
        }

        internal Keep GetById(int id) // Get By Id
        {
            string sql = "SELECT * FROM keeps WHERE id = @id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }
        internal Keep Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps
            (name, description, img, isPrivate, userId)
            VALUES
            (@Name, @Description, @Img, @IsPrivate, @UserId);
            SELECT LAST_INSERT_ID()";
            newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
            return newKeep;
        }

        internal bool Edit(Keep keepToUpdate, string userId)
        {
            keepToUpdate.UserId = userId;
            string sql = @"
            UPDATE keeps
            SET
                name = @Name,
                description = @Description,
                img = @Img,
                isPrivate = @IsPrivate,
                keeps = @Keeps,
                views = @Views,
                shares = @Shares
            WHERE id = @Id
            AND userId = @UserId";
            int affectedRows = _db.Execute(sql, keepToUpdate);
            return affectedRows == 1;
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM keeps WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}