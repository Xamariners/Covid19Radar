﻿using Covid19Radar.Background.Services;
using Covid19Radar.Api.DataAccess;
using Covid19Radar.Api.DataStore;
using Covid19Radar.Api.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Covid19Radar.Api.Extensions;

[assembly: FunctionsStartup(typeof(Covid19Radar.Background.Startup))]

namespace Covid19Radar.Background
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddCosmosClient();
            builder.Services.AddSingleton<ICosmos, Cosmos>();
            builder.Services.AddSingleton<INotificationService, NotificationService>();
            builder.Services.AddSingleton<ISequenceRepository, CosmosSequenceRepository>();
            builder.Services.AddSingleton<ITemporaryExposureKeyRepository, CosmosTemporaryExposureKeyRepository>();
            builder.Services.AddSingleton<ITemporaryExposureKeyExportRepository, CosmosTemporaryExposureKeyExportRepository>();
            builder.Services.AddSingleton<ITemporaryExposureKeyExportBatchService, TemporaryExposureKeyExportBatchService>();
            builder.Services.AddSingleton<ITemporaryExposureKeyDeleteBatchService, TemporaryExposureKeyDeleteBatchService>();
            builder.Services.AddSingleton<ITemporaryExposureKeySignatureInfoService, TemporaryExposureKeySignatureInfoService>();
            builder.Services.AddSingleton<ITemporaryExposureKeyBlobService, TemporaryExposureKeyBlobService>();
#if DEBUG
            builder.Services.AddSingleton<ITemporaryExposureKeySignService, TemporaryExposureKeySignServiceDebug>();
#else
            builder.Services.AddSingleton<ITemporaryExposureKeySignService, TemporaryExposureKeySignService>();
#endif

        }
    }
}

