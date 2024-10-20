using Cms.Application._Utilities;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Cms.Domain.ProductAgg;
using Cms.Domain.ProductAgg.Repository;

namespace Cms.Application.Products.AddImage
{
    internal class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public AddProductImageCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);

            var productImage = new ProductImage(imageName, request.Sequence);
            product.AddImage(productImage);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}