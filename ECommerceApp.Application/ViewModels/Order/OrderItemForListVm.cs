﻿using AutoMapper;
using ECommerceApp.Application.Mapping;
using ECommerceApp.Application.ViewModels.Coupon;
using ECommerceApp.Application.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Application.ViewModels.Order
{
    public class OrderItemForListVm : IMapFrom<ECommerceApp.Domain.Model.OrderItem>
    {
        public int Id { get; set; }
        public int ItemId { get; set; }   // 1:Many Item OrderItem  
        public int ItemOrderQuantity { get; set; }
        public int OrderId { get; set; }  // Many : 1 OrderItem Order
        public int? CouponUsedId { get; set; }
        public int? RefundId { get; set; } // 1:Many Refund OrderItem

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ECommerceApp.Domain.Model.OrderItem, OrderItemForListVm>().ReverseMap();
        }
    }
}