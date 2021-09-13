using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    public VaultKeep GetOne(int id)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal List<VaultKeepViewModel> GetVaultKeeps(int id)
    {
      string sql = @"
      SELECT 
      a.*,
      vk.*
      FROM vaultKeeps vk
      JOIN accounts a ON a.id = vk.creatorId
      WHERE vk.id = @id;";
      return _db.Query<Profile, VaultKeepViewModel, VaultKeepViewModel>(sql, (prof, vkvm) =>
      {
          vkvm.Creator = prof;
          return vkvm;
      }, new{id}, splitOn: "id").ToList();
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      string sql = @"
      INSERT INTO vaultKeeps
      (vaultId, keepId, creatorId)
      VALUES
      (@VaultId, @KeepId, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultKeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new {id});
    }
  }
}