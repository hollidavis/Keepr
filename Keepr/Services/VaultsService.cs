using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
        _repo = repo;
    }

    internal Vault Get(int id)
    {
      Vault vault = _repo.GetById(id);
      if(vault == null)
      {
          throw new Exception("Invalid Id");
      }
      return vault;
    }

    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal Vault Edit(Vault updatedVault)
    {
      Vault original = Get(updatedVault.Id);
      if(original.CreatorId != updatedVault.CreatorId)
      {
          throw new Exception("This is not your vault!");
      }
      original.Name = updatedVault.Name != null ? updatedVault.Name : original.Name;
      original.Description = updatedVault.Description != null ? updatedVault.Description : original.Description;
      original.Img = updatedVault.Img != null ? updatedVault.Img : original.Img;
      original.IsPrivate = updatedVault.IsPrivate != original.IsPrivate ? updatedVault.IsPrivate : original.IsPrivate;
      _repo.Edit(original);
      return original;
    }

    internal void Delete(int vaultId, string userId)
    {
      Vault toBeDeleted = Get(vaultId);
      if(toBeDeleted.CreatorId != userId)
      {
          throw new Exception("This is not your vault!");
      }
      _repo.Delete(vaultId);
    }
  }
}