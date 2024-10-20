using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Domain.SellerAgg.Services;

namespace Cms.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public long UserId { get; private set; }
        public string CmsName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }

        private Seller()
        {
        }

        public Seller(long userId, string CmsName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(CmsName, nationalCode);
            UserId = userId;
            CmsName = CmsName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();

            if (domainService.IsValidSellerInformation(this) == false)
                throw new InvalidDomainDataException("اطلاعات نامعتبر است");

        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string CmsName, string nationalCode, SellerStatus status, ISellerDomainService domainService)
        {
            Guard(CmsName, nationalCode);
            if (nationalCode != NationalCode)
                if (domainService.NationalCodeExistInDataBase(nationalCode))
                    throw new InvalidDomainDataException("کدملی متعلق به شخص دیگری است");

            CmsName = CmsName;
            NationalCode = nationalCode;
            Status = status;
        }

        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است.");

            Inventories.Add(inventory);
        }

        public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(f => f.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            //TODO Check Inventories
            currentInventory.Edit(count, price, discountPercentage);
        }

        public void Guard(string CmsName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(CmsName, nameof(CmsName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }
    }
}