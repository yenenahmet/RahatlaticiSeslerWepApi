using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknasyonA.Models
{
    public class CategoryDeatilModel
    {
        public int CategoryId { get; set; }
        public String CategoryDeatilTitle { get; set; }
        public String CategoryExplanation { get; set; }
        public String CategoryMp3Path { get; set; }
    }
}