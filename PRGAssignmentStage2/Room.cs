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
    abstract class Room
    {
        public int roomNumber { get; set; }
        public string bedConfiguration { get; set; }
        public double dailyRate { get; set; }
        public bool isAvail { get; set; }

        //Constructors

        public Room(int roomNumber, string bedConfiguration, double dailyRate, bool isAvail)
        {
            this.roomNumber = roomNumber;
            this.bedConfiguration = bedConfiguration;
            this.dailyRate = dailyRate;
            this.isAvail = isAvail;
        }

        public abstract double CalculateCharges();

        public override string ToString()
        {
            return "RoomNumber:" + roomNumber + "\tBedConfiguration:" + bedConfiguration + "\tDailyRate:" + dailyRate 
                + "\tAvailability:" + isAvail;

        }
    }
}