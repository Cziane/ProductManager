using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ProductManager.Model.Entities;

namespace ProductManager.Model
{
    class Illustration
    {
        public int? Id {get;set;}
        public string path { get; set; }

        public string title { get; set; }

        public Illustration(string path, string title)
        {
            this.path = path;
            this.title = title;
        }



        public Illustration(EIllustration eIllu)
        {
            this.Id = eIllu.ID;
            this.title = eIllu.title;
            this.path = eIllu.path;
        }


        public dynamic GetContent()
        {
            return null;
        }
    }
}
