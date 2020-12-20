﻿using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.NotificationService.Localization;
using Volo.Abp.EventBus;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.NotificationService
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(AbpEventBusModule)
    )]
    public class NotificationServiceDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<NotificationServiceDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<NotificationServiceResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/EasyAbp/NotificationService/Localization");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("EasyAbp.NotificationService", typeof(NotificationServiceResource));
            });
        }
    }
}
