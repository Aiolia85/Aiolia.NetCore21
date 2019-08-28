﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Aiolia.NetCore21.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
           // 最小的日志输出级别
           .MinimumLevel.Information()
           // 日志调用类命名空间如果以 Microsoft 开头，覆盖日志输出最小级别为 Information
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           // 配置日志输出到控制台
           .WriteTo.Debug()
           // 配置日志输出到文件，文件输出到当前项目的 logs 目录下
           // 日记的生成周期为每天
           //.WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Day)
           // 创建 logger
           .CreateLogger();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .UseSerilog();
    }
}
