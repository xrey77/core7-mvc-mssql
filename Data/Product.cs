using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace core7_mvc_mssql.Data;

[Table("products", Schema = "dbo")]    
public class Product {

        [Key]
        [Column("id",TypeName="int")]
        public int Id { get; set; }

        [Column("prod_name",TypeName="varchar")]
        [StringLength(100)]
        public string Prod_name { get; set; }

        [Column("prod_desc",TypeName="varchar")]
        [StringLength(100)]
        public string Prod_desc { get; set; }

        [Column("prod_stockqty",TypeName="int")]
        public int Prod_stockqty { get; set; }

        [Column("prod_unit",TypeName="varchar")]
        [StringLength(10)]
        public string Prod_unit { get; set; }

        [Column("prod_cost",TypeName="decimal")]
        public decimal Prod_cost { get; set; }

        [Column("prod_sell",TypeName="decimal")]
        public decimal Prod_sell { get; set; }

        [Column("prod_pic",TypeName="varchar")]
        [StringLength(100)]
        public string Prod_pic { get; set; }

        [Column("prod_category",TypeName="varchar")]
        [StringLength(20)]
        public string Prod_category { get; set; }

        [Column("prod_saleprice",TypeName="decimal")]
        public decimal Prod_saleprice { get; set; }

        [Column("prod_alert",TypeName="int")]
        public int Prod_alert { get; set; }

        [Column("prod_critical",TypeName="int")]
        public int Prod_critical { get; set; }

        [Column("Prod_createdat",TypeName="datetime2")]
        public DateTime Prod_createdat { get; set; }

        [Column("Prod_updatedat",TypeName="datetime2")]
        public DateTime Prod_updatedat {get; set;}
}    
