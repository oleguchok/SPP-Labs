using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ImageViewer.Model
{
    public class Image
    {
        private ImageSource image;
        private string name;

        public Image(ImageSource image, string name)
        {
            this.image = image;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public ImageSource ImageSrc
        {
            get { return image; }
        }

        public string Name
        {
            get { return name; }
        }


    }
}
