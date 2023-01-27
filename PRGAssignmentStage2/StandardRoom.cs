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

        public StandardRoom(int roomNumber, string bedConfiguration, double dailyRate, bool isAvail, bool requireWifi, bool requireBreakfast)
            : base(roomNumber, bedConfiguration, dailyRate, isAvail)
        {
            this.requireWifi = requireWifi;
            this.requireBreakfast = requireBreakfast;
        }

        public override double CalculateCharges()
        {
            return 0;
        }

        public override string ToString()
        {
            return base.ToString() + "RequiresWifi = " + requireWifi + "RequiresBreakfast = " + requireBreakfast;
        }
    }
}