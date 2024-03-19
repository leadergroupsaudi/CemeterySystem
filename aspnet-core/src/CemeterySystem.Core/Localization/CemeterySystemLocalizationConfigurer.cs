using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CemeterySystem.Localization
{
    public static class CemeterySystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CemeterySystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CemeterySystemLocalizationConfigurer).GetAssembly(),
                        "CemeterySystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
