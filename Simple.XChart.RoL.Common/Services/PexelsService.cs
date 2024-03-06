using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PexelsDotNetSDK.Api;
using PexelsDotNetSDK.Models;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Common.Models.Pexels;
using static System.Net.Mime.MediaTypeNames;

namespace Simple.XChart.RoL.Common.Services;

public class PexelsService
{
    private readonly PexelsClient pexelClient;

    public PexelsService(string apiKey)
    {
        pexelClient = new PexelsClient(apiKey);
    }

    public async Task<PhotoPage> GetSearchPhoto(string photoQuery, PexelsOrientation orientation = PexelsOrientation.landscape, int page = -1, int pageSize = 10)
    {
        if (page == -1) 
        {
            var rnd = new Random((int)DateTime.Now.TimeOfDay.TotalSeconds);
            page = rnd.Next(60);
        }

        return await pexelClient.SearchPhotosAsync(photoQuery, orientation.ToString(), "small", page: page, pageSize: pageSize);
    }

    public async Task<IEnumerable<BannerImage>> GetBannerImages()
    {
        var response = await GetSearchPhoto("Nature");
        var bannerImages = new List<BannerImage>();
        var bannerImage = new BannerImage();
        foreach (var image in response.photos)
        {
            bannerImage = new BannerImage();

            bannerImage.DateUpdated = DateTime.Now;
            bannerImage.Photographer = image.photographer;
            bannerImage.PhotographerUrl = image.photographerUrl;
            bannerImage.ImageUrl = image.url;
            bannerImage.ImageLandscapeUrl = image.source.landscape;
            bannerImage.ImageAlt = image.alt;

            bannerImages.Add(bannerImage);
        }

        return bannerImages;
    }
}
