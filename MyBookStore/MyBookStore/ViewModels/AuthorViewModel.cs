﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookStore.ViewModels
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}