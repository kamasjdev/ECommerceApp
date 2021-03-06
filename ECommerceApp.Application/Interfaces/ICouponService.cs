﻿using ECommerceApp.Application.ViewModels.Coupon;
using ECommerceApp.Application.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceApp.Application.Interfaces
{
    public interface ICouponService
    {
        int AddCoupon(NewCouponVm coupon);
        void UpdateCoupon(NewCouponVm coupon);
        void DeleteCoupon(int id);
        ListForCouponVm GetAllCoupons(int pageSize, int pageNo, string searchString);
        NewCouponVm GetCouponForEdit(int id);
        CouponDetailsVm GetCouponDetail(int id);
        int AddCouponType(NewCouponTypeVm couponType);
        void UpdateCouponType(NewCouponTypeVm couponType);
        void DeleteCouponType(int id);
        ListForCouponTypeVm GetAllCouponsTypes(int pageSize, int pageNo, string searchString);
        NewCouponTypeVm GetCouponTypeForEdit(int id);
        CouponTypeDetailsVm GetCouponTypeDetail(int id);
        int AddCouponUsed(NewCouponUsedVm couponUsedVm);
        void UpdateCouponUsed(NewCouponUsedVm couponUsedVm);
        void DeleteCouponUsed(int id);
        ListForCouponUsedVm GetAllCouponsUsed(int pageSize, int pageNo, string searchString);
        NewCouponTypeVm GetCouponUsedForEdit(int id);
        CouponUsedDetailsVm GetCouponUsedDetail(int id);
        IQueryable<NewCouponTypeVm> GetAllCouponsTypes();
        IQueryable<NewOrderVm> GetAllOrders();
        IQueryable<NewCouponUsedVm> GetAllCouponsUsed();
    }
}
