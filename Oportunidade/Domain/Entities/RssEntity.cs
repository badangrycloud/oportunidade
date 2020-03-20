using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class RssEntity
    {
        public RssEntity()
        {
            Items = new List<ItemEntity>();
        }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime LastBuildDate { get; set; }
        public List<ItemEntity> Items { get; set; }
    }
}
