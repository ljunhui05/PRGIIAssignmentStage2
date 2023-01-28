﻿// See https://aka.ms/new-console-template for more information
//====================================
//Student Number: S10242387
//Student Name: Lim JunHui
//====================================
//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
//====================================
//Student Number: (S10220867G)
//Student Name: Li Jin Jie
//====================================
//You can copy paste your code into the functions the list of functions you did and what line it is on is below
//Function : Line
//        1:  318
//        3:  360
//        5:  527
//        7:  576
//        8:  586
//If you can pls add a brief description of how the code works and what it does in the top box of every function
//  (can see Line 33 for example)
//If you have any qns on how to access certain things (cos i changed our classes abit sorry!) can msg me

using Microsoft.Win32;
using PRGAssignmentStage2;
using System.Diagnostics.CodeAnalysis;

//Universal lists 
List<Room> roomList = new List<Room>();
List<Guest> guestList = new List<Guest>();


//Universal Arrays
string[] csvRooms = File.ReadAllLines("Rooms.csv");
string[] csvStays = File.ReadAllLines("Stays.csv");

//*********************************InitRoomData()*********************************//
//Initialises room data                                                           //
//Loops through Roooms and Stays csv                                              //
//Checks if room is booked through comparing booked and rooms lists               //
//Checks if room is "Deluxe" or "Standard"                                        //
//Checks if room has been booked                                                  //
//If it has been booked then the program takes the requiresWifi, requiresBreakfast//
//  and additionalBed boolean values.                                             //
//If room is "Deluxe" it takes only the additionalBed value, if it is a "Standard"//
//  room it takes the requiresWifi and requiresBreakfast values                   //
//Creates the respective room objects                                             //
//Adds them to roomList                                                           //
//Checks if there are additional rooms booked in the Stays.csv file               //
//If there is, it executes the same function as mentioned above but adds the      //
//respective values                                                               //
//If there isn't it continues the for loop                                        //
//********************************************************************************//
void InitRoomData()
{
    string[] csvRooms = File.ReadAllLines("Rooms.csv");
    string[] csvStays = File.ReadAllLines("Stays.csv");
    List<string> rooms = new List<string>();
    List<string> booked = new List<string>();

    for (int i = 1; i < csvRooms.Length; i++)
    {
        string[] infoRooms = csvRooms[i].Split(',');
        rooms.Add(infoRooms[1]);
    }

    for (int k = 1; k < csvStays.Length; k++)
    {
        string[] infoStays = csvStays[k].Split(',');
        booked.Add(infoStays[5]);
        if (infoStays[9] != "" && !booked.Contains(infoStays[9]))
        {
            booked.Add(infoStays[9]);
        }
        else
        {
            continue;
        }
    }

    for (int i = 0; i < csvRooms.Length; i++)
    {
        int stayNum = 0;
        string[] infoRooms = csvRooms[i].Split(',');
        for (int j = 1; j < csvStays.Length; j++)
        {
            stayNum = j;
            break;
        }
        string[] infoStays = csvStays[stayNum].Split(',');
        string roomType = infoRooms[0];
        string roomNum = infoRooms[1];
        string bedConfig = infoRooms[2];
        string dailyRate = infoRooms[3];


        if (roomType == "Standard")
        {
            //Checks if certain rooms are unavailable
            if (!booked.Contains(Convert.ToString(roomNum)))
            {
                
                bool requireWifi = Convert.ToBoolean(infoStays[6]);
                bool requireBFast = Convert.ToBoolean(infoStays[7]);
                
                StandardRoom newStandardRoom = new StandardRoom(Convert.ToInt32(roomNum), bedConfig, Convert.ToDouble(dailyRate), true);
                newStandardRoom.requireBreakfast = requireWifi;
                newStandardRoom.requireBreakfast = requireBFast;

                roomList.Add(newStandardRoom);
            }

            else if (booked.Contains(Convert.ToString(roomNum)))
            {
                StandardRoom newStandardRoom = new StandardRoom(Convert.ToInt32(roomNum), bedConfig, Convert.ToDouble(dailyRate), false);

                roomList.Add(newStandardRoom);
            }

        }

        else if (roomType == "Deluxe")
        {
            //Checks if certain rooms are unavailable
            if (!booked.Contains(Convert.ToString(roomNum)))
            {
                bool additionalBed = Convert.ToBoolean(infoStays[8]);
                DeluxeRoom newDeluxeRoom = new DeluxeRoom(Convert.ToInt32(roomNum), bedConfig, Convert.ToDouble(dailyRate), true);
                newDeluxeRoom.additionalBed = additionalBed;
                roomList.Add(newDeluxeRoom);
            }

            else if (booked.Contains(Convert.ToString(roomNum)))
            {
                DeluxeRoom newDeluxeRoom = new DeluxeRoom(Convert.ToInt32(roomNum), bedConfig, Convert.ToDouble(dailyRate), false);
                roomList.Add(newDeluxeRoom);
            }

        }

        if (infoStays[9] != "")
        {
            roomType = infoRooms[0];
            roomNum = infoRooms[1];
            bedConfig = infoRooms[2];
            dailyRate = infoRooms[3];


            if (roomType == "Standard")
            {
                //Checks if certain rooms are unavailable
                if (!booked.Contains(Convert.ToString(roomNum)))
                {

                    bool requireWifi = Convert.ToBoolean(infoStays[10]);
                    bool requireBFast = Convert.ToBoolean(infoStays[11]);

                    StandardRoom newStandardRoom = new StandardRoom(Convert.ToInt32(roomNum), bedConfig, Convert.ToDouble(dailyRate), true);
                    newStandardRoom.requireWifi = requireWifi;
                    newStandardRoom.requireBreakfast = requireBFast;
                    roomList.Add(newStandardRoom);
                }

                else if (booked.Contains(Convert.ToString(roomNum)))
                {
                    StandardRoom newStandardRoom = new StandardRoom(Convert.ToInt32(roomNum), bedConfig, Convert.ToDouble(dailyRate), false);

                    roomList.Add(newStandardRoom);
                }

            }

            else if (roomType == "Deluxe")
            {
                //Checks if certain rooms are unavailable
                if (!booked.Contains(Convert.ToString(roomNum)))
                {
                    bool additionalBed = Convert.ToBoolean(infoStays[12]);
                    DeluxeRoom newDeluxeRoom = new DeluxeRoom(Convert.ToInt32(roomNum), bedConfig, Convert.ToDouble(dailyRate), true);
                    newDeluxeRoom.additionalBed = additionalBed;
                    roomList.Add(newDeluxeRoom);
                }

                else if (booked.Contains(Convert.ToString(roomNum)))
                {
                    DeluxeRoom newDeluxeRoom = new DeluxeRoom(Convert.ToInt32(roomNum), bedConfig, Convert.ToDouble(dailyRate), false);

                    roomList.Add(newDeluxeRoom);
                }

            }
        }

        else
        {
            continue;
        }

    }




}
//*********************************InitGuestData()*********************************//
//Initialises guest data                                                           //
//Loops through the Guest and Stays csv files                                      //
//Gets respective guest informations                                               //
//Checks if guest name matches the name in stays                                   //
//If it matches it would create the Member object using the retrieved data and     //
//  assign the default values to the stay object.                                  //
//Then it would create the guest object and put it in the guestList                //
//*********************************************************************************//
void InitGuestData()
{
    string[] csvGuests = File.ReadAllLines("Guests.csv");
    string[] csvStays = File.ReadAllLines("Stays.csv");
    for(int i = 1; i < csvGuests.Length; i++)
    {
        string[] infoStays = csvStays[i].Split(',');
        string[] infoGuests = csvGuests[i].Split(',');
        string guestName = infoGuests[0];
        string passportNo = infoGuests[1];
        if(guestName == infoStays[0])
        {
            Stays hotelStay = new Stays(default,default);
            Membership member = new Membership(infoGuests[2], Convert.ToInt32(infoGuests[3]));

            Guest newGuest = new Guest(guestName, passportNo, hotelStay, member);
            newGuest.isCheckedin = Convert.ToBoolean(infoStays[2]);
            guestList.Add(newGuest);

        }

        else
        {
            continue;
        }

    }

}

