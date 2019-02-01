using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ImageEditorDLL
{
    
    [Guid("5B8AC727-DA4E-430F-B23E-B5EB5D01565A")]
    internal interface IMyClass
    {
        [DispId(1)]

        //методы, которые будут вызываться извне

        Image Cut_image(Image image, uint x1, uint y1, uint x2, uint y2);

        Image Insert_image(Image image1, uint x1, uint y1, Image image2);

    }


    [Guid("E101E314-0281-4665-8FAB-64408C4C638B"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IMyEvents
    {

    }


    [Guid("9AD67B75-A434-41DB-9B2C-C6E81E815B77"), ClassInterface(ClassInterfaceType.None),
        ComSourceInterfaces(typeof(IMyEvents))]
    public class MyClass : IMyClass
    {
        //реализация методов
    
        public Image Cut_image(Image image, uint x1, uint y1, uint x2, uint y2)
        {
            if (image == null)
            {
                MessageBox.Show("image not found;\nimage == NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (x2 > image.Width)
            {
                MessageBox.Show("x2 exceeds the width of image1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (y2 > image.Height)
            {
                MessageBox.Show("y2 exceeds the height of image1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (x1 > (image.Width - x2))
            {
                MessageBox.Show("x1 exceeds the new width of image1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (y1 > (image.Height - y2))
            {
                MessageBox.Show("y1 exceeds the new height of image1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


            Bitmap bmp = image as Bitmap;

            Bitmap result = bmp.Clone(new Rectangle((int)x1, (int)y1, (int)x2, (int)y2),bmp.PixelFormat);

            return result;
        }



        public Image Insert_image(Image image1, uint x1, uint y1, Image image2)
        {
            if (image1 == null)
            {
                MessageBox.Show("image1 not found;\nimage1 == NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (image2 == null)
            {
                MessageBox.Show("image 2 not found;\nimage2 == NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (x1 > image1.Width)
            {
                MessageBox.Show("x exceeds the width of image1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (y1 > image1.Height)
            {
                MessageBox.Show("y exceeds the height of image1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


            Bitmap result = new Bitmap(image1.Width, image1.Height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(image1, 0, 0, image1.Width, image1.Height);
                g.DrawImage(image2, x1, y1, image2.Width, image2.Height);

                return result;
            }
        }
    }
}