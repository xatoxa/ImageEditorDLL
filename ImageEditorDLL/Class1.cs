using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ImageEditorDLL
{
    
    [Guid("5B8AC727-DA4E-430F-B23E-B5EB5D01565A")]
    internal interface IMyClass
    {
        [DispId(1)]

        //методы, которые будут вызываться извне
        //print - просто пример, потом её надо будет удалить
        string printin1C(string msg);

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

        public string printin1C(string msg)
        {
            return msg;
        }

        public Image Cut_image(Image image, uint x1, uint y1, uint x2, uint y2)
        {

            return null; //заглушка, должна возвратить Image;
        }

        public Image Insert_image(Image image1, uint x1, uint y1, Image image2)
        {


            return null;
        }
    }



}
