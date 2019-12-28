using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace FifteenPercentDrop.Core.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
       

        private double frontPressure;
        private double rearPressure;
        private double frontLoad;
        private double rearLoad;
        private double frontTyreWidth;
        private double rearTyreWidth;
        private double totalWeight;
        private double bikeWeight;
        private double riderWeight;
        private double percentageOnFront;

        public CalculatorViewModel()
        {
        }

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


        public double TotalWeight { get => totalWeight; set => SetProperty(ref totalWeight,  value); }
        public double FrontLoad { get => frontLoad; set => SetProperty(ref frontLoad, value); }
        public double RearLoad { get => rearLoad; set => SetProperty(ref rearLoad, value); }
        public double PercentageOnFront
        {
            get => percentageOnFront;
            set
            {
                SetProperty(ref percentageOnFront, value);
                UpdateLoadDistribution();
            }
        }




        public double UpdateTotalWeight()
        {
            TotalWeight = RiderWeight + BikeWeight;
            UpdateLoadDistribution();
            return TotalWeight;
        }

        public (double frontLoad, double rearLoad) UpdateLoadDistribution()
        {
            FrontLoad = (PercentageOnFront / 100) * TotalWeight;
            RearLoad = (1 - PercentageOnFront / 100) * TotalWeight;
            return (FrontLoad, RearLoad);
        }





        public double FrontTyreWidth
        {
            get => frontTyreWidth;
            set
            {
                var rounded = GetRoundedWidth(value);
                SetProperty(ref frontTyreWidth, rounded);
            }
        }

        public static double GetRoundedWidth(double value)
        {
            var ordered = TyreSizes.OrderBy(x => Math.Abs(x - value));
            var closest = ordered.FirstOrDefault();
            return closest;
        }

        public double RearTyreWidth { get => rearTyreWidth;
            set
            {
                var rounded = GetRoundedWidth(value);
                SetProperty(ref rearTyreWidth, rounded);
            }
        }
        public double FrontPressure { get => frontPressure; set => SetProperty(ref frontPressure, value); }
        public double RearPressure { get => rearPressure; set => SetProperty(ref rearPressure, value); }

        public double DropPercentage { get; set; } = 15;

        static List<double> TyreSizes = new List<double>
        {
            20,
            23,
            25,
            28,
            32,
            37
        };

        public ICommand CalculateCommand => new Command(DoCalculateCommand);

        private void DoCalculateCommand(object obj)
        {
            FrontPressure = CalculateTyrePressure(FrontTyreWidth, FrontLoad);
            RearPressure = CalculateTyrePressure(RearTyreWidth, RearLoad);
        }


        public static (double m, double c) GetGradient(double tyreWidth)
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

        public static double CalculateTyrePressure(double tyreWidth, double load)
        {
            var (m, c) = GetGradient(tyreWidth);
            var pressure = m * load + c;
            return pressure;
        }
    }
}
