﻿using AuraAndTheChamberOfSecrets.Models.User;

namespace AuraAndTheChamberOfSecrets.Repo.Interface
{
    public interface IUserProfileRepository : IBaseRepository<UserProfile>
    {
        UserProfile GetSingleByUsername(string username);
    }
}
