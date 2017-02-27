using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOP_MVC.DataLayer
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            RegisterDate = DateTime.Now;
        }
        public int ID { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
