using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class StartUp
    {
        static void Main()
        {
            var cntx = new LocalStoreContext();

            cntx.Database.Initialize(true);

            
        }
    }
}
