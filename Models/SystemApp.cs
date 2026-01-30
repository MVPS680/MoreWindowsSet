namespace WinUserLauncher.Models
{
    /// <summary>
    /// 系统应用模型
    /// </summary>
    public class SystemApp
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 应用描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// URI Scheme或可执行文件路径
        /// </summary>
        public string LaunchCommand { get; set; } = string.Empty;

        /// <summary>
        /// 启动类型: URI或Executable
        /// </summary>
        public LaunchType LaunchType { get; set; }

        /// <summary>
        /// 应用分类
        /// </summary>
        public AppCategory Category { get; set; }

        /// <summary>
        /// 图标名称(使用Fluent图标)
        /// </summary>
        public string Icon { get; set; } = "Apps24";
    }

    /// <summary>
    /// 启动类型枚举
    /// </summary>
    public enum LaunchType
    {
        /// <summary>
        /// URI Scheme启动(如calculator:, ms-settings:)
        /// </summary>
        URI,

        /// <summary>
        /// 可执行文件启动(如notepad.exe)
        /// </summary>
        Executable,

        /// <summary>
        /// 通过explorer.exe启动
        /// </summary>
        Explorer
    }

    /// <summary>
    /// 应用分类枚举
    /// </summary>
    public enum AppCategory
    {
        /// <summary>
        /// 系统工具
        /// </summary>
        SystemTools,

        /// <summary>
        /// 设置
        /// </summary>
        Settings,

        /// <summary>
        /// 娱乐
        /// </summary>
        Entertainment,

        /// <summary>
        /// 办公
        /// </summary>
        Productivity,

        /// <summary>
        /// 网络
        /// </summary>
        Network,

        /// <summary>
        /// 安全
        /// </summary>
        Security,

        /// <summary>
        /// 其他
        /// </summary>
        Other,

        /// <summary>
        /// 常用快捷打开
        /// </summary>
        QuickAccess
    }
}