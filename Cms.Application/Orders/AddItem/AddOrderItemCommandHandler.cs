﻿using Common.Application;
using Cms.Domain.OrderAgg;
using Cms.Domain.OrderAgg.Repository;
using Cms.Domain.SellerAgg.Repository;

namespace Cms.Application.Orders.AddItem;

public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
{
    private readonly IOrderRepository _repository;
    private readonly ISellerRepository _sellerRepository;

    public AddOrderItemCommandHandler(IOrderRepository repository, ISellerRepository sellerRepository)
    {
        _repository = repository;
        _sellerRepository = sellerRepository;
    }

    public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
        if (inventory == null)
            return OperationResult.NotFound();

        if (inventory.Count < request.Count)
            return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");

        var order = await _repository.GetCurrentUserOrder(request.UserId);
        if (order == null)
            order = new Order(request.UserId);

        order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));

        if (ItemCountBeggerThanInventoryCount(inventory, order))
            return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");

        await _repository.Save();
        return OperationResult.Success();
    }

    private bool ItemCountBeggerThanInventoryCount(InventoryResult inventory, Order order)
    {
        var orderItem = order.Items.First(f => f.InventoryId == inventory.Id);
        if (orderItem.Count > inventory.Count)
            return true;

        return false;
    }
}