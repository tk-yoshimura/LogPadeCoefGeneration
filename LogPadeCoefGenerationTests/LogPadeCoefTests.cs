using LogPadeCoefGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace LogPadeCoefGenerationTests {
    [TestClass()]
    public class LogPadeCoefTests {
        [TestMethod()]
        public void N4Test() {
            BigInteger[] actual = LogPadeCoef.GenerateCoef(4);

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
            }

            BigInteger[] expected = [
                420,
                510,
                140,
                3,
                420,
                720,
                360,
                48,
            ];

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void N5Test() {
            BigInteger[] actual = LogPadeCoef.GenerateCoef(5);

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
            }

            BigInteger[] expected = [
                3780,
                6510,
                3360,
                505,
                6,
                3780,
                8400,
                6300,
                1800,
                150,
            ];

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void N8Test() {
            BigInteger[] actual = LogPadeCoef.GenerateCoef(8);

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
            }

            BigInteger[] expected = [
                1801800,
                5825820,
                7327320,
                4508350,
                1395240,
                198324,
                9656,
                35,
                1801800,
                6726720,
                10090080,
                7761600,
                3234000,
                705600,
                70560,
                2240,
            ];

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void N9Test() {
            BigInteger[] actual = LogPadeCoef.GenerateCoef(9);

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
            }

            BigInteger[] expected = [
                30630600,
                114414300,
                172372200,
                133963830,
                56936880,
                12885180,
                1382040,
                51561,
                140,
                30630600,
                129729600,
                227026800,
                211891680,
                113513400,
                34927200,
                5821200,
                453600,
                11340,
            ];

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void N16Plot() {
            const int n = 16;

            BigInteger[] actual = LogPadeCoef.GenerateCoef(n);

            StreamWriter sw = new($"../../../../results/logpadecoef_{n}.txt");

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
                sw.WriteLine(c);
            }

            sw.WriteLine("eof");

            sw.Close();
        }

        [TestMethod()]
        public void N24Plot() {
            const int n = 24;

            BigInteger[] actual = LogPadeCoef.GenerateCoef(n);

            StreamWriter sw = new($"../../../../results/logpadecoef_{n}.txt");

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
                sw.WriteLine(c);
            }

            sw.WriteLine("eof");

            sw.Close();
        }

        [TestMethod()]
        public void N32Plot() {
            const int n = 32;

            BigInteger[] actual = LogPadeCoef.GenerateCoef(n);

            StreamWriter sw = new($"../../../../results/logpadecoef_{n}.txt");

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
                sw.WriteLine(c);
            }

            sw.WriteLine("eof");

            sw.Close();
        }

        [TestMethod()]
        public void N64Plot() {
            const int n = 64;

            BigInteger[] actual = LogPadeCoef.GenerateCoef(n);

            StreamWriter sw = new($"../../../../results/logpadecoef_{n}.txt");

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
                sw.WriteLine(c);
            }

            sw.WriteLine("eof");

            sw.Close();
        }

        [TestMethod()]
        public void N128Plot() {
            const int n = 128;

            BigInteger[] actual = LogPadeCoef.GenerateCoef(n);

            StreamWriter sw = new($"../../../../results/logpadecoef_{n}.txt");

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
                sw.WriteLine(c);
            }

            sw.WriteLine("eof");

            sw.Close();
        }

        [TestMethod()]
        public void N256Plot() {
            const int n = 256;

            BigInteger[] actual = LogPadeCoef.GenerateCoef(n);

            StreamWriter sw = new($"../../../../results/logpadecoef_{n}.txt");

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
                sw.WriteLine(c);
            }

            sw.WriteLine("eof");

            sw.Close();
        }

        [TestMethod()]
        public void N512Plot() {
            const int n = 512;

            BigInteger[] actual = LogPadeCoef.GenerateCoef(n);

            StreamWriter sw = new($"../../../../results/logpadecoef_{n}.txt");

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
                sw.WriteLine(c);
            }

            sw.WriteLine("eof");

            sw.Close();
        }

        [TestMethod()]
        public void N1024Plot() {
            const int n = 1024;

            BigInteger[] actual = LogPadeCoef.GenerateCoef(n);

            StreamWriter sw = new($"../../../../results/logpadecoef_{n}.txt");

            foreach (BigInteger c in actual) {
                Console.WriteLine(c);
                sw.WriteLine(c);
            }

            sw.WriteLine("eof");

            sw.Close();
        }
    }
}