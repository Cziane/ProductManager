using ProductManager.Model.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Model
{
    class Product
    {
        public int? Id { get; set; }
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

        private List<Illustration> _illustrations;

        public List<Illustration> Illustrations { get => this._illustrations; }

        public Product(string title, string description, double price)
        {
            this.title = title;
            this.description = description;
            this.Price = price;
            this._illustrations = new List<Illustration>();
        }

        public Product(EProduct eprod)
        {
            this.Id = eprod.ID;
            this.title = eprod.Title;
            this.description = eprod.Description;
            this.Price = eprod.Price;
            this._illustrations = new List<Illustration>();
            foreach(EIllustration i in eprod.Illustrations)
            {
                this._illustrations.Add(new Illustration(i));
            }
        }

        public Illustration GetIllustration(int index)
        {
            return _illustrations[index];
        }

        public void AddIllustration(Illustration illu)
        {
            this._illustrations.Add(illu);
        }


        public override string ToString()
        {
            return this.title + " :" + this.Price + "€"; 
        }
    }
}
