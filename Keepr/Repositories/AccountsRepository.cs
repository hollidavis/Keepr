using System.Data;
using Keepr.Models;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace Keepr.Repositories
{
  public class AccountsRepository
    {
        private readonly IDbConnection _db;

        public AccountsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Account GetByEmail(string userEmail)
        {
            string sql = "SELECT * FROM accounts WHERE email = @userEmail";
            return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
        }

        internal Account GetById(string profileId)
        {
            string sql = "SELECT * FROM accounts WHERE id = @profileId";
            return _db.QueryFirstOrDefault<Account>(sql, new { profileId });
        }

        internal List<Keep> GetProfileKeeps(string profileId)
        {
            string sql = @"
            SELECT 
            a.*,
            k.*
            FROM keeps k
            JOIN accounts a ON a.id = k.creatorId
            WHERE k.creatorId = @profileId;";
            return _db.Query<Profile, Keep, Keep>(sql, (prof, keep) =>
            {
                keep.Creator = prof;
                return keep;
            }, new{profileId}, splitOn: "id").ToList();
        }

        internal List<Vault> GetProfileVaults(string profileId)
        {
            string sql = @"
            SELECT 
            a.*,
            v.*
            FROM vaults v
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.creatorId = @profileId;";
            return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
            {
                vault.Creator = prof;
                return vault;
            }, new{profileId}, splitOn: "id").ToList();
        }

        internal Account Create(Account newAccount)
        {
            string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
            _db.Execute(sql, newAccount);
            return newAccount;
        }


        internal Account Edit(Account update)
            {
                string sql = @"
                UPDATE accounts
                SET 
                name = @Name,
                picture = @Picture
                WHERE id = @Id;";
                _db.Execute(sql, update);
                return update;
            }
        }
}
