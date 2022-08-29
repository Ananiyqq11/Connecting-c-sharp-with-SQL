using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExcer01
{
    class Item
    {
        public int Number { get; set; }
        public string Date { get; set; }
        public string Sku { get; set; }
        public string Item_Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public bool IsAvailable { get; set; }

        static List<Item> _items = new List<Item>();
        public static Item findone(String name)
        {
            return _items.Find(item => item.Item_Name == name);
        }

        //public String Count {get;set;}
        


        public void save()
        {
            _items.Add(this);
            Console.WriteLine("Saved into the List(_items) Successfully");
        }
      static public List<Item> Getallproducts()
        {
            return _items;
        }

       

    }

}
