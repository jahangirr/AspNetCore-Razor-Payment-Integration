using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JafEcomRCL.Model
{
    public class Item
    {

         [Key]
         public int Id { get; set; }
         public string ProductName { get; set; }
         
         
    }
}
