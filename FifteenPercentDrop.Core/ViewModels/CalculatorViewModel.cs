using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace FifteenPercentDrop.Core.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        private double tyreWidth = 23;
        private double totalWeight = 80;
        private double bikeWeight = 20;
        private double riderWeight = 60;
        private double percentageOnFront = 40;

        public double BikeWeight
        {
            get => bikeWeight;
            set
            {
                SetProperty(ref bikeWeight, value);
                UpdateTotalWeight();
            }
        }

        public double RiderWeight
        {
            get => riderWeight;
            set
            {
                SetProperty(ref riderWeight, value);
                UpdateTotalWeight();
            }
        }

        public double TotalWeight
        {
            get => totalWeight;
            set
            {
                SetProperty(ref totalWeight, value);
                OnPropertyChanged(nameof(FrontPressure));
                OnPropertyChanged(nameof(RearPressure));
            }
        }
        public double FrontLoad => (PercentageOnFront / 100) * TotalWeight;
        public double RearLoad => (1 - PercentageOnFront / 100) * TotalWeight;

        public double PercentageOnFront
        {
            get => percentageOnFront;
            set
            {
                SetProperty(ref percentageOnFront, value);
                OnPropertyChanged(nameof(FrontPressure));
                OnPropertyChanged(nameof(RearPressure));
            }
        }

        public double UpdateTotalWeight()
        {
            TotalWeight = RiderWeight + BikeWeight;
            return TotalWeight;
        }

        public double TyreWidth
        {
            get => tyreWidth;
            set
            {
                var rounded = GetRoundedWidth(value);
                SetProperty(ref tyreWidth, rounded);
                OnPropertyChanged(nameof(FrontPressure));
                OnPropertyChanged(nameof(RearPressure));
            }
        }

        public static double GetRoundedWidth(double value)
        {
            var ordered = TyreSizes.OrderBy(x => Math.Abs(x - value));
            var closest = ordered.FirstOrDefault();
            return closest;
        }

        public double FrontPressure => CalculateTyrePressure(FrontLoad);
        public double RearPressure => CalculateTyrePressure(RearLoad);
        public double DropPercentage { get; set; } = 15;

        static readonly List<double> TyreSizes = new List<double> { 20, 23, 25, 28, 32, 37 };

        public ICommand IncrementWeightCommand => new Command(DoIncrementWeightCommand);
        public ICommand DecrementWeightCommand => new Command(DoDecrementWeightCommand);
        public ICommand IncrementWithCommand => new Command(DoIncrementWidthCommand);
        public ICommand DecrementWidthCommand => new Command(DoDecrementWidthCommand);

        private void DoIncrementWidthCommand(object obj)
        {
            double incremented = TyreSizes.ElementAtOrDefault(TyreSizes.IndexOf(TyreWidth) + 1);

            if (incremented != 0)
                TyreWidth = incremented;
        }


        private void DoDecrementWidthCommand(object obj)
        {
            double incremented = TyreSizes.ElementAtOrDefault(TyreSizes.IndexOf(TyreWidth) - 1);

            if (incremented != 0)
                TyreWidth = incremented;
        }

        private void DoDecrementWeightCommand(object obj)
        {
            TotalWeight -= 1;
        }

        private void DoIncrementWeightCommand(object obj)
        {
            TotalWeight += 1;
        }

        public (double m, double c) Gradient
        {
            get
            {

                if (TyreWidth == 20)
                    return (3.8285714285714287, -54.42857142857143);//(32.5,70), (50,137)
                else if (TyreWidth == 23)
                    return (3.2903225806451615, -47.935483870967744);//Points: (32.5,59), (48,110)
                else if (TyreWidth == 25)
                    return (2.5625, -35.28125);//(32.5,48), (64.5,130)
                else if (TyreWidth == 28)
                    return (1.702127659574468, -2.765957446808514);//Points: (31,50), (54.5,90)
                else if (TyreWidth == 32)
                    return (1.3333333333333333, -2);//Points: (39,50), (69,90)
                else if (TyreWidth == 37)
                    return (0.9230769230769231, 2.3076923076923066);//(30,30),(62.5,60)
                else
                    return (0, 0);
            }

        }

        public double CalculateTyrePressure(double load)
        {
            var (m, c) = Gradient;
            var pressure = m * load + c;
            return pressure;
        }
    }
}
