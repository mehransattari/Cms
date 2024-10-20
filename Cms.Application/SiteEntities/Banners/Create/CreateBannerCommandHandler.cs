using Cms.Application._Utilities;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Cms.Domain.SiteEntities;
using Cms.Domain.SiteEntities.Repositories;

namespace Cms.Application.SiteEntities.Banners.Create;

public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;
    public CreateBannerCommandHandler(IBannerRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService
            .SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
        var banner = new Banner(request.Link, imageName, request.Position);

        _repository.Add(banner);
        await _repository.Save();
        return OperationResult.Success();
    }
}