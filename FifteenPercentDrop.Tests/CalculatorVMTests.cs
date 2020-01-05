using System;
using FifteenPercentDrop.Core.ViewModels;
using NUnit.Framework;

namespace FifteenPercentDrop.Tests
{
    public class CalculatorVMTests
    {



        [Test]
        public void GetFormulaFor20mm()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 20,
            };

            var gradient = vm.GetGradient(20);
            var expected = (3.8285714285714287, -54.42857142857143);
            Assert.AreEqual(expected, gradient);
        }
        [Test]
        public void GetFormulaFor23mm()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 23,
            };

            var gradient = vm.GetGradient(23);
            var expected = (3.2903225806451615, -47.935483870967744);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void GetFormulaFor25mm()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 25,
            };

            var gradient = vm.GetGradient(25);
            var expected = (2.5625, -35.28125);
            Assert.AreEqual(expected, gradient);
        }
        [Test]
        public void GetFormulaFor28mm()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 28,
            };

            var gradient = vm.GetGradient(28);
            var expected = (1.702127659574468, -2.765957446808514);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void GetFormulaFor32mm()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 32,
            };

            var gradient = vm.GetGradient(32);
            var expected = (1.3333333333333333, -2);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void GetFormulaFor37mm()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 37,
            };

            var gradient = vm.GetGradient(37);
            var expected = (0.9230769230769231, 2.3076923076923066);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void CalculatePressure25mm65kg()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 25,
            };

            var pressure = vm.CalculateTyrePressure(65,25);
            var expected = 130;
            Assert.Multiple(() =>
            {
                Assert.GreaterOrEqual(expected * 1.05, pressure);
                Assert.LessOrEqual(expected * 0.95, pressure);
            });
        }

        [Test]
        public void CalculatePressure25mm45kg()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 25,
            };
            var pressure = vm.CalculateTyrePressure(45,25);
            var expected = 83;
            Assert.Multiple(() =>
            {
                Assert.GreaterOrEqual(expected * 1.05, pressure);
                Assert.LessOrEqual(expected * 0.95, pressure);
            });
        }

        [Test]
        public void Calculate25mm90kgTotal()
        {
            var vm = new CalculatorViewModel
            {
                TyreWidth = 25,
                TotalWeight = 90,
            };
            var expectedFront = 57;
            var expectedRear = 103;
            Assert.Multiple(() =>
            {
                Assert.GreaterOrEqual(expectedFront * 1.05, vm.FrontPressure);
                Assert.LessOrEqual(expectedFront * 0.95, vm.FrontPressure);
                Assert.GreaterOrEqual(expectedRear * 1.05, vm.RearPressure);
                Assert.LessOrEqual(expectedRear * 0.95, vm.RearPressure);
            });
        }

        [Test]
        public void RoundedWidthLessThan20()
        {
            var vm = new CalculatorViewModel();

            var expected = 20;
            var actual = vm.GetRoundedWidth(19);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RoundedWidth21point4()
        {
            var vm = new CalculatorViewModel();
            var expected = 20;
            var actual = vm.GetRoundedWidth(21.4);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RoundedWidth21point6()
        {
            var vm = new CalculatorViewModel();
            var expected = 23;
            var actual = vm.GetRoundedWidth(21.6);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RoundedWidth24Point1()
        {
            var vm = new CalculatorViewModel();
            var expected = 25;
            var actual = vm.GetRoundedWidth(24.1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RoundedWidth50()
        {
            var vm = new CalculatorViewModel();
            var expected = 37;
            var actual = vm.GetRoundedWidth(50);
            Assert.AreEqual(expected, actual);
        }

    }
}
