using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }
    internal List<Keep> GetAll()
    {
      string sql = "SELECT * FROM keeps;";
      return _db.Query<Keep>(sql).ToList();
    }

    internal Keep GetById(int id)
    {
      string sql = @"
      SELECT 
      a.*,
      k.*
      FROM keeps k
      JOIN accounts a ON a.id = r.creatorId
      WHERE r.id = @id;";
      return _db.Query<Profile, Keep, Keep>(sql, (prof, keep) =>
      {
          keep.Creator = prof;
          return keep;
      }, new{id}, splitOn: "id").FirstOrDefault();
    }

    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (name, description, img, creatorId)
      VALUES
      (@Name, @Description, @Img, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return GetById(newKeep.Id);
    }
  }
}