﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Application.ViewModels.Coupon;
using ECommerceApp.Application.ViewModels.Order;
using ECommerceApp.Domain.Interface;
using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceApp.Application.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepo;
        private readonly IMapper _mapper;

        public CouponService(ICouponRepository couponRepo, IMapper mapper)
        {
            _couponRepo = couponRepo;
            _mapper = mapper;
        }

        public int AddCoupon(NewCouponVm couponVm)
        {
            var coupon = _mapper.Map<Coupon>(couponVm);
            var id = _couponRepo.AddCoupon(coupon);
            return id;
        }

        public int AddCouponType(NewCouponTypeVm couponTypeVm)
        {
            var couponType = _mapper.Map<CouponType>(couponTypeVm);
            var id = _couponRepo.AddCouponType(couponType);
            return id;
        }

        public int AddCouponUsed(NewCouponUsedVm couponUsedVm)
        {
            var couponUsed = _mapper.Map<CouponUsed>(couponUsedVm);
            var id = _couponRepo.AddCouponUsed(couponUsed);
            return id;
        }

        public void DeleteCoupon(int id)
        {
            _couponRepo.DeleteCoupon(id);
        }

        public void DeleteCouponType(int id)
        {
            _couponRepo.DeleteCouponType(id);
        }

        public void DeleteCouponUsed(int id)
        {
            _couponRepo.DeleteCouponUsed(id);
        }

        public ListForCouponVm GetAllCoupons(int pageSize, int pageNo, string searchString)
        {
            var coupons = _couponRepo.GetAllCoupons().Where(coupon => coupon.Code.StartsWith(searchString))
                .ProjectTo<CouponForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var couponsToShow = coupons.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var couponsList = new ListForCouponVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Coupons = couponsToShow,
                Count = coupons.Count
            };

            return couponsList;
        }

        public ListForCouponTypeVm GetAllCouponsTypes(int pageSize, int pageNo, string searchString)
        {
            var couponTypes = _couponRepo.GetAllCouponsTypes().Where(coupon => coupon.Type.StartsWith(searchString))
                .ProjectTo<CouponTypeForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var couponTypesToShow = couponTypes.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var couponTypesList = new ListForCouponTypeVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                CouponTypes = couponTypesToShow,
                Count = couponTypes.Count
            };

            return couponTypesList;
        }

        public IQueryable<NewCouponTypeVm> GetAllCouponsTypes()
        {
            var couponTypes = _couponRepo.GetAllCouponsTypes();
            var couponTypesVm = couponTypes.ProjectTo<NewCouponTypeVm>(_mapper.ConfigurationProvider);
            return couponTypesVm;
        }

        public ListForCouponUsedVm GetAllCouponsUsed(int pageSize, int pageNo, string searchString)
        {
            var couponsUsed = _couponRepo.GetAllCouponsUsed()//.Where(coupon => coupon..StartsWith(searchString))
                .ProjectTo<CouponUsedForListVm>(_mapper.ConfigurationProvider)
                .ToList();
            var couponsUsedToShow = couponsUsed.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            var couponsUsedList = new ListForCouponUsedVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                CouponsUsed = couponsUsedToShow,
                Count = couponsUsed.Count
            };

            return couponsUsedList;
        }

        public IQueryable<NewCouponUsedVm> GetAllCouponsUsed()
        {
            var couponsUsed = _couponRepo.GetAllCouponsUsed();
            var couponsUsedVm = couponsUsed.ProjectTo<NewCouponUsedVm>(_mapper.ConfigurationProvider);
            return couponsUsedVm;
        }

        public IQueryable<NewOrderVm> GetAllOrders()
        {
            var orders = _couponRepo.GetAllOrders();
            //var ordersVm = _mapper.Map<List<NewOrderVm>(orders);
            var ordersVm = orders.ProjectTo<NewOrderVm>(_mapper.ConfigurationProvider);
            return ordersVm;
        }

        public CouponDetailsVm GetCouponDetail(int id)
        {
            var couponDetails = _couponRepo.GetCouponById(id);
            var couponDetailsVm = _mapper.Map<CouponDetailsVm>(couponDetails);
            return couponDetailsVm;
        }

        public NewCouponVm GetCouponForEdit(int id)
        {
            var coupon = _couponRepo.GetCouponById(id);
            var couponVm = _mapper.Map<NewCouponVm>(coupon);
            return couponVm;
        }

        public CouponTypeDetailsVm GetCouponTypeDetail(int id)
        {
            var couponType = _couponRepo.GetCouponTypeById(id);
            var couponTypeVm = _mapper.Map<CouponTypeDetailsVm>(couponType);
            return couponTypeVm;
        }

        public NewCouponTypeVm GetCouponTypeForEdit(int id)
        {
            var couponType = _couponRepo.GetCouponTypeById(id);
            var couponTypeVm = _mapper.Map<NewCouponTypeVm>(couponType);
            return couponTypeVm;
        }

        public CouponUsedDetailsVm GetCouponUsedDetail(int id)
        {
            var couponUsed = _couponRepo.GetCouponUsedById(id);
            var couponUsedVm = _mapper.Map<CouponUsedDetailsVm>(couponUsed);
            return couponUsedVm;
        }

        public NewCouponTypeVm GetCouponUsedForEdit(int id)
        {
            var couponUsed = _couponRepo.GetCouponUsedById(id);
            var couponUsedVm = _mapper.Map<NewCouponTypeVm>(couponUsed);
            return couponUsedVm;
        }

        public void UpdateCoupon(NewCouponVm couponVm)
        {
            var coupon = _mapper.Map<Coupon>(couponVm);
            _couponRepo.UpdateCoupon(coupon);
        }

        public void UpdateCouponType(NewCouponTypeVm couponTypeVm)
        {
            var couponType = _mapper.Map<CouponType>(couponTypeVm);
            _couponRepo.UpdateCouponType(couponType);
        }

        public void UpdateCouponUsed(NewCouponUsedVm couponUsedVm)
        {
            var couponUsed = _mapper.Map<CouponUsed>(couponUsedVm);
            _couponRepo.UpdateCouponUsed(couponUsed);
        }
    }
}
