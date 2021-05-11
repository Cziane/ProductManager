using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    class Product
    {
        public string title { get; set; }

        public string description { get; set; }

        private double _price;
        public double Price
        {
            get => this._price;

            set
            {
                if (this._price < 0)
                {
                    this._price = 0;
                }
                else
                {
                    this._price = value;
                }
            }
        }

        private ArrayList _illustrations;

        public Product(string title, string description, double price)
        {
            this.title = title;
            this.description = description;
            this.Price = price;
            this._illustrations = new ArrayList();
        }

        public Illustration GetIllustration(int index)
        {
            return (_illustrations[index] as Illustration);
        }

        public void AddIllustration(Illustration illu)
        {
            this._illustrations.Add(illu);
        }

        public List<Illustration> GetIllustrations()
        {
            LinkedList<Illustration> myList = new LinkedList<Illustration>();
            foreach(Illustration i in this._illustrations)
            {
                myList.AddLast(i);
            }
            return myList.ToList();
        }

        public override string ToString()
        {
            return this.title + "\n" + "Description : " + this.description + "\n"
                + "Price : " + this.Price + "€";
        }
    }
}
