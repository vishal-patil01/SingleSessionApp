﻿using SingleSession.ModelLayer.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SingleSession.DataAccessLayer.Interface
{
    public interface IUserRepository
    {
        public Task<User> Login(User user);
        public Task<bool> Register(User user);
    }
}