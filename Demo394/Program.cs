namespace Demo394;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    // 原作者实现（改为 static 方便传递委托）
    public static string DecodeString(string s)
    {
        int a = 0, b = 0;
        while (a == b)
        {
            s = returnOne(s, ref b);
            a++;
        }
        return s;
    }
    
    //从右到左来找左括号，然后根据这个左括号来右边来找右括号
    private static string returnOne(string s, ref int b)
    {
        int left = s.Length - 1;
        int right = 0;
        string 括号内的字符串 = "";
        for (; left >= 0; left--)
        {
            if (s[left] == '[')
            {
                for (int i = left + 1; i < s.Length - 1; i++)
                {
                    if (s[i] != ']')
                    {
                        括号内的字符串 += s[i];
                    }
                    else
                    {
                        right = i;
                        break;
                    }
                }
                break;
            }
        }

        string length = "";
        for (int i = left - 1; i >= 0; i--)
        {
            if (s[i] - '0' >= 0 && s[i] - '0' <= 9)
            {
                left = i;
                length = s[i] + length;
            }
            else
            {
                break;
            }
        }

        if (length != "" && left != s.Length - 1)
        {
            string 完整的字符串 = length + "[" + 括号内的字符串 + "]";
            int num = int.Parse(length);
            string 新字符串 = "";
            for (int i = 0; i < num; i++)
            {
                新字符串 += 括号内的字符串;
            }
            s = s.Replace(完整的字符串, 新字符串);
            b++;
        }
        return s;
    }

    private record MethodCase(string Name, Func<string, string> Func);

    private static string[] GenerateStressInputs() => new[]
    {
        // 旨在放大差异，但避免爆内存
        "100[a]",
        "40[ab10[z]]",
        "15[a2[b3[c]]]",
        "8[x5[y2[z]]]",
        "2[50[a10[b]c]]",
        "3[2[qw]5[e2[r]]]",
        "5[ab3[cd2[ef3[g]]]]"
    };

    static void Main(string[] args)
    {
        // 参数解析
        bool isStress = args.Any(a => a.Equals("stress", StringComparison.OrdinalIgnoreCase));
        bool perInput = args.Any(a => a.Equals("perinput", StringComparison.OrdinalIgnoreCase));
        int? userIterations = ParseIterations(args);

        string[] inputs = isStress ? GenerateStressInputs() : new[]
        {
            "3[a]2[bc]",
            "3[a2[c]]",
            "2[abc]3[cd]ef",
            "10[a]",
            "3[z]2[2[y]pq4[2[jk]e1[f]]]ef",
            "50[a10[b]c]",
            "25[b26[8[c9[a]e]c]h6[e]]"
        };

        if (isStress)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("== 使用 STRESS 输入集 ==\n");
            Console.ResetColor();
        }

        // 定义需要测试的四种实现
        var methods = new List<MethodCase>
        {
            new("Original_Program", DecodeString),
            new("Recursive", DecoderRecursive.Decode),
            new("Stack", DecoderStack.Decode),
            new("IterativeSingleExpand", new DecodeStringDemo().DecodeStringTwo)
        };

        Console.WriteLine("功能正确性校验 (以 Recursive 为基准):");
        var baseline = DecoderRecursive.Decode; // 选递归实现作为基准
        foreach (var input in inputs)
        {
            string expect = baseline(input);
            foreach (var m in methods)
            {
                string actual = m.Func(input);
                if (actual != expect)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[FAIL] {m.Name} 输入: {input} \n  期望长度={expect.Length} 实际长度={actual.Length}");
                    Console.ResetColor();
                }
            }
        }
        Console.WriteLine();

        // 预热 (JIT) – 避免首次调用的编译成本影响测试
        foreach (var m in methods)
            foreach (var input in inputs)
                m.Func(input);

        // Benchmark 参数 (Stress 模式降低迭代次数)
        int iterations = userIterations ?? (isStress ? 200 : 5000); 
        Console.WriteLine($"开始基准测试: 模式={ (isStress ? "STRESS" : "NORMAL") } {(perInput ? "(Per-Input Detail)" : "(Aggregated)")} 每个方法 {iterations} 次\n");

        if (perInput)
        {
            RunPerInputDetail(methods, inputs, iterations);
        }
        else
        {
            RunAggregated(methods, inputs, iterations);
        }

        Console.WriteLine("\n用法示例:");
        Console.WriteLine("  普通:   dotnet run -c Release --project Demo394");
        Console.WriteLine("  压力:   dotnet run -c Release --project Demo394 -- stress");
        Console.WriteLine("  指定迭代: dotnet run -c Release --project Demo394 -- iterations=1000");
        Console.WriteLine("  每输入详情: dotnet run -c Release --project Demo394 -- perinput iterations=300");
        Console.WriteLine("  组合:   dotnet run -c Release --project Demo394 -- stress perinput iterations=100");

        Console.WriteLine("\n深入分析可使用: BenchmarkDotNet + MemoryDiagnoser, dotnet-counters, dotnet-trace, PerfView.");
    }

    private static void RunAggregated(List<MethodCase> methods, string[] inputs, int iterations)
    {
        var results = new List<(string Name, long ElapsedMs, long TotalAllocatedBytes, long BytesPerCall, int Gen0, int Gen1, int Gen2)>();

        foreach (var m in methods)
        {
            GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();
            int gen0Before = GC.CollectionCount(0);
            int gen1Before = GC.CollectionCount(1);
            int gen2Before = GC.CollectionCount(2);

            long allocBefore = GC.GetAllocatedBytesForCurrentThread();
            var sw = Stopwatch.StartNew();
            for (int it = 0; it < iterations; it++)
                foreach (var input in inputs)
                    m.Func(input);
            sw.Stop();
            long allocAfter = GC.GetAllocatedBytesForCurrentThread();

            long totalAlloc = allocAfter - allocBefore;
            long calls = (long)iterations * inputs.Length;
            long perCall = calls > 0 ? totalAlloc / calls : 0;
            int gen0 = GC.CollectionCount(0) - gen0Before;
            int gen1 = GC.CollectionCount(1) - gen1Before;
            int gen2 = GC.CollectionCount(2) - gen2Before;

            results.Add((m.Name, sw.ElapsedMilliseconds, totalAlloc, perCall, gen0, gen1, gen2));
            Console.WriteLine(
                $"{m.Name,-24} : {sw.ElapsedMilliseconds,6} ms  | TotalAlloc={FormatBytes(totalAlloc),12} | PerCall={FormatBytes(perCall),10} | GC(G0/G1/G2)={gen0}/{gen1}/{gen2}");
        }

        Console.WriteLine();
        Console.WriteLine("按耗时排序:");
        foreach (var r in Sorted(results, r => r.ElapsedMs))
            Console.WriteLine($"{r.Name,-24} : {r.ElapsedMs,6} ms  | Alloc/Call={FormatBytes(r.BytesPerCall),10}");
        Console.WriteLine();
        var fastest = Sorted(results, r=>r.ElapsedMs)[0];
        Console.WriteLine($"最快的方法: {fastest.Name}\n");

        Console.WriteLine("按平均分配(Per Call Bytes)排序:");
        foreach (var r in Sorted(results, r => r.BytesPerCall))
            Console.WriteLine($"{r.Name,-24} : {FormatBytes(r.BytesPerCall),10} /call  (Total {FormatBytes(r.TotalAllocatedBytes)})");
        Console.WriteLine();
        var lowestAlloc = Sorted(results, r=>r.BytesPerCall)[0];
        Console.WriteLine($"最省内存的方法(单次分配): {lowestAlloc.Name}");
    }

    private static void RunPerInputDetail(List<MethodCase> methods, string[] inputs, int iterations)
    {
        Console.WriteLine("== Per-Input 详细模式 ==\n(注意: 该模式开销更高, 建议迭代次数适当减小)\n");
        foreach (var m in methods)
        {
            Console.WriteLine($"-- 方法: {m.Name} --");
            foreach (var input in inputs)
            {
                GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();
                int gen0Before = GC.CollectionCount(0);
                int gen1Before = GC.CollectionCount(1);
                int gen2Before = GC.CollectionCount(2);

                long allocBefore = GC.GetAllocatedBytesForCurrentThread();
                var sw = Stopwatch.StartNew();
                for (int it = 0; it < iterations; it++)
                    m.Func(input);
                sw.Stop();
                long allocAfter = GC.GetAllocatedBytesForCurrentThread();

                long totalAlloc = allocAfter - allocBefore;
                long calls = iterations;
                long perCall = calls > 0 ? totalAlloc / calls : 0;
                int gen0 = GC.CollectionCount(0) - gen0Before;
                int gen1 = GC.CollectionCount(1) - gen1Before;
                int gen2 = GC.CollectionCount(2) - gen2Before;

                Console.WriteLine($"InputLen={input.Length,-5} | Iter={iterations,-5} | Time={sw.ElapsedMilliseconds,6} ms | Total={FormatBytes(totalAlloc),10} | /Call={FormatBytes(perCall),9} | GC {gen0}/{gen1}/{gen2}");
            }
            Console.WriteLine();
        }
    }

    private static List<T> Sorted<T, TKey>(IEnumerable<T> src, Func<T, TKey> key) where TKey : IComparable<TKey>
    {
        var list = new List<T>(src);
        list.Sort((a,b) => key(a).CompareTo(key(b)));
        return list;
    }

    private static int? ParseIterations(string[] args)
    {
        foreach (var a in args)
        {
            if (a.StartsWith("iterations=", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(a.AsSpan("iterations=".Length), out int v) && v > 0)
                    return v;
            }
        }
        return null;
    }

    private static string FormatBytes(long bytes)
    {
        if (bytes < 1024) return bytes + " B";
        double kb = bytes / 1024.0;
        if (kb < 1024) return kb.ToString("F2") + " KB";
        double mb = kb / 1024.0;
        if (mb < 1024) return mb.ToString("F2") + " MB";
        double gb = mb / 1024.0;
        return gb.ToString("F2") + " GB";
    }
}