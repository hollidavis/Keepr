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

    internal VaultKeep GetOne(int id)
    {
      return _repo.GetOne(id);
    }

    internal List<VaultKeepViewModel> GetVaultKeeps(int id)
    {
      return _repo.GetVaultKeeps(id);
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
    }

    internal void Delete(int vaultKeepId, string userId)
    {
      VaultKeep toBeDeleted = GetOne(vaultKeepId);
      if(toBeDeleted.CreatorId != userId)
      {
          throw new Exception("This is not yours!");
      }
      _repo.Delete(vaultKeepId);
    }
  }
}