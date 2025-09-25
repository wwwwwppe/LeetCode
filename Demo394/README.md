# Demo394 字符串解码与性能/内存基准说明

本目录包含四种“解码形如 `3[a2[c]]`”字符串算法实现，以及一个自制的基准/内存测试框架。本文档总结：
1. 这些测试与代码使用了哪些 C# / .NET 技术栈要点
2. 学习路径与推荐资料
3. 运行与扩展示例
4. 如何进一步深化（BenchmarkDotNet、PerfView、dotnet 工具）

---
## 1. 涉及到的 C# / .NET 技术点概览
| 主题 | 在项目中的体现 | 关键文件/代码点 |
|------|----------------|----------------|
| .NET SDK / Target Framework | 使用 `net9.0` | `Demo394.csproj` |
| 程序入口 / 命令行参数 | `Main(string[] args)` 解析 `stress` / `perinput` / `iterations=` | `Program.cs` |
| 记录类型 (record) | `private record MethodCase(string Name, Func<string,string> Func);` | `Program.cs` |
| 委托 / 函数指针 | 用 `Func<string,string>` 收集不同实现 | `Program.cs` |
| 多种算法风格 | 递归 `DecoderRecursive`、显式栈 `DecoderStack`、迭代逐段展开 `DecodeStringDemo`、原始实现 `Program.DecodeString` | 对应四个类 |
| 字符串处理与 `StringBuilder` | 降低拼接分配、构造重复段 | 所有实现 |
| 栈模拟（数组+List 混合） | 小深度数组 + 溢出时转 List，减少分配 | `DecoderStack.cs` |
| 递归下降解析 | 嵌套括号解析 `Parse` | `DecoderRecursive.cs` |
| `Span` / `AsSpan` 使用 | 在迭代实现里裁剪原字符串构造新串 | `DecodeStringDemo.cs` |
| 计时器 | `Stopwatch` 精确测量耗时 | `Program.cs` |
| GC 分配统计 | `GC.GetAllocatedBytesForCurrentThread()` 获取分配差值 | `Program.cs` |
| GC 回收次数 | `GC.CollectionCount(0/1/2)` 统计各代回收 | `Program.cs` |
| 手工 GC 干预 | 基准前调用 `GC.Collect()` 降低噪声 | `Program.cs` |
| 预热 (JIT Warm-up) | 正式计时前先调用所有方法 | `Program.cs` |
| 条件/模式输入集 | 普通输入 vs STRESS 输入集切换 | `Program.cs` |
| 简单排序与结果聚合 | `List<T>.Sort` + 自定义元组结构 | `Program.cs` |
| 可配置迭代次数 | `iterations=1000` 参数控制测试规模 | `Program.cs` |
| 每输入粒度细分 | `perinput` 模式逐个输入统计 | `Program.cs` |
| 编码规范与中文命名混用 | 演示但不推荐（生产应统一英文） | `Program.DecodeString` |

> 提示：当前的内存测量为“线程已分配字节差值”，适合对比趋势；要获得更权威的统计与分配来源，后续请结合 BenchmarkDotNet + MemoryDiagnoser 或 ETW/PerfView。

---
## 2. 推荐学习路径（循序渐进）
### 阶段 0：基础语法与运行
1. C# 基本语法（变量、控制流、方法、类、字符串）  
2. .NET CLI 基本操作：`dotnet new / build / run`

### 阶段 1：核心语言与内存
1. 不可变字符串 & `StringBuilder` 工作原理  
2. 值/引用类型区别、装箱/拆箱  
3. 数组、`List<T>`、`Span<T>` / `ReadOnlySpan<T>` 基础

### 阶段 2：性能基础
1. 复杂度分析（O(n)、O(n^2)）  
2. 避免重复全串扫描与多次分配  
3. 常见优化：预估容量、循环内避免不必要临时对象

### 阶段 3：计时与分配统计
1. `Stopwatch` 精确计时  
2. JIT 预热的原因（首次调用方法会触发编译）  
3. `GC.GetAllocatedBytesForCurrentThread` 与其局限性  
4. `GC.CollectionCount` 观察回收频率

### 阶段 4：基准测试框架
1. BenchmarkDotNet：`[Benchmark]`、`[Params]`、`[MemoryDiagnoser]`  
2. 输出视图解读（Mean / Error / StdDev / Gen0 / Allocated）  
3. 正确写法：避免在基准方法内部包含 I/O

### 阶段 5：分析工具与调优
1. PerfView 或 dotnet-trace：抓取分配/CPU/GC  
2. dotnet-counters：实时观测 `alloc-rate`、`gc-heap-size`  
3. 火焰图（Speedscope）阅读  
4. 找热点 -> 修改 -> 再验证（迭代调优循环）

### 阶段 6：工程化与回归防护
1. 输出基线 JSON（保存上次基准）  
2. CI 中跑“快速基准” + 阈值比较 (允许少量波动)  
3. 回归报警策略（耗时或分配增长 > X%）

### 阶段 7：进阶（可选）
1. 自定义内存池 (`ArrayPool<T>` / ValueStringBuilder)  
2. Source Generator / AOT / NativeAOT  
3. Unsafe / Span 解包进一步降低边界检查（需非常谨慎）

