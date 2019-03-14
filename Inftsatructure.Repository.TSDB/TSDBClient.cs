using KairosDbClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inftsatructure.Repository.TSDB
{
    public class TSDBClient
    {
        RestClient client = new RestClient("http://localhost:8083");
    }
}
