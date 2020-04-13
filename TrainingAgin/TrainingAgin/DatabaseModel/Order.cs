using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingAgin.DatabaseModel
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmpoyeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
