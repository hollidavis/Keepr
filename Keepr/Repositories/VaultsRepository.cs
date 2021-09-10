using System.Data;
using System.Linq;
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

    internal Vault GetById(int id)
    {
      string sql = @"
      SELECT 
      a.*,
      k.*
      FROM vaults k
      JOIN accounts a ON a.id = k.creatorId
      WHERE k.id = @id;";
      return _db.Query<Profile, Vault, Vault>(sql, (prof, vault) =>
      {
          vault.Creator = prof;
          return vault;
      }, new{id}, splitOn: "id").FirstOrDefault();
    }

    internal Vault Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults
      (name, description, img, isPrivate, creatorId)
      VALUES
      (@Name, @Description, @Img, @IsPrivate, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return GetById(newVault.Id);
    }

    internal Vault Edit(Vault updatedVault)
    {
      string sql = @"
      UPDATE vaults
      SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @IsPrivate
      WHERE id = @Id
      ;";
      _db.Execute(sql, updatedVault);
      return updatedVault;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new {id});
    }
  }
}