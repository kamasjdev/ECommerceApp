﻿using AutoMapper;
using ECommerceApp.Application.Mapping;
using ECommerceApp.Application.ViewModels.Coupon;
using ECommerceApp.Application.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Application.ViewModels.Order
{
    public class OrderItemDetailsVm : IMapFrom<ECommerceApp.Domain.Model.OrderItem>
    {
        public int Id { get; set; }
        public int ItemId { get; set; }   // 1:Many Item OrderItem  
        public int ItemOrderQuantity { get; set; }
        public virtual ItemDetailsVm Item { get; set; }
        public int OrderId { get; set; }  // Many : 1 OrderItem Order
        public OrderDetailsVm Order { get; set; }
        public int? CouponUsedId { get; set; }
        public CouponUsedDetailsVm CouponUsed { get; set; } // 1:Many OrderItem Coupon discount can be used for many Items
        public int? RefundId { get; set; } // 1:Many Refund OrderItem
        public RefundDetailsVm Refund { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ECommerceApp.Domain.Model.CouponUsed, OrderItemDetailsVm>().ReverseMap();
        }
    }
}