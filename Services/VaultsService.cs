using System;
using System.Collections.Generic;
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
        internal IEnumerable<Vault> GetVaultsByUser(string userId)
        {
            return _repo.GetByUserId(userId);
        }

        internal Vault GetById(int id)
        {
            Vault foundVault = _repo.GetById(id);
            if(foundVault == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundVault;
        }

        internal Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        internal object Delete(int id, string userId)
        {
            Vault foundVault = GetById(id);
            if(foundVault.UserId != userId)
            {
                throw new Exception("That aint ur vault chief");
            }
            if(_repo.Delete(id, userId))
            {
                return "its gone";
            }
            throw new Exception("what did you do????");
        }
    }
}