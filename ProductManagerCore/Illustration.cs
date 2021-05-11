using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProductManager
{
    class Illustration
    {
        public string path { get; set; }

        public string title { get; set; }

        public Illustration(string path, string title)
        {
            this.path = path;
            this.title = title;
        }

        public Illustration(string path)
        {
            this.path = path;
        }

        public dynamic GetContent()
        {
            return null;
        }
    }
}
