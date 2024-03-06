using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Models.Pexels;

public class PexelsPhotoResponse
{
    public int total_results { get; set; }
    public int page { get; set; }
    public int per_page { get; set; }
    public PexelsPhoto[] photos { get; set; }
    public string next_page { get; set; }
}

public class PexelsPhoto
{
    public int id { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public string url { get; set; }
    public string photographer { get; set; }
    public string photographer_url { get; set; }
    public int photographer_id { get; set; }
    public string avg_color { get; set; }
    public PexelsPhotoSource src { get; set; }
    public bool liked { get; set; }
    public string alt { get; set; }
}

public class PexelsPhotoSource
{
    public string original { get; set; }
    public string large2x { get; set; }
    public string large { get; set; }
    public string medium { get; set; }
    public string small { get; set; }
    public string portrait { get; set; }
    public string landscape { get; set; }
    public string tiny { get; set; }
}

public enum PexelsOrientation
{
    landscape,
    portrait,
    square
}

public enum PexelsSize
{
    large,
    medium,
    small
}