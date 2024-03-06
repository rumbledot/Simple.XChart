using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Web.Data;
using Simple.XChart.RoL.Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Simple.XChart.RoL.Web.Helpers;

namespace Simple.XChart.RoL.Web.Shared;

public partial class HeroBanner
{
    [Inject]
    public PexelsService pexelsService { get; set; }

    [Inject]
    public RoLDatabaseHelper dbHelper { get; set; }
    [Inject]
    public JSHelper js { get; set; }

    public RoLDBContext context { get => dbHelper.context; }
    public BannerImage BannerImage { get; set; }


    protected async override Task OnInitializedAsync()
    {
        if (!context.BannerImages.Any())
        {
            var bannerImages = await pexelsService.GetBannerImages();
            foreach (var bannerImage in bannerImages) 
            {
                context.BannerImages.Add(bannerImage);
            }
            context.SaveChanges();
        }

        var ids = context.BannerImages.Select(x => x.Id).ToArray();
        var rnd = new Random(DateTime.Now.Millisecond);
        var rndId = ids[rnd.Next(0, ids.Length - 1)];

        BannerImage = await context.BannerImages.FirstOrDefaultAsync(x => x.Id == rndId);
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (BannerImage != null && !string.IsNullOrEmpty(BannerImage.ImageLandscapeUrl))
        {
            await js.ChangeBannerImage(BannerImage.ImageLandscapeUrl);
        }
    }
}
