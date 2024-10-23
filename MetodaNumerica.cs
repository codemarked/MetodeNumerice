using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodeNumerice
{
    public interface MetodaNumerica
    {
        Method GetMethod();

        void Run();
    }
}
