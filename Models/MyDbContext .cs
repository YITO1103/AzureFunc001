/*
using System;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using Entity;
*/

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; // Npgsql.EntityFrameworkCore.PostgreSQLパッケージを追加


using Microsoft.Extensions.Configuration;
using Entity;

public class MyDbContext : DbContext
{
/*
    public MyDbContext() : base(GetConnectionString())
    {
    }
*/    
    public MyDbContext() : base(GetConnectionOptions())
    {

    }

    private static DbContextOptions<MyDbContext>  GetConnectionOptions()
    {

            //var connectionString = Environment.GetEnvironmentVariable("PostgreSQLConnectionString");
            // --------------------------------------------------
            // PostgreSQLに繋げてみる

            //直打ち
            var connectionString = "Server=sever-pg-a.postgres.database.azure.com;Database=postgres;Port=5432;User Id=postgres;Password=miumiu@0816;Ssl Mode=Require;";
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseNpgsql(connectionString) // Npgsqlプロバイダを使用
                .Options;

            return options;

    }



    private static string GetConnectionString()
    {
// SQL Database への接続
// エラー内容にあった、20.37.49.234をdb-01で許可したら通った
// FunctionApp120231012101939 | ネットワークの送信トラフィックの送信トラフィックに含まれてる
// 20.37.47.44, 20.37.47.58, 20.37.44.59, 20.37.46.91, 20.37.44.84, 20.37.48.86, 20.37.46.176, 20.37.48.32, 20.37.48.61, 20.37.48.116, 20.37.48.173, 20.37.48.230, 20.70.24.156, 20.70.24.164, 20.37.4.3, 20.70.25.86, 20.70.25.89, 20.37.4.208, 20.37.49.142, 20.37.49.183, 20.37.49.234, 20.37.49.248, 20.37.49.255, 20.37.51.66, 20.36.106.97
    // ADO.NET (SQL 認証)
    //return "Server=tcp:server-dev01.database.windows.net,1433;Initial Catalog=db-01;Persist Security Info=False;User ID=yuta.j.1103@gmail.com@server-dev01;Password=miumiu@0816;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

/*
local.settings.json ファイル（ローカル開発用）およびAzure Functionsアプリケーションのアプリケーション設定（本番環境用）に設定を追加します。

ローカル開発用の local.settings.json ファイル内で設定を定義します：
アプリケーション設定" ページで、新しい設定を追加します。DB接続文字列を設定するには、次のように設定します：

    名前: MyDbConnectionString（環境変数の名前）
    値: 実際のDB接続文字列

必要に応じて、他の設定も追加できます。

変更の保存:
設定を追加したら、変更を保存します。

アプリケーションの再起動:
アプリを再起動したら ファイヤーウォールの再設定

*/
return Environment.GetEnvironmentVariable("DbConnectionString");



        /*
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        return configuration["DbConnectionString"];
        */        
    }

    public DbSet<Employee> Employees { get; set; }
}