//*********************************InitStayData()*********************************//
//Initialises stay data                                                           //
//Loops through the Stays csv file                                                //
//Checks if passportnum matches passportnum in guestlist if it does then          //
//  overwrite the stay data of that guest.                                        //
//Loops through the csvStays array and retrieves the roomNum of both rooms.       //
//It then loops through the roomList and checks if the second roomNum is a ""     //
//If it is, then the function will only add the room object of the first roomNum  //
//  to the respective Stay objects roomList.                                      //
//If the second roomNum is not a "" then the function will add both the first and //
//  second rooms into the respective Stay objects roomList                        //
//********************************************************************************//
void InitStayData()
{
    string[] csvStays = File.ReadAllLines("Stays.csv");
    for(int i = 1; i < csvStays.Length; i++)
    {
        string[] infoStays = csvStays[i].Split(',');
        string name = infoStays[0];
        string passportNo = infoStays[1];
        DateTime CheckInDate = Convert.ToDateTime(infoStays[3]);
        DateTime CheckOutDate = Convert.ToDateTime(infoStays[4]);
        Stays newStays = new Stays(CheckInDate, CheckOutDate);
        for(int j = 0; j < guestList.Count; j++)
        {
            if (guestList[j].passportNum == passportNo)
            {
                guestList[j].hotelStay = newStays;

                for(int k = 1; k < csvStays.Length; k++)
                {
                    string roomNum1 = infoStays[5];
                    string roomNum2 = infoStays[9];
                    for(int l = 0; l < roomList.Count; l++)
                    {
                        if(roomNum2 == "")
                        {
                            if(roomList[l].roomNumber == Convert.ToInt32(roomNum1))
                            {
                                guestList[j].hotelStay.roomList.Add(roomList[l]);
                            } 
                        }

                        else if(roomNum2 != "")
                        {
                            if (roomList[l].roomNumber == Convert.ToInt32(roomNum1))
                            {
                                guestList[j].hotelStay.roomList.Add(roomList[l]);
                            }

                            else if (roomList[l].roomNumber == Convert.ToInt32(roomNum2))
                            {
                                guestList[j].hotelStay.roomList.Add(roomList[l]);
                            }
                        }
                    }
                }
            }
        }

    }
}

