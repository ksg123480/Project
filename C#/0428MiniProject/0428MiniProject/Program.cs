using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            
            if(app.Init() == true)
                app.Run();
            app.Exit();
        }
    }
}
