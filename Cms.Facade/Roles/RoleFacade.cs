using Common.Application;
using MediatR;
using Cms.Application.Roles.Create;
using Cms.Application.Roles.Edit;
using Cms.Query.Roles.DTOs;
using Cms.Query.Roles.GetById;
using Cms.Query.Roles.GetList;

namespace Cms.Facade.Roles;

internal class RoleFacade : IRoleFacade
{
    private readonly IMediator _mediator;

    public RoleFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateRole(CreateRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditRole(EditRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<RoleDto?> GetRoleById(long roleId)
    {
        return await _mediator.Send(new GetRoleByIdQuery(roleId));
    }
    public async Task<List<RoleDto>> GetRoles()
    {
        return await _mediator.Send(new GetRoleListQuery());
    }
}