//*********************************dispMenu()*********************************//
//Prints the menu                                                             //
//****************************************************************************//
void dispMenu()
{
    Console.WriteLine("+=====================================+");
    Console.WriteLine("1: Displays all guests");
    Console.WriteLine("2: Displays available rooms");
    Console.WriteLine("3: Register as guest");
    Console.WriteLine("4: Check-In");
    Console.WriteLine("5: Display details of guest");
    Console.WriteLine("6: Extend your stay");
    Console.WriteLine("0: Exit");
    Console.WriteLine("+=====================================+");
}

//*********************************dispAllGuests()*********************************//
//Displays all guests                                                              //
//*********************************************************************************//
void dispAllGuests()
{
    Console.WriteLine("+==============================All Guests==============================+");
    //Can copy paste your code here
    string[] guestInfo = File.ReadAllLines("Guests.csv");
    string[] guestHeader = guestInfo[0].Split(",");

    Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", guestHeader[0], guestHeader[1], guestHeader[2], guestHeader[3]);
    for (int i = 0; i < guestList.Count; i++)
    {
        Guest g = guestList[i];
        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", g.Name, g.passportNum, g.Member.Status, g.Member.Points);
    }
    Console.WriteLine("+======================================================================+");
}

//*********************************DispAvailRooms()*********************************//
//Displays all currently available rooms                                            //
//Loops through the roomList                                                        //
//Checks if roomList.isAvail attribute is true                                      //
//If it is then it will print out the room and its relevant information             //
//**********************************************************************************//
void dispAvailRooms()
{
    

    Console.WriteLine("+================================Available Rooms================================+");
    int num = 0;
    for (int i = 0; i < roomList.Count; i++)
    {
        if (roomList[i].isAvail == true)
        {
            string[] infoRooms = csvRooms[i].Split(',');
            string RoomType = infoRooms[0];
            int roomNum = Convert.ToInt32(roomList[i].roomNumber);
            string BedConfig = roomList[i].bedConfiguration;
            double DailyRate = Convert.ToDouble(roomList[i].dailyRate);
            num++;
            Console.WriteLine("Num: {0,-5} Room: {1,-5} RoomType: {2,-10} BedConfig: {3,-10} DailyRate: {4,-10}"
                ,num, roomNum, RoomType, BedConfig, DailyRate);

        }

    }
    Console.WriteLine("+===============================================================================+");

}

//*********************************registerGuest()*********************************//
//Registers Guests                                                                 //
//*********************************************************************************//
void registerGuest()
{
    Console.WriteLine("+================================Register Guest================================+");
    //Can copy paste your code here
    Console.WriteLine("+===============================================================================+");
}

