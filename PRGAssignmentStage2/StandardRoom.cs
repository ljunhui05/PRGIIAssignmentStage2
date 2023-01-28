using PRGAssignmentStage2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//====================================
//Student Number: S10242387
//Student Name: Lim JunHui
//====================================

namespace PRGAssignmentStage2
{
    class StandardRoom : Room
    {
        public bool requireWifi { get; set; }
        public bool requireBreakfast { get; set; }

        //Constructors

        public StandardRoom(int roomNumber, string bedConfiguration, double dailyRate, bool isAvail)
            : base(roomNumber, bedConfiguration, dailyRate, isAvail)
        {
        }

        public override double CalculateCharges()
        {
            if (requireWifi == true && requireBreakfast == true)
            {
                double chargePerday = dailyRate + 30;
                return chargePerday;
            }

            else if (requireWifi == true)
            {
                double chargePerday = dailyRate + 10;
                return chargePerday;
            }

            else if (requireBreakfast == true)
            {
                double chargePerday = dailyRate + 20;
                return chargePerday;
            }

            else
            {
                return dailyRate;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\tRequiresWifi = " + requireWifi + "\tRequiresBreakfast = " + requireBreakfast;
        }
    }
}