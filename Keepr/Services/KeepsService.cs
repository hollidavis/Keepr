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

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal Keep Edit(Keep updatedKeep)
    {
      Keep original = Get(updatedKeep.Id);
      if(original.CreatorId != updatedKeep.CreatorId)
      {
          throw new Exception("This is not your keep!");
      }
      original.Name = updatedKeep.Name != null ? updatedKeep.Name : original.Name;
      original.Description = updatedKeep.Description != null ? updatedKeep.Description : original.Description;
      original.Img = updatedKeep.Img != null ? updatedKeep.Img : original.Img;
      _repo.Edit(original);
      return original;
    }

    internal void Delete(int keepId, string userId)
    {
      Keep toBeDeleted = Get(keepId);
      if(toBeDeleted.CreatorId != userId)
      {
          throw new Exception("This is not your keep!");
      }
      _repo.Delete(keepId);
    }
  }
}