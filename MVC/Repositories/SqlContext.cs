using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Repositories
{
    public class SqlContext :DbContext
    {
        private SqlContext sqlContext { get }
    }
}