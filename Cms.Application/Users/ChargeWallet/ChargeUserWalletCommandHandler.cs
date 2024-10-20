﻿using Common.Application;
using Cms.Domain.UserAgg;
using Cms.Domain.UserAgg.Repository;

namespace Cms.Application.Users.ChargeWallet;

internal class ChargeUserWalletCommandHandler : IBaseCommandHandler<ChargeUserWalletCommand>
{
    private readonly IUserRepository _repository;

    public ChargeUserWalletCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var wallet = new Wallet(request.Price, request.Description, request.IsFinally, request.Type);
        user.ChargeWallet(wallet);
        await _repository.Save();
        return OperationResult.Success();
    }
}