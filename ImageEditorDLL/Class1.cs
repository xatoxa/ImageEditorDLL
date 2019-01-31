using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ImageEditorDLL
{
    
    [Guid("5B8AC727-DA4E-430F-B23E-B5EB5D01565A")]
    internal interface IMyClass
    {
        [DispId(1)]

        //методы, которые будут вызываться извне

        string printin1C(string msg);

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
    }



}
