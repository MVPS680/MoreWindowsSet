using System.Collections.ObjectModel;
using System.Windows.Input;
using WinUserLauncher.Models;

namespace WinUserLauncher.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<SystemApp> SystemApps { get; set; }
        public ObservableCollection<CategoryItem> Categories { get; set; }
        public ICommand LaunchAppCommand { get; set; }

        public MainWindowViewModel()
        {
            SystemApps = new ObservableCollection<SystemApp>();
            Categories = new ObservableCollection<CategoryItem>();
            LoadSystemApps();
            LoadCategories();
            LaunchAppCommand = new RelayCommand(LaunchApp);
        }

        private void LoadSystemApps()
        {
            // 常用快捷打开 - Shell命令
            SystemApps.Add(new SystemApp
            {
                Name = "启动文件夹",
                Description = "开机自启动程序文件夹",
                LaunchCommand = "shell:Startup",
                LaunchType = LaunchType.URI,
                Category = AppCategory.QuickAccess,
                Icon = "Play24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "应用数据Roaming",
                Description = "用户应用数据(漫游)",
                LaunchCommand = "shell:AppData",
                LaunchType = LaunchType.URI,
                Category = AppCategory.QuickAccess,
                Icon = "Cloud24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "应用数据Local",
                Description = "用户应用数据(本地)",
                LaunchCommand = "shell:Local AppData",
                LaunchType = LaunchType.URI,
                Category = AppCategory.QuickAccess,
                Icon = "HardDrive24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "发送到菜单",
                Description = "右键发送到快捷方式",
                LaunchCommand = "shell:SendTo",
                LaunchType = LaunchType.URI,
                Category = AppCategory.QuickAccess,
                Icon = "Share24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "最近文件",
                Description = "最近打开的文件列表",
                LaunchCommand = "shell:Recent",
                LaunchType = LaunchType.URI,
                Category = AppCategory.QuickAccess,
                Icon = "History24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "开始菜单程序",
                Description = "开始菜单程序文件夹",
                LaunchCommand = "shell:Programs",
                LaunchType = LaunchType.URI,
                Category = AppCategory.QuickAccess,
                Icon = "Apps24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "公共文档",
                Description = "所有用户共享的文档",
                LaunchCommand = "shell:Common Documents",
                LaunchType = LaunchType.URI,
                Category = AppCategory.QuickAccess,
                Icon = "People24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "回收站",
                Description = "Windows回收站",
                LaunchCommand = "shell:RecycleBinFolder",
                LaunchType = LaunchType.URI,
                Category = AppCategory.QuickAccess,
                Icon = "Delete24"
            });

            // 常用快捷打开 - 环境变量
            SystemApps.Add(new SystemApp
            {
                Name = "临时文件夹",
                Description = "系统临时文件目录",
                LaunchCommand = "%TEMP%",
                LaunchType = LaunchType.Explorer,
                Category = AppCategory.QuickAccess,
                Icon = "FolderOpen24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "ProgramData",
                Description = "所有用户的应用数据",
                LaunchCommand = "%PROGRAMDATA%",
                LaunchType = LaunchType.Explorer,
                Category = AppCategory.QuickAccess,
                Icon = "DataManagement24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Windows目录",
                Description = "Windows系统目录",
                LaunchCommand = "%WINDIR%",
                LaunchType = LaunchType.Explorer,
                Category = AppCategory.QuickAccess,
                Icon = "Windows24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "System32",
                Description = "Windows系统32目录",
                LaunchCommand = "%WINDIR%\\System32",
                LaunchType = LaunchType.Explorer,
                Category = AppCategory.QuickAccess,
                Icon = "Settings24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "用户目录",
                Description = "当前用户主目录",
                LaunchCommand = "%USERPROFILE%",
                LaunchType = LaunchType.Explorer,
                Category = AppCategory.QuickAccess,
                Icon = "Person24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Program Files",
                Description = "64位程序安装目录",
                LaunchCommand = "%PROGRAMFILES%",
                LaunchType = LaunchType.Explorer,
                Category = AppCategory.QuickAccess,
                Icon = "Library24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Program Files (x86)",
                Description = "32位程序安装目录",
                LaunchCommand = "%PROGRAMFILES(X86)%",
                LaunchType = LaunchType.Explorer,
                Category = AppCategory.QuickAccess,
                Icon = "Library24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "公共桌面",
                Description = "所有用户的桌面",
                LaunchCommand = "%PUBLIC%\\Desktop",
                LaunchType = LaunchType.Explorer,
                Category = AppCategory.QuickAccess,
                Icon = "Desktop24"
            });

            // 系统工具
            SystemApps.Add(new SystemApp
            {
                Name = "计算器",
                Description = "Windows计算器",
                LaunchCommand = "calculator:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.SystemTools,
                Icon = "Calculator24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "记事本",
                Description = "Windows记事本",
                LaunchCommand = "notepad.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.SystemTools,
                Icon = "Document24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "画图",
                Description = "Windows画图应用",
                LaunchCommand = "ms-paint:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.SystemTools,
                Icon = "Edit24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "截图工具",
                Description = "Windows截图工具",
                LaunchCommand = "ms-ScreenSketch:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.SystemTools,
                Icon = "Crop24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "时钟",
                Description = "时钟、闹钟和计时器",
                LaunchCommand = "ms-clock:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.SystemTools,
                Icon = "Clock24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "任务管理器",
                Description = "Windows任务管理器",
                LaunchCommand = "taskmgr.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.SystemTools,
                Icon = "TaskManager24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "命令提示符",
                Description = "CMD命令提示符",
                LaunchCommand = "cmd.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.SystemTools,
                Icon = "Terminal24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "PowerShell",
                Description = "Windows PowerShell",
                LaunchCommand = "powershell.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.SystemTools,
                Icon = "Code24"
            });

            // 设置
            SystemApps.Add(new SystemApp
            {
                Name = "设置",
                Description = "Windows设置主页",
                LaunchCommand = "ms-settings:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Settings24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "显示设置",
                Description = "显示器和显示设置",
                LaunchCommand = "ms-settings:display",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Desktop24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "声音设置",
                Description = "声音和音频设置",
                LaunchCommand = "ms-settings:sound",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Speaker24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "网络设置",
                Description = "网络和互联网设置",
                LaunchCommand = "ms-settings:network",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Wifi24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "蓝牙设置",
                Description = "蓝牙和其他设备设置",
                LaunchCommand = "ms-settings:bluetooth",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Bluetooth24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "应用设置",
                Description = "已安装应用管理",
                LaunchCommand = "ms-settings:appsfeatures",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "AppsList24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "电源设置",
                Description = "电源和睡眠设置",
                LaunchCommand = "ms-settings:powersleep",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Battery24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "存储设置",
                Description = "存储空间管理",
                LaunchCommand = "ms-settings:storagesense",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Folder24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "个性化",
                Description = "主题、背景、颜色设置",
                LaunchCommand = "ms-settings:personalization",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Color24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "账户设置",
                Description = "账户和个人信息",
                LaunchCommand = "ms-settings:yourinfo",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Person24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "时间和语言",
                Description = "日期、时间和语言设置",
                LaunchCommand = "ms-settings:dateandtime",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Calendar24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "隐私和安全",
                Description = "隐私和安全设置",
                LaunchCommand = "ms-settings:privacy",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "Lock24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Windows更新",
                Description = "Windows更新和恢复",
                LaunchCommand = "ms-settings:windowsupdate",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Settings,
                Icon = "ArrowDownload24"
            });

            // 娱乐
            SystemApps.Add(new SystemApp
            {
                Name = "照片",
                Description = "Windows照片查看器",
                LaunchCommand = "ms-photos:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Entertainment,
                Icon = "Image24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "相机",
                Description = "Windows相机应用",
                LaunchCommand = "microsoft.windows.camera:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Entertainment,
                Icon = "Camera24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "电影和电视",
                Description = "视频播放器",
                LaunchCommand = "mswindowsvideo:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Entertainment,
                Icon = "Video24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Microsoft Solitaire",
                Description = "纸牌游戏合集",
                LaunchCommand = "xboxliveapp-1297287741:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Entertainment,
                Icon = "Games24"
            });

            // 办公
            SystemApps.Add(new SystemApp
            {
                Name = "Outlook邮件",
                Description = "Outlook邮件应用",
                LaunchCommand = "outlookmail:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Productivity,
                Icon = "Mail24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "日历",
                Description = "Windows日历应用",
                LaunchCommand = "outlookcal:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Productivity,
                Icon = "CalendarAgenda24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Microsoft To Do",
                Description = "待办事项管理",
                LaunchCommand = "ms-todo:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Productivity,
                Icon = "Checkmark24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Microsoft Clipchamp",
                Description = "视频编辑器",
                LaunchCommand = "ms-clipchamp:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Productivity,
                Icon = "VideoClip24"
            });

            // 网络
            SystemApps.Add(new SystemApp
            {
                Name = "Microsoft Edge",
                Description = "Microsoft Edge浏览器",
                LaunchCommand = "microsoft-edge:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Network,
                Icon = "Globe24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Microsoft Store",
                Description = "应用商店",
                LaunchCommand = "ms-windows-store:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Network,
                Icon = "StoreMicrosoft24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "地图",
                Description = "Bing地图",
                LaunchCommand = "bingmaps:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Network,
                Icon = "MapPin24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "天气",
                Description = "Bing天气",
                LaunchCommand = "bingweather:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Network,
                Icon = "WeatherSunny24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "新闻",
                Description = "Microsoft新闻",
                LaunchCommand = "bingnews:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Network,
                Icon = "News24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "手机连接",
                Description = "连接Android/iOS手机",
                LaunchCommand = "ms-phone:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Network,
                Icon = "Phone24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "Microsoft Teams",
                Description = "团队协作工具",
                LaunchCommand = "msteams:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Network,
                Icon = "PeopleTeam24"
            });

            // 安全
            SystemApps.Add(new SystemApp
            {
                Name = "Windows安全中心",
                Description = "Windows安全设置",
                LaunchCommand = "windowsdefender:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Security,
                Icon = "Shield24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "快速助手",
                Description = "远程协助工具",
                LaunchCommand = "ms-quick-assist:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Security,
                Icon = "PersonSupport24"
            });

            // 其他
            SystemApps.Add(new SystemApp
            {
                Name = "文件资源管理器",
                Description = "Windows文件资源管理器",
                LaunchCommand = "explorer.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Folder24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "控制面板",
                Description = "经典控制面板",
                LaunchCommand = "control.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Settings24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "系统信息",
                Description = "查看系统详细信息",
                LaunchCommand = "msinfo32.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Info24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "设备管理器",
                Description = "管理硬件设备",
                LaunchCommand = "devmgmt.msc",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Hardware24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "服务",
                Description = "管理Windows服务",
                LaunchCommand = "services.msc",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Server24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "事件查看器",
                Description = "查看系统事件日志",
                LaunchCommand = "eventvwr.msc",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Open24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "注册表编辑器",
                Description = "Windows注册表编辑器",
                LaunchCommand = "regedit.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Database24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "磁盘管理",
                Description = "管理磁盘分区",
                LaunchCommand = "diskmgmt.msc",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "HardDrive24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "任务计划程序",
                Description = "管理计划任务",
                LaunchCommand = "taskschd.msc",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Clock24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "性能监视器",
                Description = "监视系统性能",
                LaunchCommand = "perfmon.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Chart24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "资源监视器",
                Description = "监视系统资源使用",
                LaunchCommand = "resmon.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "DataHistogram24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "系统配置",
                Description = "系统配置工具(msconfig)",
                LaunchCommand = "msconfig.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Settings24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "远程桌面连接",
                Description = "远程桌面连接工具",
                LaunchCommand = "mstsc.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Desktop24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "写字板",
                Description = "Windows写字板",
                LaunchCommand = "write.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Document24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "字符映射表",
                Description = "插入特殊字符",
                LaunchCommand = "charmap.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Font24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "放大镜",
                Description = "屏幕放大工具",
                LaunchCommand = "magnify.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "ZoomIn24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "屏幕键盘",
                Description = "屏幕虚拟键盘",
                LaunchCommand = "osk.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Keyboard24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "步骤记录器",
                Description = "记录操作步骤",
                LaunchCommand = "psr.exe",
                LaunchType = LaunchType.Executable,
                Category = AppCategory.Other,
                Icon = "Camera24"
            });

            SystemApps.Add(new SystemApp
            {
                Name = "剪贴板历史",
                Description = "查看剪贴板历史",
                LaunchCommand = "ms-clipboard:",
                LaunchType = LaunchType.URI,
                Category = AppCategory.Other,
                Icon = "Clipboard24"
            });
        }

        private void LoadCategories()
        {
            Categories.Add(new CategoryItem { Category = AppCategory.QuickAccess, DisplayName = "常用快捷" });
            Categories.Add(new CategoryItem { Category = AppCategory.SystemTools, DisplayName = "系统工具" });
            Categories.Add(new CategoryItem { Category = AppCategory.Settings, DisplayName = "系统设置" });
            Categories.Add(new CategoryItem { Category = AppCategory.Entertainment, DisplayName = "娱乐休闲" });
            Categories.Add(new CategoryItem { Category = AppCategory.Productivity, DisplayName = "办公效率" });
            Categories.Add(new CategoryItem { Category = AppCategory.Network, DisplayName = "网络应用" });
            Categories.Add(new CategoryItem { Category = AppCategory.Security, DisplayName = "安全工具" });
            Categories.Add(new CategoryItem { Category = AppCategory.Other, DisplayName = "其他工具" });
        }

        private void LaunchApp(object? parameter)
        {
            if (parameter is SystemApp app)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();

                switch (app.LaunchType)
                {
                    case LaunchType.URI:
                        process.StartInfo.FileName = app.LaunchCommand;
                        process.StartInfo.UseShellExecute = true;
                        break;

                    case LaunchType.Executable:
                        process.StartInfo.FileName = app.LaunchCommand;
                        process.StartInfo.UseShellExecute = true;
                        break;

                    case LaunchType.Explorer:
                        process.StartInfo.FileName = "explorer.exe";
                        process.StartInfo.Arguments = app.LaunchCommand;
                        process.StartInfo.UseShellExecute = true;
                        break;
                }

                try
                {
                    process.Start();
                }
                catch (System.Exception ex)
                {
                    System.Windows.MessageBox.Show($"无法启动应用: {ex.Message}", "错误",
                        System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}