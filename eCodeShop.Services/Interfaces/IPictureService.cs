using eCodeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCodeShop.Services.Interfaces
{
    public interface IPictureService
    {
        Picture GetPictureById(int id);
        List<Picture> GetPictures();
        bool SavePicture(Picture picture);
        bool AddProductPicture(int productId, int pictureId);
    }
}
