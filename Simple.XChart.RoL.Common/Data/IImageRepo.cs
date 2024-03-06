using Simple.XChart.RoL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Data;

public interface IImageRepo
{
    IEnumerable<BannerImage> GetImages();
    IEnumerable<BannerImage> GetImagesFromDatabase();
    BannerImage GetImageFromDatabase(int id);
}
