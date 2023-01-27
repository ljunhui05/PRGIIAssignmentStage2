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
    class DeluxeRoom : Room
    {
        public bool additionalBed { get; set; }

        //constructors

        public DeluxeRoom(int roomNumber, string bedConfiguration, double dailyRate, bool isAvail) : base(roomNumber, bedConfiguration, dailyRate, isAvail)
        {
        }

        public override double CalculateCharges()
        {
            return 0;
        }

        public override string ToString()
        {
            return base.ToString() + "AdditionalBed: " + additionalBed;
        }
    }
}