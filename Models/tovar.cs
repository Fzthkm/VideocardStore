using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Магазин.Models
{
    public class tovar
    {
        public int Id { get; set; }
        public int stoimost { get; set; }
        public string name { get; set; }
        public string Image { get; set; }
        public int kolichestvoNaSklade { get; set; }
        public string opisanie { get; set; }
        public string firma { get; set; }
        public string razmer { get; set; }
        public string color { get; set; }

        public List<otziv> otzivi { get; set; }
        public List<zakaz> zakazi { get; set; }
        public tovar()
        {
            zakazi = new List<zakaz>();
            otzivi = new List<otziv>();
        }
    }
}
