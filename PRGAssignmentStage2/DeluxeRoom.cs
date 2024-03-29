﻿using PRGAssignmentStage2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//====================================
//Student Number: S10242387
//Student Name: Lim JunHui
//====================================
//Student Number: S10220867
//Student Name: Li Jin Jin
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
            if (additionalBed == true)
            {
                double chargePerday = dailyRate + 25;
                return chargePerday;
            }
            else
            {
                return dailyRate;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\tAdditionalBed: " + additionalBed;
        }
    }
}