---
## 3. 运行方式与示例
在仓库根目录或本目录下执行（建议 Release）：
```bash
# 普通聚合基准
dotnet run -c Release --project Demo394

# 指定迭代次数
dotnet run -c Release --project Demo394 -- iterations=1000

# 压力输入集（更大/更深嵌套）
dotnet run -c Release --project Demo394 -- stress

# 每个输入单独统计（建议减小迭代）
dotnet run -c Release --project Demo394 -- perinput iterations=300

# 组合模式
dotnet run -c Release --project Demo394 -- stress perinput iterations=100
```
输出中你会看到：
- TotalAlloc: 总分配字节（格式化）
- PerCall: 平均单次调用分配
- GC(G0/G1/G2): 各代发生 GC 次数

---
## 4. 四种实现策略简述
| 名称 | 思路 | 优点 | 缺点 |
|------|------|------|------|
| Original_Program | 反复寻找最右侧 `[` + `Replace` 替换 | 直观 | 多轮扫描 + 大量字符串分配 (非常慢) |
| Recursive | 递归下降解析 + `StringBuilder` | 代码清晰、一次扫描 | 递归深度受限（极深嵌套需注意栈） |
| Stack | 显式维护数栈和字符串栈（数组+List 双层） | 无递归栈风险，速度快 | 代码相对复杂 |
| IterativeSingleExpand | 每次展开一个最内层括号段 | 实现较简单 | 多轮扫描，额外分配较多 |

---
## 5. 如何自己“从零写出这套基准” 练习路线
1. 先写 1 个简单实现（递归或栈）并保证正确性。  
2. 引入第二种实现，写一个 `Func<string,string>` 列表循环对比输出。  
3. 用 `Stopwatch` 包裹大循环，统计耗时。  
4. 增加预热阶段。  
5. 添加内存统计：计时前后调用 `GC.GetAllocatedBytesForCurrentThread()`。  
6. 抽象结果结构（元组/record）并排序打印。  
7. 增加命令行参数解析，控制迭代与模式。  
8. 拆分 per-input 与 aggregated 两套函数，减少分支。  
9. 最后再接入 BenchmarkDotNet 做权威对比。  

---
## 6. 推荐官方/权威资料
| 主题 | 参考链接 |
|------|----------|
| C# 语言指南 | https://learn.microsoft.com/dotnet/csharp/ |
| .NET GC 基础 | https://learn.microsoft.com/dotnet/standard/garbage-collection/ |
| String & StringBuilder | https://learn.microsoft.com/dotnet/api/system.text.stringbuilder |
| BenchmarkDotNet | https://benchmarkdotnet.org/ |
| PerfView | https://github.com/microsoft/perfview |
| dotnet-trace | https://learn.microsoft.com/dotnet/core/diagnostics/dotnet-trace |
| dotnet-counters | https://learn.microsoft.com/dotnet/core/diagnostics/dotnet-counters |
| dotnet-monitor | https://learn.microsoft.com/dotnet/core/diagnostics/dotnet-monitor |
| 性能最佳实践 | https://learn.microsoft.com/dotnet/standard/performance/ |

---
## 7. 进一步扩展建议
| 方向 | 建议 |
|------|------|
| 引入 BenchmarkDotNet | 新建 Benchmark 工程，添加 `[MemoryDiagnoser]`，对四种实现基准化 |
| 结果持久化 | 将结果序列化为 JSON，供回归比较 |
| 随机输入生成 | 按嵌套深度、重复次数、片段长度受控生成用例；过滤掉展开后长度过大的样本 |
| 吞吐量指标 | 统计“总输出字符数 / ms”，比较真正的字符处理效率 |
| 改良 Original | 改为栈或递归一次解析，加入对比（可命名 ImprovedOriginal） |
| 减少分配 | 尝试共享 `StringBuilder`、使用 `ArrayPool<char>`、优化重复 append 逻辑 |
| 极限测试 | 测试深度 > 50、重复次数很大（防止 int 溢出），验证异常或保护策略 |
| CI 基线 | 定期跑快速基准 (较小 iterations) 比较最新 PR 与主分支差异 |

---
## 8. 常见陷阱与注意事项
1. Stopwatch 精度：短时间（<1ms）差异不可靠，需要增加迭代规模。  
2. GC.GetAllocatedBytesForCurrentThread 不是“精准分配来源”，只做对比趋势。  
3. 大重复展开可能导致爆内存：要控制输入或预估输出长度。  
4. 递归方法过深可能栈溢出：可切换栈实现。  
5. string.Replace 会替换所有匹配子串，若模式重复出现且语义不唯一会出错（当前数据集中未触发）。  
6. 分析工具（PerfView/trace）首次使用要关注权限与符号下载耗时。  
7. 测试时保持系统负载相对稳定，避免其它进程干扰结果。  

---
## 9. 下一步可以尝试的“练手任务”
1. 新增 ImprovedOriginal（线性栈解析）并放进基准列表。  
2. 写一个 `RandomInputGenerator`：可配置种子、最大展开长度、最大深度。  
3. 输出结果同时写入 `benchmark-results-{timestamp}.json`。  
4. 引入 BenchmarkDotNet：跑至少 3 组参数（小/中/大）。  
5. 用 PerfView 抓一次运行，截图/记录 Top Alloc Stacks。  
6. 实现一个“增量模式”：只跑最快的两个方法作为日常监测。  

---
## 10. 小结
通过该示例你可以系统掌握：
- 多种解析策略权衡（清晰 vs 分配 vs 速度）
- 手写轻量基准 vs 正式基准框架的差别
- 初步内存与 GC 观察手法
- 如何工程化地演进一个小型性能测试平台

学会本示例后，迁移到其它字符串/解析/表达式展开/标记语言处理等场景会非常顺利。

---
如需我继续：可以告诉我你希望我优先实现“改良版 + BenchmarkDotNet”还是“随机输入 + JSON 输出”等，我可以直接补上。

