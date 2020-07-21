using System;
using System.Collections.Generic;
using System.Data;
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
        public IEnumerable<Keep> Get() //Get All
        {
            return _repo.Get();
        }


        internal IEnumerable<Keep> GetByUserId(string userId) //Get by User
        {
            return _repo.GetByUserId(userId);
        }

        internal Keep GetById(int id) //Get by Id
        {
            
            Keep foundKeep = _repo.GetById(id);
            if(foundKeep == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundKeep;
        }
        
        public Keep Create(Keep newKeep) //Create
        {
            return _repo.Create(newKeep);
        }

        internal Keep Edit(Keep keepToUpdate, string userId) //Edit
        {
            Keep foundKeep = GetById(keepToUpdate.Id);
            if(foundKeep.UserId == userId && _repo.Edit(keepToUpdate, userId))
            {
                return keepToUpdate;
            }
            throw new Exception("You cannot edit this keep");
        }

        internal string Delete(int id, string userId) //Delete
        {
            Keep foundKeep = GetById(id);
            if(foundKeep.UserId != userId)
            {
                throw new Exception("That is not your post");
            }
            if(_repo.Delete(id, userId))
            {
                return "poof.";
            }
            throw new Exception("ruh roh");
        }
    }
}