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
            var gradient = CalculatorViewModel.GetGradient(20);
            var expected = (3.8285714285714287, -54.42857142857143);
            Assert.AreEqual(expected, gradient);
        }
        [Test]
        public void GetFormulaFor23mm()
        {
            var gradient = CalculatorViewModel.GetGradient(23);
            var expected = (3.2903225806451615, -47.935483870967744);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void GetFormulaFor25mm()
        {
            var gradient = CalculatorViewModel.GetGradient(25);
            var expected = (2.5625, -35.28125);
            Assert.AreEqual(expected, gradient);
        }
        [Test]
        public void GetFormulaFor28mm()
        {
            var gradient = CalculatorViewModel.GetGradient(28);
            var expected = (1.702127659574468, -2.765957446808514);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void GetFormulaFor32mm()
        {
            var gradient = CalculatorViewModel.GetGradient(32);
            var expected = (1.3333333333333333, -2);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void GetFormulaFor37mm()
        {
            var gradient = CalculatorViewModel.GetGradient(37);
            var expected = (0.9230769230769231, 2.3076923076923066);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void GetFormulaFor0mm()
        {
            var gradient = CalculatorViewModel.GetGradient(0);
            var expected = (0, 0);
            Assert.AreEqual(expected, gradient);
        }

        [Test]
        public void GetFormulaFor50mm()
        {
            var gradient = CalculatorViewModel.GetGradient(50);
            var expected = (0, 0);
            Assert.AreEqual(expected, gradient);
        }




        [Test]
        public void CalculatePressure25mm65kg()
        {
            var pressure = CalculatorViewModel.CalculateTyrePressure(25, 65);
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
            var pressure = CalculatorViewModel.CalculateTyrePressure(25, 45);
            var expected = 83;
            Assert.Multiple(() =>
            {
                Assert.GreaterOrEqual(expected * 1.05, pressure);
                Assert.LessOrEqual(expected * 0.95, pressure);
            });
        }

        [Test]
        public void CalculateCommand25mm45kg()
        {
            var vm = new CalculatorViewModel
            {
                FrontTyreWidth = 25,
                RearTyreWidth = 25,
                FrontLoad = 45,
                RearLoad = 45
            };
            vm.CalculateCommand.Execute(null);
            var expected = 83;
            Assert.Multiple(() =>
            {
                Assert.GreaterOrEqual(expected * 1.05, vm.FrontPressure);
                Assert.LessOrEqual(expected * 0.95, vm.FrontPressure);
                Assert.GreaterOrEqual(expected * 1.05, vm.RearPressure);
                Assert.LessOrEqual(expected * 0.95, vm.RearPressure);
            });
        }

        [Test]
        public void RoundedWidthLessThan20()
        {
            var expected = 20;
            var actual = CalculatorViewModel.GetRoundedWidth(19);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RoundedWidth21point4()
        {
            var expected = 20;
            var actual = CalculatorViewModel.GetRoundedWidth(21.4);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RoundedWidth21point6()
        {
            var expected = 23;
            var actual = CalculatorViewModel.GetRoundedWidth(21.6);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RoundedWidth24Point1()
        {
            var expected = 25;
            var actual = CalculatorViewModel.GetRoundedWidth(24.1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RoundedWidth50()
        {
            var expected = 37;
            var actual = CalculatorViewModel.GetRoundedWidth(50);
            Assert.AreEqual(expected, actual);
        }

    }
}
