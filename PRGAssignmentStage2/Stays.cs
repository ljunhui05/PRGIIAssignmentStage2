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

namespace PRGAssignmentStage2
{
    class Stays
    {
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public List<Room> roomList { get; set; } = new List<Room>();

        //constructors

        public Stays(DateTime checkInDate, DateTime checkOutDate)
        {
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
        }

        public void AddRoom(Room room)
        {
            roomList.Add(room);
        }

        public double CalculateTotal()
        {
            double total = 0;
            return total;
        }

        public string ToString()
        {
            return "CheckInDate:" + checkInDate + "CheckOutDate:" + checkOutDate + "RoomList:" + roomList;
        }
    }
}