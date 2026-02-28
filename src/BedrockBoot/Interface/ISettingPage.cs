using System.Collections.Generic;
using Material.Avalonia.Entry;

namespace BedrockBoot.Interface;

public class ISettingPage : ISetting
{
    public List<BreadcrumbItemInfo> BreadcrumbItem { get; set; } = new();
    public static I18nManager i18n => I18nManager.Instance;
}