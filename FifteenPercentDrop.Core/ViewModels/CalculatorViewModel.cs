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
        private double frontTyreWidth = 23;
        private double rearTyreWidth = 23;
        private double? totalWeight = 80;
        private double bikeWeight = 20;
        private double riderWeight = 60;
        private int percentageOnFront = 40;
        private double frontLoad;
        private double rearLoad;

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


        public double? TotalWeight
        {
            get => totalWeight;
            set
            {
                SetProperty(ref totalWeight, value);

                UpdateFrontAndRearWeight();
                OnPropertyChanged(nameof(FrontPressure));
                OnPropertyChanged(nameof(RearPressure));
            }
        }



        
        public double FrontLoad
        {
            get => frontLoad;
            set
            {
                SetProperty(ref frontLoad, value);
                OnPropertyChanged(nameof(FrontPressure));
            }
        }
        public double RearLoad
        {
            get => rearLoad;
            set
            {
                SetProperty(ref rearLoad, value);
                OnPropertyChanged(nameof(RearPressure));
            }
        }



        public int PercentageOnFront
        {
            get => percentageOnFront;
            set
            {
                SetProperty(ref percentageOnFront, value);
                UpdateFrontAndRearWeight();
                OnPropertyChanged(nameof(FrontPressure));
                OnPropertyChanged(nameof(RearPressure));

            }
        }

        public double UpdateTotalWeight()
        {
            TotalWeight = RiderWeight + BikeWeight;
            return TotalWeight ?? 0;
        }

        public (double rear,double front) UpdateFrontAndRearWeight()
        {
            FrontLoad = ((double)PercentageOnFront / 100) * TotalWeight ?? 0;
            RearLoad = (1 - (double)PercentageOnFront / 100) * TotalWeight ?? 0;


            return (RearLoad, FrontLoad);
        }


        public double TyreWidth
        {
            get => tyreWidth;
            set
            {
                var rounded = GetRoundedWidth(value);
                SetProperty(ref tyreWidth, rounded);
                rearTyreWidth = rounded;
                frontTyreWidth = value;
                OnPropertyChanged(nameof(FrontPressure));
                OnPropertyChanged(nameof(RearPressure));
            }
        }

        public double FrontTyreWidth
        {
            get => frontTyreWidth;
            set
            {
                var rounded = GetRoundedWidth(value);
                SetProperty(ref frontTyreWidth, rounded);
                OnPropertyChanged(nameof(FrontPressure));
            }
        }

        public double RearTyreWidth
        {
            get => rearTyreWidth;
            set
            {
                var rounded = GetRoundedWidth(value);
                SetProperty(ref rearTyreWidth, rounded);
                OnPropertyChanged(nameof(RearPressure));
            }
        }

        public double GetRoundedWidth(double value)
        {
            var ordered = TyreSizes.OrderBy(x => Math.Abs(x - value));
            var closest = ordered.FirstOrDefault();
            return closest;
        }

        public double FrontPressure => CalculateTyrePressure(FrontLoad, frontTyreWidth);
        public double RearPressure => CalculateTyrePressure(RearLoad, rearTyreWidth);
        public double DropPercentage { get; set; } = 15;

        public List<double> TyreSizes { get; } = new List<double> { 20, 23, 25, 28, 32, 37 };

        public (double m, double c) GetGradient(double tyreWidth)
        {
                if (tyreWidth == 20)
                    return (3.8285714285714287, -54.42857142857143);//(32.5,70), (50,137)
                else if (tyreWidth == 23)
                    return (3.2903225806451615, -47.935483870967744);//Points: (32.5,59), (48,110)
                else if (tyreWidth == 25)
                    return (2.5625, -35.28125);//(32.5,48), (64.5,130)
                else if (tyreWidth == 28)
                    return (1.702127659574468, -2.765957446808514);//Points: (31,50), (54.5,90)
                else if (tyreWidth == 32)
                    return (1.3333333333333333, -2);//Points: (39,50), (69,90)
                else if (tyreWidth == 37)
                    return (0.9230769230769231, 2.3076923076923066);//(30,30),(62.5,60)
                else
                    return (0, 0);
        }

        public double CalculateTyrePressure(double load, double tyreWidth)
        {
            var (m, c) = GetGradient(tyreWidth);
            var pressure = m * load + c;
            return pressure;
        }
    }
}
