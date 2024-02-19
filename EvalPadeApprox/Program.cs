using MultiPrecision;
using System.Collections.ObjectModel;

namespace EvalPadeApprox {
    internal class Program {
        static void Main() {
            ReadOnlyCollection<MultiPrecision<Pow2.N128>> n16 = ReadCoefs<Pow2.N128>(16);
            ReadOnlyCollection<MultiPrecision<Pow2.N128>> n32 = ReadCoefs<Pow2.N128>(32);
            ReadOnlyCollection<MultiPrecision<Pow2.N128>> n64 = ReadCoefs<Pow2.N128>(64);
            ReadOnlyCollection<MultiPrecision<Pow2.N128>> n128 = ReadCoefs<Pow2.N128>(128);
            ReadOnlyCollection<MultiPrecision<Pow2.N128>> n256 = ReadCoefs<Pow2.N128>(256);
            ReadOnlyCollection<MultiPrecision<Pow2.N128>> n512 = ReadCoefs<Pow2.N128>(512);

            using (StreamWriter sw = new("../../../../results_disused/logpade_result.csv")) {
                sw.WriteLine("x,n,error(log10)");

                for (MultiPrecision<Pow2.N128> x = 0; x <= 1; x += 1 / 256d) {
                    MultiPrecision<Pow2.N128> expected = MultiPrecision<Pow2.N128>.Log1p(x);

                    MultiPrecision<Pow2.N128> actual_n16 = PadeApprox(x, n16);
                    MultiPrecision<Pow2.N128> actual_n32 = PadeApprox(x, n32);
                    MultiPrecision<Pow2.N128> actual_n64 = PadeApprox(x, n64);
                    MultiPrecision<Pow2.N128> actual_n128 = PadeApprox(x, n128);
                    MultiPrecision<Pow2.N128> actual_n256 = PadeApprox(x, n256);
                    MultiPrecision<Pow2.N128> actual_n512 = PadeApprox(x, n512);

                    MultiPrecision<Pow2.N128> error_n16 =  MultiPrecision<Pow2.N128>.Log10(MultiPrecision<Pow2.N128>.Abs(actual_n16 - expected) / expected);
                    MultiPrecision<Pow2.N128> error_n32 =  MultiPrecision<Pow2.N128>.Log10(MultiPrecision<Pow2.N128>.Abs(actual_n32 - expected) / expected);
                    MultiPrecision<Pow2.N128> error_n64 =  MultiPrecision<Pow2.N128>.Log10(MultiPrecision<Pow2.N128>.Abs(actual_n64 - expected) / expected);
                    MultiPrecision<Pow2.N128> error_n128 = MultiPrecision<Pow2.N128>.Log10(MultiPrecision<Pow2.N128>.Abs(actual_n128 - expected) / expected);
                    MultiPrecision<Pow2.N128> error_n256 = MultiPrecision<Pow2.N128>.Log10(MultiPrecision<Pow2.N128>.Abs(actual_n256 - expected) / expected);
                    MultiPrecision<Pow2.N128> error_n512 = MultiPrecision<Pow2.N128>.Log10(MultiPrecision<Pow2.N128>.Abs(actual_n512 - expected) / expected);

                    if (expected == 0) {
                        sw.WriteLine($"{x},16,-inf");
                        sw.WriteLine($"{x},32,-inf");
                        sw.WriteLine($"{x},64,-inf");
                        sw.WriteLine($"{x},128,-inf");
                        sw.WriteLine($"{x},256,-inf");
                        sw.WriteLine($"{x},512,-inf");
                    }
                    else {
                        sw.WriteLine($"{x},16,{error_n16:e20}");
                        sw.WriteLine($"{x},32,{error_n32:e20}");
                        sw.WriteLine($"{x},64,{error_n64:e20}");
                        sw.WriteLine($"{x},128,{error_n128:e20}");
                        sw.WriteLine($"{x},256,{error_n256:e20}");
                        sw.WriteLine($"{x},512,{error_n512:e20}");
                    }
                }
            }

            Console.WriteLine("END");
            Console.Read();
        }

        static ReadOnlyCollection<MultiPrecision<N>> ReadCoefs<N>(int n) where N : struct, IConstant {
            using StreamReader sr = new($"../../../../results/logpadecoef_{n}.txt");

            List<MultiPrecision<N>> coefs = [];

            while (!sr.EndOfStream) {
                string? line = sr.ReadLine();

                if (string.IsNullOrWhiteSpace(line)) {
                    throw new FileLoadException();
                }

                if (line == "eof") {
                    break;
                }

                coefs.Add(line);
            }

            return coefs.AsReadOnly();
        }

        static MultiPrecision<N> PadeApprox<N>(MultiPrecision<N> x, ReadOnlyCollection<MultiPrecision<N>> coefs) where N : struct, IConstant {
            int n = coefs.Count / 2;

            MultiPrecision<N> sc = coefs[n - 1], sd = coefs[2 * n - 1];

            for (int i = n - 2; i >= 0; i--) {
                sc = coefs[i] + x * sc;
                sd = coefs[i + n] + x * sd;
            }

            MultiPrecision<N> y = x * sc / sd;

            return y;
        }
    }
}
