using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Магазин.Models
{
    public class otziv
    {
        public int Id { get; set; }
        public string text { get; set; }
        public int rate { get; set; }
        public int? tovarId { get; set; }
        public tovar tovar { get; set; }
    }
}
