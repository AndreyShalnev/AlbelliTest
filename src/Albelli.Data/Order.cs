using System;
using System.Collections.Generic;

namespace Albelli.Data
{
    public class Order : IGuidEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public List<Product> Products { get; set; }
        public decimal PackageWidth { get; set; }
    }
}
