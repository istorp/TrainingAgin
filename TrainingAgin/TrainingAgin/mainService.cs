using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainingAgin.DatabaseModel;

namespace TrainingAgin
{
    public class mainService : IHostedService
    {
        private readonly OrderContext orderContext;
        private IHostApplicationLifetime lifetime;

        public mainService(OrderContext orderContext, IHostApplicationLifetime lifetime)
        {
            this.orderContext = orderContext;
            this.lifetime = lifetime;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var order1 = new Order()
            {
                EmpoyeeID=1
            };
            orderContext.Orders.Add(order1);
            orderContext.SaveChanges();

            var allaOrderes = orderContext.Orders.Select(o => new  { OrderId = o.OrderID }).ToList();
            foreach (var item in allaOrderes)
            {
                Console.WriteLine($"OrderID: {item.OrderId}");
            }
            Console.WriteLine("Hallo Anders");
            Console.ReadKey();
            lifetime.StopApplication();
            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
