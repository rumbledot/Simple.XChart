using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class BannerImage
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string ImageLandscapeUrl { get; set; }
    public string ImageAlt { get; set; }
    public string Photographer { get; set; }
    public string PhotographerUrl { get; set; }
    public DateTime DateUpdated { get; set; }
}
