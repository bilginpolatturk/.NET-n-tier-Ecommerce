﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
    }
}
