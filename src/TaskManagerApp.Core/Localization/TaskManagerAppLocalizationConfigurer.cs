using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Reflection.Extensions;

namespace TaskManagerApp.Localization
{
    public static class TaskManagerAppLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags england", isDefault: true));
            localizationConfiguration.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flags tr"));
            localizationConfiguration.Languages.Add(new LanguageInfo("fr", "French", "famfamfam-flags fr"));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TaskManagerAppConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TaskManagerAppLocalizationConfigurer).GetAssembly(),
                        "TaskManagerApp.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}