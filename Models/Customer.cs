﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eden.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubcribedToNewsletter { get; set; }
    }
}