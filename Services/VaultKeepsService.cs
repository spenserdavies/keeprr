using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Http;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<VaultKeepVM> GetAll(string userId) //NOTE Might change to Public? idk if it matters
        {
            return _repo.GetByUserId(userId);
        }
        internal DTOVaultKeep GetById(int id) //TODO call in a different controller than VKC
        {            
            DTOVaultKeep exists = _repo.GetById(id);
            if(exists == null){
                throw new Exception("ur wrong bub");
            }
            return exists;
        }
        internal DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
        {
            if(_repo.hasRelationship(newVaultKeep))
            {
                throw new Exception("That Keep is Already in that Vault");
            }
            return _repo.Create(newVaultKeep);
        }

        internal DTOVaultKeep Delete(int id, string userId)
        {
            DTOVaultKeep exists = GetById(id);
            _repo.Delete(id, userId);
            return exists;
        }

        //////////////////////////// GET KEEPS FOR A VAULT ////////////////////////////////////////
        public IEnumerable<VaultKeepVM> GetKeepsByVaultId(int vaultId, string userId)
        {
            return _repo.GetKeepsByVaultId(vaultId, userId);
        }
    }
}