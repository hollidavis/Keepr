using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class AccountService
    {
        private readonly AccountsRepository _repo;
        public AccountService(AccountsRepository repo)
        {
            _repo = repo;
        }

        internal string GetProfileEmailById(string id)
        {
            return _repo.GetById(id).Email;
        }
        internal Account GetProfileByEmail(string email)
        {
            return _repo.GetByEmail(email);
        }
        internal Account GetOrCreateProfile(Account userInfo)
        {
            Account profile = _repo.GetById(userInfo.Id);
            if (profile == null)
            {
                return _repo.Create(userInfo);
            }
            return profile;
        }

        internal Profile GetProfileById(string profileId)
        {
            return _repo.GetById(profileId);
        }

        internal List<Keep> GetProfileKeeps(string profileId)
        {
            return _repo.GetProfileKeeps(profileId);
        }

        internal List<Vault> GetProfileVaults(string profileId, string userId)
        {
            List<Vault> vaults = _repo.GetProfileVaults(profileId);
            if(profileId == userId){
                return vaults;
            } else {
                List<Vault> results = vaults.FindAll(v => v.IsPrivate == false);
                return results;
            }
        }

        internal Account Edit(Account editData, string userEmail)
        {
            Account original = GetProfileByEmail(userEmail);
            original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
            original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
            return _repo.Edit(original);
        }
    }
}