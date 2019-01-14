using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.ServiceConsumer
{
    public interface IApiServiceConsumer
    {
        T GetApiData<T>(string url);
    }
}
