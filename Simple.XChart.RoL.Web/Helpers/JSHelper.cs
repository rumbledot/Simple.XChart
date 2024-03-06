using Microsoft.JSInterop;

namespace Simple.XChart.RoL.Web.Helpers;

public class JSHelper
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _jsRuntime;

    public JSHelper(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    private async Task WaitForReference()
    {
        if (_accessorJsRef.IsValueCreated is false)
        {
            _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/bannerImage.js"));
        }
    }

    public async Task ChangeBannerImage(string imageUrl)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("changeBannerBackground", imageUrl);
    }
}
