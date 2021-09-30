using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolrNetCoreAPIs
{
    public interface ISolrIndexService<T>
    {
        bool AddUpdate(T document);
        bool Delete(T document);
    }
}
