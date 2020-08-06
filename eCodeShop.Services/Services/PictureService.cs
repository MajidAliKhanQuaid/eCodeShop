using eCodeShop.Core.Entities;
using eCodeShop.Core.Interfaces;
using eCodeShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCodeShop.Services.Services
{
    public class PictureService : IPictureService
    {
        private IRepository<Picture> _pictureRepo;
        private IRepository<ProductPictureMapping> _productPicRepo;
        public PictureService(IRepository<Picture> pictureRepo, IRepository<ProductPictureMapping> productPicRepo)
        {
            _pictureRepo = pictureRepo;
            _productPicRepo = productPicRepo;
        }

        public Picture GetPictureById(int id)
        {
            return _pictureRepo.GetById(id);
        }

        public List<Picture> GetPictures()
        {
            return _pictureRepo.Table.ToList();
        }

        public bool SavePicture(Picture picture)
        {
            _pictureRepo.Insert(picture);
            return true;
        }

        public bool AddProductPicture(int productId, int pictureId)
        {
            _productPicRepo.Insert(new ProductPictureMapping()
            {
                PictureId = pictureId,
                ProductId = productId,
                IsDefault = false
            });
            return true;
        }

        public List<Picture> GetProductPictures(int productId)
        {
            return _productPicRepo.Table.Where(x => x.ProductId == productId)
                            .Select(x => x.Picture)
                            .ToList();
        }
    }
}