//*********************************checkInGuest()*********************************//
//Checks in Guests                                                                //
//Prompts user to enter the guests passport number                                //
//Loops through the guestList to find the passportNum that matches the user input //
//Saves the index of the selected guest                                           //
//Prompts user for CheckIn and CheckOut dates                                     //
//Creates Stays obj called newStays that contains the CheckIn and CheckOut dates  //
//  of the user input.                                                            //
//Prompts user to enter the room num that they would like to choose               //
//Loops through the roomList to find the roomList[i].roomNumber that matches the  //
//  user input.                                                                   //
//Based on the class of the room the function will prompt the user for different  //
//  inputs.                                                                       //
//If the room is a StandardRoom it prompt the user if they requireWifi and        //
//  requireBreakfast.                                                             //
//If the room is a DeluxeRoom it will prompt the user if they require             //
//  additionalbed.                                                                //
//Prompts the user if they want to check into more rooms                          //
//If user inputs Y, the function will continue running                            //
//If the user inputs N the function will assign the newStays Stays object to the  //
//  Guest object and update the Guest objects isCheckedin attribute to true       //
//Prints a message to feedback to the user that they have successfully checked in //
//Stops the while loop by assigning check the boolean value of false              //
//********************************************************************************//
void checkInGuest()
{
    int selectedGuest = 0;
    bool check = true;
    dispAllGuests();

    Console.Write("Enter the passport number of guest to start CheckIn: ");
    string opt = Console.ReadLine();
    for (int i = 0; i < guestList.Count; i++)
    {
        if (opt == guestList[i].passportNum)
        {
            selectedGuest = i;
        }
    }

    Console.Write("Enter CheckIn Date:");
    DateTime CheckInDate = Convert.ToDateTime(Console.ReadLine());
    Console.Write("Enter CheckOut Date:");
    DateTime CheckOutDate = Convert.ToDateTime(Console.ReadLine());
    Stays newStays = new Stays(CheckInDate, CheckOutDate);

    while (check == true)
    {
        dispAvailRooms();

        Console.Write("Enter Room Number to select:");
        int roomSelect = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < roomList.Count; i++)
        {

            if (roomSelect == roomList[i].roomNumber)
            {
                if (roomList[i] is StandardRoom)
                {
                    StandardRoom s = (StandardRoom)roomList[i];
                    Console.Write("Do you require WiFi [Y/N]: ");
                    string wifi = Console.ReadLine();
                    Console.Write("Do you require Breakfast [Y/N]: ");
                    string breakFast = Console.ReadLine();
                    if (wifi == "Y" && breakFast == "N")
                    {
                        s.requireWifi = true;
                        s.requireBreakfast = false;
                    }

                    else if (wifi == "N" && breakFast == "Y")
                    {
                        s.requireWifi = false;
                        s.requireBreakfast = true;
                    }

                    else if (wifi == "N" && breakFast == "N")
                    {
                        s.requireWifi = false;
                        s.requireBreakfast = false;
                    }

                    else if (wifi == "Y" && breakFast == "Y")
                    {
                        s.requireWifi = true;
                        s.requireBreakfast = true;
                    }

                    roomList[i].isAvail = false;
                    newStays.roomList.Add(roomList[i]);
                    Console.Write("Do you want to check into more rooms [Y/N]: ");
                    string moreRooms = Console.ReadLine();
                    if (moreRooms == "Y")
                    {
                        check = true;
                    }

                    else if (moreRooms == "N")
                    {
                        guestList[selectedGuest].hotelStay = newStays;
                        guestList[selectedGuest].isCheckedin = true;
                    }

                    Console.WriteLine("+==========================+");
                    Console.WriteLine("+Successfully Checked in");
                    Console.WriteLine("+==========================+");
                    check = false;
                    return;
                }
            }

            else if (roomList[i] is DeluxeRoom)
            {
                DeluxeRoom d = (DeluxeRoom)roomList[i];
                Console.Write("Do you require an additional bed [Y/N]: ");
                string addBed = Console.ReadLine();

                if (addBed == "Y")
                {
                    d.additionalBed = true;
                }

                else if (addBed == "N")
                {
                    d.additionalBed = false;
                }

                roomList[i].isAvail = false;
                newStays.roomList.Add(roomList[i]);
                Console.Write("Do you want to check into more rooms [Y/N]: ");
                string moreRooms = Console.ReadLine();
                if (moreRooms == "Y")
                {
                    check = true;
                }

                else if (moreRooms == "N")
                {
                    guestList[selectedGuest].hotelStay = newStays;
                    guestList[selectedGuest].isCheckedin = true;


                    Console.WriteLine("+==========================+");
                    Console.WriteLine("+Successfully Checked in");
                    Console.WriteLine("+==========================+");
                    check = false;
                    return;
                }

            }

        }
    }

}

