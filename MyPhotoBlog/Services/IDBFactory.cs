using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoBlog.Services
{
    public interface IDBFactory
    {
        dynamic DB();
    }
}
