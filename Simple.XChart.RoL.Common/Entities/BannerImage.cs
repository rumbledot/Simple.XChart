using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Entities;

public class BannerImage
{
    public int Id { get; set; }
    [StringLength(300)]
    public string ImageUrl { get; set; }
    [StringLength(300)]
    public string ImageLandscapeUrl { get; set; }
    [StringLength(300)]
    public string ImageAlt { get; set; }
    [StringLength(200)]
    public string Photographer { get; set; }
    [StringLength(300)]
    public string PhotographerUrl { get; set; }
    public DateTime DateUpdated { get; set; }
    [StringLength(10)]
    public string AverageColor { get; set; }
}
