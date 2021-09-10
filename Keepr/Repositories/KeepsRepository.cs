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
      string sql = "SELECT * FROM keeps WHERE id = @id;";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
  }
}