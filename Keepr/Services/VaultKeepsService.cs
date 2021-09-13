using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
        _repo = repo;
    }

    internal List<VaultKeep> Get(int id)
    {
      VaultKeep found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
    }

    internal void Delete(int vaultKeepId, string userId)
    {
      VaultKeep toBeDeleted = Get(vaultKeepId);
      if(toBeDeleted.CreatorId != userId)
      {
          throw new Exception("This is not yours!");
      }
      _repo.Delete(vaultKeepId);
    }
  }
}