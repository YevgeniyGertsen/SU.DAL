﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SU.BLL.Model
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
    }
}
