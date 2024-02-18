using System.Numerics;

namespace LogPadeCoefGeneration {
    public static class LogPadeCoef {

        public static BigInteger[] GenerateCoef(int n) {
            ArgumentOutOfRangeException.ThrowIfLessThan(n, 2, nameof(n));

            n -= 1;

            Fraction[] c = Solve(n, GenerateMatrix(n), GenerateVector(n));
            Fraction[] p = [1, .. c[..n], 1, .. c[n..]];

            BigInteger[] v = ToInteger(p);

            return v;
        }

        static Fraction[,] GenerateMatrix(int n) {
            Fraction[,] m = new Fraction[2 * n, 2 * n];

            for (int i = 0; i < 2 * n; i++) {
                for (int j = 0; j < 2 * n; j++) {
                    m[i, j] = (i == j) ? 1 : 0;
                }
            }

            for (int i = 0; i < 2 * n; i++) {
                Fraction c = new((i % 2 == 0) ? -1 : 1, i + 1);

                for (int j = 0; j < int.Min(n, 2 * n - i); j++) {
                    m[i + j, j + n] = c;
                }
            }

            return m;
        }

        static Fraction[] GenerateVector(int n) {
            Fraction[] v = new Fraction[2 * n];

            for (int i = 0; i < 2 * n; i++) {
                Fraction c = new((i % 2 == 0) ? -1 : 1, i + 2);

                v[i] = c;
            }

            return v;
        }

        static Fraction[] Solve(int n, Fraction[,] m, Fraction[] v) {
            m = (Fraction[,])m.Clone();
            v = (Fraction[])v.Clone();

            for (int i = n; i < 2 * n; i++) {
                Fraction mii = m[i, i];

                m[i, i] = 1;
                for (int j = i + 1; j < 2 * n; j++) {
                    m[i, j] /= mii;
                }

                v[i] /= mii;

                for (int j = i + 1; j < 2 * n; j++) {
                    Fraction mji = m[j, i];

                    m[j, i] = 0;

                    for (int k = i + 1; k < 2 * n; k++) {
                        m[j, k] -= m[i, k] * mji;
                    }

                    v[j] -= v[i] * mji;
                }
            }

            for (int i = 2 * n - 1; i >= 0; i--) {
                for (int j = i - 1; j >= 0; j--) {
                    Fraction mji = m[j, i];

                    for (int k = i; k < 2 * n; k++) {
                        m[j, k] = 0;
                    }

                    v[j] -= v[i] * mji;
                }
            }

            return v;
        }

        static BigInteger[] ToInteger(Fraction[] v) {
            while (v.Any(c => c.Denom > 1)) {
                BigInteger n = v.First(c => c.Denom > 1).Denom;

                v = v.Select(c => c * n).ToArray();
            }

            return v.Select(c => c.Numer).ToArray();
        }
    }
}
