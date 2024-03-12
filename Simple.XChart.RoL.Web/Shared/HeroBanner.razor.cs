using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Web.Data;
using Simple.XChart.RoL.Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Simple.XChart.RoL.Web.Helpers;
using System.Drawing;
using System.ComponentModel;

namespace Simple.XChart.RoL.Web.Shared;

public partial class HeroBanner
{
    [Inject]
    public PexelsService pexelsService { get; set; }

    [Inject]
    private VerseService verseService { get; set; }
    [Inject]
    public RoLDatabaseHelper dbHelper { get; set; }
    private RoLDBContext context { get => dbHelper.context; }
    [Inject]
    public JSHelper js { get; set; }

    public BannerImage BannerImage { get; set; }
    public DateTime todaysDate { get; set; }
    private AttachVerse todaysVerse { get; set; }
    private string colorContrast { get; set; }


    protected async override Task OnInitializedAsync()
    {
        todaysDate = DateTime.Now;

        await GetBannerImageAsync();
        await GetTodaysVerseAsync();

        await InvokeAsync(() => StateHasChanged());
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (BannerImage != null && !string.IsNullOrEmpty(BannerImage.ImageLandscapeUrl))
        {
            await js.ChangeBannerImage(BannerImage.ImageLandscapeUrl);
        }
    }

    private async Task GetBannerImageAsync()
    {
        if (!context.BannerImages.AsNoTracking().Any())
        {
            var photoTheme = await dbHelper.GetAppInformation("PhotoTheme");
            var bannerImages = await pexelsService.GetBannerImages(photoTheme.FirstOrDefault()?.InfoValue ?? "Nature");
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
        CalcBannerTextColor();
    }

    private void CalcBannerTextColor() 
    {
        var conv = new ColorConverter();
        var avgColor  = (Color)conv.ConvertFromString(BannerImage.AverageColor);
        colorContrast = (((avgColor.R + avgColor.B + avgColor.G) / 3) > 128) ? "text-black" : "text-white";
        //colorContrast = string.Concat("#", (255 - avgColor.R).ToString("X2"), (255 - avgColor.G).ToString("X2"), (255 - avgColor.B).ToString("X2"));
    }

    private async Task GetTodaysVerseAsync()
    {
        var updatedTodayVerse = await dbHelper.GetTodayVerseAsync();

        if (updatedTodayVerse == null)
        {
            var todaysVerseResponse = await verseService.GetTodayVerse();
            await dbHelper.UpdateTodayVerseAsync(todaysVerseResponse.verse);
        }
        else
        {
            todaysVerse = new AttachVerse
            {
                Text = updatedTodayVerse.Text,
                VerseId = updatedTodayVerse.VerseId,
                BibleId = updatedTodayVerse.BibleId
            };
        }
    }
}
