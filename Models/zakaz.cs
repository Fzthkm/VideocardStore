using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public enum tip
{
    neOpredelen,
    samovivoz,
    dostavka //стоимость доставки - 10%
}

public enum mode
{

    neoplachen,
    oplachen
}

namespace Магазин.Models
{

    public class zakaz
    {
        public int Id { get; set; }
        public int kolichestvo { get; set; }
        public mode status { get; set; }
        public tip sposobDostavki { get; set; }
        public int tovarId { get; set; }
        public tovar tovar { get; set; }
        public string karta { get; set; }
        public string adres { get; set; }
        public string poluchatel { get; set; }
    }
}
