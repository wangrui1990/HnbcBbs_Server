using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace HnbcInfo.Bbs.Localization
{
    public static class BbsLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BbsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BbsLocalizationConfigurer).GetAssembly(),
                        "HnbcInfo.Bbs.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
