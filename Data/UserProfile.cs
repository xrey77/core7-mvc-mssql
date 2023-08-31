using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace core7_mvc_mssql.Data;

[Table("userprofile", Schema = "dbo")]    
public class UserProfile {

    [Key]
    [Column("Id",TypeName="int")]
    public int Id {get; set;}

    [Column("Userid",TypeName="varchar")]
    [StringLength(100)]
    public string Userid {get; set;}

    [Column("Lastname",TypeName="varchar")]
    [StringLength(20)]
    public string Lastname {get; set;}

    [Column("Firstname",TypeName="varchar")]
    [StringLength(20)]
    public string Firstname {get; set;}

    [Column("Userpic",TypeName="varchar")]
    [StringLength(100)]
    public string Userpic {get; set;}

    [Column("Mobile",TypeName="varchar")]
    [StringLength(40)]
    public string Mobile {get; set;}

    [Column("Created_at",TypeName="datetime2")]
    public DateTime Created_at { get; set; }

    [Column("Updated_at",TypeName="datetime2")]
    public DateTime Updated_at { get; set; }

}