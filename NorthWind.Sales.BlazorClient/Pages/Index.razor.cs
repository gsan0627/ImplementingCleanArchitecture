using Microsoft.AspNetCore.Components;
using NorthWind.Sales.BlazorClient.Exceptions;
using NorthWind.Sales.BlazorClient.Services;
using NorthWind.Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Sales.BlazorClient.Pages
{
    public partial class Index
    {
        [Inject]
        public NorthWindApiClient service { get; set; }

        CreateOrderDTO Order =
            new CreateOrderDTO
            {
                OrderDetails = new List<CreateOrderDetailDTO>()
            };
        string Message;
        HttpCustomException Exception;

        void AddProduct()
        {
            Order.OrderDetails.Add(new CreateOrderDetailDTO());
        }

        async Task Send()
        {
            try
            {
                var orderId = await service.CreateOrder(Order);
                Message = $"Order {orderId} creada";
                Exception = null;
            }
            catch (HttpCustomException ex)
            {            
                Exception = ex;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                Exception = null;
            }
        }

    }
}
