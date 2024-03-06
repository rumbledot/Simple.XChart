using Simple.XChart.RoL.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Services;

public class VerseService
{
    private readonly HttpClient verseClient;

    public VerseService(HttpClient httpClient)
    {
        verseClient = httpClient;
    }

    public async Task<TodayVerseResponse> GetTodayVerse()
    {
        return await verseClient.GetFromJsonAsync<TodayVerseResponse>($"{verseClient.BaseAddress}/get?format=json&order=daily");
    }

    public async Task<TodayVerseResponse> GetRandomVerse()
    {
        return await verseClient.GetFromJsonAsync<TodayVerseResponse>($"{verseClient.BaseAddress}/get?format=json&order=random");
    }
}
