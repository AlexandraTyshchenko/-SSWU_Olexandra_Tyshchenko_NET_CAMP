﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class DessertChef : IRequestProcessor,ISender
    {
        public DessertChef(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IMediator mediator { get; set ; }
        public void CompleteOrder(List<OrderItem> orderItem)
        {
            if (ReturnFoundOrder(orderItem) != null)
            {
                Send(new Tiramisu());
            }    
        }
        public TypeOfOrder? ReturnFoundOrder(List<OrderItem> orderItem)
        {
            return orderItem.FirstOrDefault(x => x.Order == TypeOfOrder.Dessert)?.Order;
        }
        public void Send(object ob)
        {
            if(ob is ICompletedOrder completedOrder)
            {
                mediator.Notify(completedOrder);
            }
          
        }
    }
}
