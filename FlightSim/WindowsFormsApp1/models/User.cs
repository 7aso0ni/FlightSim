﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
    internal class User
    {
        protected static int userId;
        private int instanceUserId;
        protected string username;
        protected string password;
        protected string email;
        protected string role;

        public User() { }

        public User(string username, string password, string email, string role)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.role = role;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Role { get => role; set => role = value; }
        public int UserId { get => userId; set => userId = value; }
        public int InstanceUserID { get => instanceUserId; set => instanceUserId = value; }

    }
}
