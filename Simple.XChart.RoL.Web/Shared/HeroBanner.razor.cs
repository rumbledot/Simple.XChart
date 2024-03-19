using System.Drawing;
using Microsoft.AspNetCore.Components;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.RoL.Common.Entities;
using Simple.XChart.RoL.Web.Helpers;
using Simple.XChart.RoL.Common.Helpers;

namespace Simple.XChart.RoL.Web.Shared;

public partial class HeroBanner
{
    [Inject]
    public PexelsService pexelsService { get; set; }

    [Inject]
    private VerseService verseService { get; set; }
    [Inject]
    public RoLRepositoryHelper db { get; set; }
    [Inject]
    public JSHelper js { get; set; }

    public BannerImage bannerImage { get; set; }
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
        if (bannerImage != null && !string.IsNullOrEmpty(bannerImage.ImageLandscapeUrl))
        {
            await js.ChangeBannerImage(bannerImage.ImageLandscapeUrl);
        }
    }

    private async Task GetBannerImageAsync()
    {
        bannerImage = await db.TryGetBannerImage();
        CalcBannerTextColor();
    }

    private void CalcBannerTextColor()
    {
        var conv = new ColorConverter();
        var avgColor  = (Color)conv.ConvertFromString(bannerImage.AverageColor);
        colorContrast = (((avgColor.R + avgColor.B + avgColor.G) / 3) > 128) ? "text-black" : "text-white";
    }

    private async Task GetTodaysVerseAsync()
    {
        var updatedTodayVerse = await db.TryGetTodayVerse();

        if (updatedTodayVerse == null)
        {
            var todaysVerseResponse = await verseService.GetTodayVerse();
            await db.UpdateTodayVerse(todaysVerseResponse.verse);
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
