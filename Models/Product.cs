using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrderService.Models;
public class Product
{
    [Key]
    public int Id { get; set; }


    [Column(TypeName = "nvarchar(50)"),
    Required(ErrorMessage = "{0}不可空白"),
    MinLength(3, ErrorMessage = "{0}至少需要{1}字數"),
    MaxLength(50, ErrorMessage = "{0}不可超過{1}字數")]
    public string Name { get; set; }
   
    [Column(TypeName = "nvarchar(150)"),
    Required(ErrorMessage = "{0}不可空白"),
    MinLength(3, ErrorMessage = "{0}至少需要{1}字數"),
    MaxLength(150, ErrorMessage = "{0}不可超過{1}字數")]
    public string Description { get; set; }
   
    [Column(TypeName = "money")]
    [Required(ErrorMessage = "{0}不可空白"),
        Range(1, 100000, ErrorMessage = "訂價需1~100000元的範圍")]
    public decimal Price { get; set; }
}
