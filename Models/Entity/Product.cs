namespace Hoc_ASP.NET_MVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(200)]
        public string supplier { get; set; }

        public int? productTypeId { get; set; }

        [StringLength(100)]
        public string img0 { get; set; }

        [StringLength(100)]
        public string img1 { get; set; }

        [StringLength(100)]
        public string img2 { get; set; }

        [StringLength(100)]
        public string img3 { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
