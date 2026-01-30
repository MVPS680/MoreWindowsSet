namespace WinUserLauncher.Models
{
    /// <summary>
    /// 分类项包装类,用于显示中文名称
    /// </summary>
    public class CategoryItem
    {
        public AppCategory Category { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }
}