//*********************************dispGuestStay()*********************************//
//Displays all Guests Stay details                                                 //
//*********************************************************************************//
void dispGuestStay()
{
    Console.WriteLine("+================================Guest Stay Details================================+");
    //Can copy paste your code here
    Console.WriteLine("+================================================================================= +");
}

//*********************************extendStay()*********************************//
//Extends stay of guest                                                         //
//Prompts the user for the passport number of the selected guest to extend stay //
//Loops through the guestList to find guests passport number that matches the   //
//  user input.                                                                 //
//Prompts the user to enter the number of days that they want to extend their   //
//  stay by.                                                                    //
//Accesses the selectedGuest's checkOutDate and adds the number of days to it   //
//Prints message to feedback to user that they have successfully extended their //
//  stay.                                                                       //
//******************************************************************************//
void extendStay()
{
    int selectedGuest = 0;
    dispAllGuests();
    Console.Write("Enter the passport number of guest to extend stay: ");
    string opt = Console.ReadLine();
    for (int i = 0; i < guestList.Count; i++)
    {
        if (opt == guestList[i].passportNum)
        {
            selectedGuest = i;
        }
    }

    Console.Write("Enter number of extra days do you want to stay: ");
    double daysExtend = Convert.ToDouble(Console.ReadLine());
    DateTime newStayDays = guestList[selectedGuest].hotelStay.checkOutDate.AddDays(daysExtend);
    guestList[selectedGuest].hotelStay.checkOutDate = newStayDays;

    Console.WriteLine("+=============================+");
    Console.WriteLine("+Successfully Extended Stay");
    Console.WriteLine("+New check out date is {0}", guestList[selectedGuest].hotelStay.checkOutDate);
    Console.WriteLine("+=============================+");



}

//*********************************dispMonthCharge()*********************************//
//Displays monthly charged amounts breakdown & totaal charged amts for the year      //
//***********************************************************************************//
void dispMonthCharge()
{
    Console.WriteLine("+================================Monthly Charge================================+");
    //Can copy paste your code here (if you havent gotten this one to work yet we can work on it tgt)
    Console.WriteLine("+==============================================================================+");
}

//*********************************checkOutGuest()*********************************//
//Checks out Guest                                                                 //
//*********************************************************************************//
void checkOutGuest()
{
    int selectedGuest = 0;
    Console.WriteLine("+================================ Check Out Guest ================================+");
    dispAllGuests();
    Console.WriteLine("+=================================================================================+");

    Console.Write("Enter the passport number of guest to check out: ");
    string passportNum = Console.ReadLine();
    for (int i = 0 ; i < guestList.Count ; i++)
    {
        if (guestList[i].passportNum == passportNum)
        {
            selectedGuest = i;
        }
    }
}

//*********************************Main()*****************************************//
//Calls all the functions of the program                                          //
//********************************************************************************//
void Main()
{
    InitRoomData();
    InitGuestData();
    InitStayData();
    bool check = true;
    

    while (check == true)
    {
        dispMenu();
        Console.Write("Please enter your option:");
        int opt = Convert.ToInt32(Console.ReadLine());

        if (opt == 1)
        {
            dispAllGuests();
        }

        else if (opt == 2)
        {
            dispAvailRooms();
        }

        else if (opt == 3)
        {
            registerGuest();
        }

        else if (opt == 4)
        {
            checkInGuest();
        }

        else if (opt == 5)
        {
            //dispGuestStay();
        }

        else if (opt == 6)
        {
            extendStay();
        }

        else if (opt == 7)
        {
            //dispMonthCharge();
        }

        else if (opt == 8)
        {
            //checkOutGuest();
        }

        else if (opt == 0)
        {
            Console.WriteLine("Goodbye!");
            check = false;
        }

    }


}

Main();
