using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Магазин.Models
{
    public class filtr
    {
        public filtr(List<tovar> stuffs, int? stuff, string name)
        {
            stuffs.Insert(0, new tovar { name = "Все", Id = 0 });
        }
        public SelectList tovari { get; private set; } // список товара
        public int? SelectedStuff { get; private set; }   // выбранный товар
        public string SelectedName { get; private set; }    // введенное название
    }
}
