﻿namespace Demo1969;

class Program
{
    public int MinNonZeroProduct(int p) {
        if (p == 1) {
            return 1;
        }
        long mod = 1000000007;
        long x = FastPow(2, p, mod) - 1;
        long y = (long) 1 << (p - 1);
        return (int) (FastPow(x - 1, y - 1, mod) * x % mod);
    }

    public long FastPow(long x, long n, long mod) {
        long res = 1;
        for (; n != 0; n >>= 1) {
            if ((n & 1) != 0) {
                res = res * x % mod;
            }
            x = x * x % mod;
        }
        return res;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}