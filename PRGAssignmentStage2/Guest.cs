using PRGAssignmentStage2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//====================================
//Student Number: S10242387
//Student Name: Lim JunHui
//====================================

namespace PRGAssignmentStage2
{
    class Guest
    {
        public string Name { get; set; }
        public string passportNum { get; set; }
        public Stays hotelStay { get; set; }
        public Membership Member { get; set; }
        public bool isCheckedin { get; set; }


        //constructors
        public Guest(string Name, string passportNum, bool isCheckedin, Stays hotelStay, Membership Member)
        {
            this.Name = Name;
            this.passportNum = passportNum;
            this.hotelStay = hotelStay;
            this.Member = Member;
            this.isCheckedin = isCheckedin;
        }

        public string ToString()
        {
            return "Name:" + Name + "PassportNum:" + passportNum + "HotelStay:" + hotelStay + "Member:" + Member;
        }
    }
}
