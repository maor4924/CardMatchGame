using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMatch
{
    public class ImagesLogic : BaseLogic
    {

        //Get list of all images
        public List<ImageModel> GetAllImages()
        {

            var query = from img in DB.Images
                        select new ImageModel
                        {
                            id = img.ImageID,
                            imgName = img.ImageName
                        };
            return query.ToList();
        }
    }
}
