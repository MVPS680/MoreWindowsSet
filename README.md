# Windows 系统应用启动器 (WinUserLauncher)

一个使用 WPF（.NET 8）构建的轻量级 Windows 系统应用启动器，基于 WPF-UI（Fluent 风格）控件库。它将常用系统 URI、可执行和资源文件夹以卡片网格的方式展示，支持按分类筛选、搜索和一键启动。

---

## 关键特性

- 使用现代 Fluent 风格的 UI（依赖 WPF-UI）
- 预置大量常用系统工具、设置页、资源管理路径和实用程序
- 按分类浏览：常用快捷、系统工具、系统设置、娱乐、办公、网络、安全、其他
- 支持通过 URI、可执行或使用 explorer 打开路径三种启动方式
- 支持搜索和按类过滤

## 适用场景

- 快速访问 Windows 常用工具与系统设置
- 为运维/高级用户提供一个集中式的系统入口
- 作为学习 WPF、MVVM 模式与 Process 启动管理的示例项目

## 技术栈与依赖

- 目标框架：`.NET 8.0`（WPF 桌面）
- WPF（UseWPF:true）
- NuGet 依赖：`WPF-UI` v4.0.3（在 `WinUserLauncher.csproj` 中声明）

在 `WinUserLauncher.csproj` 中可以看到目标框架和依赖：

```xml
<TargetFramework>net8.0-windows</TargetFramework>
<UseWPF>true</UseWPF>
<PackageReference Include="WPF-UI" Version="4.0.3" />
```

## 文件与结构说明（快速导览）

- `MainWindow.xaml` / `MainWindow.xaml.cs`：主窗口视图与交互逻辑（事件绑定）。
- `ViewModels/MainWindowViewModel.cs`：包含应用列表加载、分类、搜索与 `LaunchApp` 的启动实现；是主要的业务逻辑位置。
- `Models/SystemApp.cs`、`Models/CategoryItem.cs`：模型定义（应用信息、启动类型、分类等）。
- `WinUserLauncher.csproj`：项目配置与 NuGet 包。

如果你想添加或修改要展示/启动的应用，最直接的方式是编辑 `ViewModels/MainWindowViewModel.cs` 的 `LoadSystemApps()` 方法，在那里以 `SystemApp` 对象的方式定义要展示的项。

示例（添加一个自定义条目）：

```csharp
SystemApps.Add(new SystemApp {
  Name = "记事本",
  Description = "Windows 记事本",
  LaunchCommand = "notepad.exe",
  LaunchType = LaunchType.Executable,
  Category = AppCategory.SystemTools,
  Icon = "Document24"
});
```

## 启动类型说明

- `LaunchType.URI`：直接把 `LaunchCommand` 当作 URI（例如 `ms-settings:`、`calculator:`）使用，Process 使用 `UseShellExecute=true` 启动。
- `LaunchType.Executable`：把 `LaunchCommand` 当作可执行文件名（或带路径的可执行程序）。
- `LaunchType.Explorer`：通过 `explorer.exe` 打开一个文件夹或环境变量路径（示例 `%WINDIR%`），`Arguments` 会传递给 explorer。

注意：某些系统 URI 或可执行需要更高权限或特定 Windows 版本支持。

## 构建与运行

建议在 Windows 10/11 上使用。你需要安装 .NET 8 SDK。

1. 使用命令行（开发者命令行或 PowerShell）构建：

```powershell
dotnet build "./WinUserLauncher.csproj" -c Release
```

2. 运行（用 dotnet CLI）：

```powershell
dotnet run --project "./WinUserLauncher.csproj" -c Release
```

3. 或者在 Visual Studio 中打开解决方案或 `.csproj` 并直接调试（确保目标框架为 .NET 8 并安装 WPF 工作负载）。

## 使用说明（UI）

- 左侧导航为分类（点击会按分类过滤）；底部有“显示全部”按钮。
- 右上方为搜索框，可按名称/描述模糊搜索。
- 点击任意卡片即可启动对应应用或打开路径。

## 配置与扩展建议

- 配置文件支持（建议）：目前应用清单写死在 `LoadSystemApps()`，建议将其替换为从 JSON 加载（例如 `apps.json`），便于用户/管理员自定义而无需重新编译。
- 国际化（I18N）：当前 UI 为中文，可提取字符串以支持多语言。
- 权限与 UAC：某些可执行或管理工具需要管理员权限，考虑增加运行前权限提示或“以管理员身份运行”选项。

示例：从 `apps.json` 加载的简单思路

1. 在根目录放 `apps.json`，列出 `SystemApp` 数组。
2. 在 `MainWindowViewModel` 中实现 JSON 解析（使用 `System.Text.Json`）并合并/替换硬编码项。

## 常见问题（FAQ）

- Q: 点击没有反应？
  - A: 部分 URI 或可执行可能在当前系统不可用；检查 `LaunchCommand` 是否正确，或尝试以管理员运行程序（视具体工具而定）。

- Q: 如何添加自定义程序（第三方）？
  - A: 建议在 `LoadSystemApps()` 中添加 `LaunchType.Executable` 项并把 `LaunchCommand` 指定为可执行路径（相对或绝对）。更好的方式是实现外部 JSON 配置并重载清单。

## 贡献 & 代码准则

欢迎提交 Issue 或 Pull Request。建议：

- 提交前请确保编译通过（`dotnet build`）
- 新增 UI 请尽量复用 `WPF-UI` 风格组件并在 XAML 中保持简洁
- 功能 PR 请包含简短说明和必要的测试说明（若有）

## 许可（License）

该仓库当前未包含 LICENSE 文件。如希望开源发布，推荐 MIT 许可证。若你希望我为仓库添加 `LICENSE` 文件，请告知选择的许可证类型（例如 MIT、Apache-2.0、GPL-3.0 等），我可以为你自动创建。

作者MVPS680
2026年1月30日