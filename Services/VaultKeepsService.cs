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

        public DTOVaultKeep Get(int id, string userId)
        {
            
            DTOVaultKeep exists = _repo.GetById(id, userId);
            if(exists == null){
                throw new Exception("ur wrong bub");
            }
            return exists;
        }
        internal DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
        {
            int id = _repo.Create(newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }

        internal object Delete(int id, string userId)
        {
            DTOVaultKeep exists = Get(id, userId);
            _repo.Delete(id, userId);
            return exists;
        }

        internal IEnumerable<VaultKeep> GetKeepsByVaultId(int id, string userId)
        {
            return _repo.GetKeepsByVaultId(id, userId);
        }
    }
}