using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
        _repo = repo;
    }

    internal List<Keep> Get()
    {
      return _repo.GetAll();
    }

    internal Keep Get(int id)
    {
      Keep keep = _repo.GetById(id);
      if(keep == null)
      {
          throw new Exception("Invalid Id");
      }
      return keep;
    }
  }
}