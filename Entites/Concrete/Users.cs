﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Concrete
{
    public class Users:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
