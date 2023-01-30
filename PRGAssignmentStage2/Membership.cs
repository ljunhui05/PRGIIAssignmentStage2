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
    class Membership
    {
        public string Status { get; set; }
        public int Points { get; set; }

        //constructors
        public Membership(string Status, int Points)
        {
            this.Status = Status;
            this.Points = Points;
        }

        public void EarnPoints(double amt)
        {
            int pointsEarned = Convert.ToInt32(amt) / 10;
            Points += pointsEarned;
        }

        public bool RedeemPoints(int points)
        {
            Points -= points;
            return true;

        }

        public string ToString()
        {
            return "Status:" + Status + "Points:" + Points;
        }
    }
}