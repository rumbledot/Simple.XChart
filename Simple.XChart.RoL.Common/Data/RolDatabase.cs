using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Simple.XChart.RoL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.XChart.RoL.Common.Data;

public class RolDatabase
{
    public string connectionString { get; private set; }

    public RolDatabase(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task<string?> GetAppInformationValue(string code)
    {
        using var conn=new SqlConnection(connectionString);
        return await conn.ExecuteScalarAsync<string>("SELECT Information FROM AppInformations WHERE Code=@code"
            , new { code });
    }

    public async Task<AppInformation?> GetAppInformation(string code)
    {
        using var conn = new SqlConnection(connectionString);
        return await conn.QueryFirstOrDefaultAsync<AppInformation>("SELECT * FROM AppInformations WHERE Code=@code"
            , new { code });
    }

    public async Task SaveAppInformation(string code, string info)
    {
        using var conn = new SqlConnection(connectionString);
        var existing = await GetAppInformation(code);
        if (existing != null)
        {
            existing.Information = info;
            existing.DateUpdated = DateTime.Now;
            await conn.UpdateAsync(existing);

            return;
        }

        existing = new AppInformation();
        existing.Code = code;
        existing.Information = info;
        existing.DateUpdated = DateTime.Now;
        await conn.InsertAsync(existing);
    }
}
