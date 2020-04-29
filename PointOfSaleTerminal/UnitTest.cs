using Xunit;
using Xunit.Abstractions;
using PointOfSaleTerminalLibrary;

namespace PointOfSaleTerminal
{
    public class UnitTest
    {
        private readonly ITestOutputHelper output;

        public UnitTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void ExampleTest1()
        {
            PointOfSaleTerminalService terminal = new PointOfSaleTerminalService();
            this.SetPrices(terminal);

            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("A");

            decimal expected = 13.25M;
            decimal result = terminal.CalculateTotal();
            Assert.Equal(expected, result);
            output.WriteLine("Example 1 result: $" + result);
        }
        [Fact]
        public void ExampleTest2()
        {
            PointOfSaleTerminalService terminal = new PointOfSaleTerminalService();
            this.SetPrices(terminal);

            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");

            decimal expected = 6.00M;
            decimal result = terminal.CalculateTotal();
            Assert.Equal(expected, result);
            output.WriteLine("Example 2 result: $" + result);
        }
        [Fact]
        public void ExampleTest3()
        {
            PointOfSaleTerminalService terminal = new PointOfSaleTerminalService();
            this.SetPrices(terminal);

            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");

            decimal expected = 7.25M;
            decimal result = terminal.CalculateTotal();
            Assert.Equal(expected, result);
            output.WriteLine("Example 3 result: $" + result);
        }
        [Fact]
        public void ExampleTest4()
        {
            string scanResult;

            PointOfSaleTerminalService terminal = new PointOfSaleTerminalService();
            this.SetPrices(terminal);

            // series of scans: FABBAACACCCCCDD (F:1 A:4 B:2 C:6 D:2)
            scanResult = terminal.ScanProduct("F"); // Product doesn´t exist (It hasn´t been registered as a valid product before hand)
            if (scanResult != "OK")
                output.WriteLine(scanResult);

            scanResult = terminal.ScanProduct("A");
            scanResult = terminal.ScanProduct("B");
            scanResult = terminal.ScanProduct("B");
            scanResult = terminal.ScanProduct("A");
            scanResult = terminal.ScanProduct("A");
            scanResult = terminal.ScanProduct("C");
            scanResult = terminal.ScanProduct("A");
            scanResult = terminal.ScanProduct("C");
            scanResult = terminal.ScanProduct("C");
            scanResult = terminal.ScanProduct("C");
            scanResult = terminal.ScanProduct("C");
            scanResult = terminal.ScanProduct("C");
            scanResult = terminal.ScanProduct("D");
            scanResult = terminal.ScanProduct("D");

            decimal expected = 19.25M;
            decimal result = terminal.CalculateTotal();
            Assert.Equal(expected, result);
            output.WriteLine("Example 4 result: $" + result);
        }
        [Fact]
        public void ExampleTest5()
        {
            PointOfSaleTerminalService terminal = new PointOfSaleTerminalService();
            this.SetPrices(terminal);

            // series: (7 A, 1 B, 5 C, 1 D)

            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            terminal.ScanProduct("A");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");

            decimal expected = 17.25M;
            decimal result = terminal.CalculateTotal();
            Assert.Equal(expected, result);
            output.WriteLine("Example 5 result: $" + result);
        }

        internal void SetPrices(PointOfSaleTerminalService terminal)
        {
            terminal.SetPricing("A", 1.25, true, 3, 3);
            terminal.SetPricing("B", 4.25, false, 0, 0);
            terminal.SetPricing("C", 1, true, 6, 5);
            terminal.SetPricing("D", 0.75, false, 0, 0);
        }
    }
}
