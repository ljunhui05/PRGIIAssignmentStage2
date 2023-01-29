// See https://aka.ms/new-console-template for more information
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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

//Universal lists 
List<Room> roomList = new List<Room>();
List<Guest> guestList = new List<Guest>();
List<StandardRoom> standardList = new List<StandardRoom>();
List<DeluxeRoom> deluxeList = new List<DeluxeRoom>();
List<Stays>stayList = new List<Stays>();



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
        
        Stays hotelStay = new Stays(default,default);
        Membership member = new Membership(infoGuests[2], Convert.ToInt32(infoGuests[3]));

        Guest newGuest = new Guest(guestName, passportNo, hotelStay, member);
        newGuest.isCheckedin = Convert.ToBoolean(infoStays[2]);
        guestList.Add(newGuest);

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
        stayList.Add(newStays);
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
                                //guestList[j].hotelStay.roomList.Add(roomList[l]);
                            } 
                        }

                        else if(roomNum2 != "")
                        {
                            if (roomList[l].roomNumber == Convert.ToInt32(roomNum1))
                            {
                                //guestList[j].hotelStay.roomList.Add(roomList[l]);
                            }

                            else if (roomList[l].roomNumber == Convert.ToInt32(roomNum2))
                            {
                                //guestList[j].hotelStay.roomList.Add(roomList[l]);
                            }
                        }
                    }
                }
            }
        }

    }
}

//*********************************AssignRoomAttributes()*********************************//
//Assigns attributes to rooms                                                             //
//****************************************************************************************//
void AssignRoomAttributes()
{
    string[] csvRooms = File.ReadAllLines("Rooms.csv");
    string[] csvStays = File.ReadAllLines("Stays.csv");

    List<StandardRoom> tempstandardList = new List<StandardRoom>();
    List<DeluxeRoom> tempdeluxeList = new List<DeluxeRoom>();

    for (int i = 1; i < csvRooms.Length; i++)
    {
        string[] roomContent = csvRooms[i].Split(',');

        if (roomContent[0] == "Standard")
        {
            tempstandardList.Add(new StandardRoom(Convert.ToInt32(roomContent[1]), roomContent[2], Convert.ToDouble(roomContent[3]), true));
        }
        else
        {
            tempdeluxeList.Add(new DeluxeRoom(Convert.ToInt32(roomContent[1]), roomContent[2], Convert.ToDouble(roomContent[3]), true));
        }
    }

    Guest SearchGuest(List<Guest> gList, string passportNum)
    {
        for (int i = 0; i < guestList.Count; i++)
        {
            Guest g = guestList[i];
            if (g.passportNum == passportNum)
            {
                return g;
            }
        }
        return null;
    }

    StandardRoom SearchStandardRoom(List<StandardRoom> srList, int sdRoomNum)
    {
        for (int i = 0; i < srList.Count; i++)
        {
            StandardRoom sr = srList[i];
            if (sr.roomNumber == sdRoomNum)
            {
                return sr;
            }
        }
        return null;
    }

    DeluxeRoom SearchDeluxeRoom(List<DeluxeRoom> drList, int? drRoomNum)
    {
        for (int i = 0; i < drList.Count; i++)
        {
            DeluxeRoom dr = drList[i];
            if (dr.roomNumber == drRoomNum)
            {
                return dr;
            }
        }
        return null;
    }



    for (int j = 1; j < csvStays.Length; j++)
    {
        string[] stayContent = csvStays[j].Split(',');
        for (int i = 1; i < csvRooms.Length; i++)
        {
            string[] roomContent = csvRooms[i].Split(',');

            Guest checkguest = SearchGuest(guestList, stayContent[1]);
            if (roomContent[1] == stayContent[5])
            {
                if (stayContent[9] == "")
                {
                    stayContent[9] = null;
                }

                StandardRoom firstStandardRoom = SearchStandardRoom(tempstandardList, Convert.ToInt32(stayContent[5]));
                DeluxeRoom firstDeluxeRoom = SearchDeluxeRoom(tempdeluxeList, Convert.ToInt32(stayContent[5]));
                if (firstStandardRoom != null)
                {
                    StandardRoom room;
                    room = new StandardRoom(firstStandardRoom.roomNumber, firstStandardRoom.bedConfiguration, firstStandardRoom.dailyRate, firstStandardRoom.isAvail);
                    room.requireWifi = Convert.ToBoolean(stayContent[6].ToLower());
                    room.requireBreakfast = Convert.ToBoolean(stayContent[7].ToLower());
                    room.isAvail = !(Convert.ToBoolean(stayContent[2].ToLower()));

                    standardList.Add(room);
                    checkguest.hotelStay.AddRoom(room);

                }
                if (firstDeluxeRoom != null)
                {
                    DeluxeRoom room;
                    room = new DeluxeRoom(firstDeluxeRoom.roomNumber, firstDeluxeRoom.bedConfiguration, firstDeluxeRoom.dailyRate, firstDeluxeRoom.isAvail);
                    room.additionalBed = Convert.ToBoolean(stayContent[8].ToLower());
                    room.isAvail = !(Convert.ToBoolean(stayContent[2].ToLower()));
                    //new StandardRoom(firstStandardRoom.roomNumber, firstStandardRoom.bedConfiguration, firstStandardRoom.dailyRate, firstStandardRoom.isAvail)
                    deluxeList.Add(room);
                    checkguest.hotelStay.AddRoom(room);
                }

            }

            else if (roomContent[1] == stayContent[9])
            {
                int placeholder = 0;
                if (int.TryParse(stayContent[9], out placeholder))
                {
                    StandardRoom secondStandardRoom = SearchStandardRoom(tempstandardList, placeholder);
                    DeluxeRoom secondDeluxeRoom = SearchDeluxeRoom(tempdeluxeList, placeholder);

                    if (placeholder != null)
                    {
                        if (secondStandardRoom != null)
                        {
                            StandardRoom room;
                            room = new StandardRoom(secondStandardRoom.roomNumber, secondStandardRoom.bedConfiguration, secondStandardRoom.dailyRate, secondStandardRoom.isAvail);
                            room.requireWifi = Convert.ToBoolean(stayContent[6].ToLower());
                            room.requireBreakfast = Convert.ToBoolean(stayContent[7].ToLower());
                            room.isAvail = !(Convert.ToBoolean(stayContent[2].ToLower()));
                            standardList.Add(room);
                            checkguest.hotelStay.AddRoom(room);
                        }

                        if (secondDeluxeRoom != null)
                        {
                            DeluxeRoom room;
                            room = new DeluxeRoom(secondDeluxeRoom.roomNumber, secondDeluxeRoom.bedConfiguration, secondDeluxeRoom.dailyRate, secondDeluxeRoom.isAvail);
                            room.additionalBed = Convert.ToBoolean(stayContent[12].ToLower());
                            room.isAvail = !(Convert.ToBoolean(stayContent[2].ToLower()));
                            deluxeList.Add(room);
                            checkguest.hotelStay.AddRoom(room);
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
    Console.WriteLine("7: Display monthly charged amounts and total charged amounts for the year");
    Console.WriteLine("8: Check-Out");
    Console.WriteLine("0: Exit");
    Console.WriteLine("+=====================================+");
}

//*********************************dispAllGuests()*********************************//
//Displays all guests                                                              // 
//Loops through the guestList                                                      //
//Print out the guest and its relevant information                                  //
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
//Prompt User for name and password                                                //
//Create new object for membership (Set status to Ordinary and Point to 0)         //
//With the new membership object create a new guest object                         //
//Append the new guest object into the guestList                                   //
//Write all the new guest detail into the guests.csv file                          //
//*********************************************************************************//
void registerGuest()
{
    Console.WriteLine("+================================Register Guest================================+");
    //Can copy paste your code here
    Console.Write("Enter your name: ");
    string name = Console.ReadLine();
    Console.Write("Enter your passport number: ");
    string passportNum = Console.ReadLine();
    Membership add_member = new Membership("Ordinary", 0);
    guestList.Add(new Guest(name, passportNum, null, add_member));

    Console.WriteLine("");

    string new_guesInfo = name + "," + passportNum + "," + "Ordinary" + "," + "0";
    using (StreamWriter sw = new StreamWriter("Guests.csv", true))
    {
        sw.WriteLine(new_guesInfo);
    }


    Console.WriteLine("Guest Registration Successful");
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
    checkInMoreRoom(); 

    void checkInMoreRoom()
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
                        checkInMoreRoom();
                    }

                    else if (moreRooms == "N")
                    {
                        guestList[selectedGuest].hotelStay = newStays;
                        guestList[selectedGuest].isCheckedin = true;
                        Console.WriteLine("+==========================+");
                        Console.WriteLine("+Successfully Checked in");
                        Console.WriteLine("+==========================+");
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
                        checkInMoreRoom();
                    }

                    else if (moreRooms == "N")
                    {
                        guestList[selectedGuest].hotelStay = newStays;
                        guestList[selectedGuest].isCheckedin = true;


                        Console.WriteLine("+==========================+");
                        Console.WriteLine("+Successfully Checked in");
                        Console.WriteLine("+==========================+");
                        return;
                    }

                }

            }
        }


    }
}
    

//*********************************dispGuestStay()*********************************//
//Displays all Guests Stay details                                                 //
//Prompt User for personl detail such as passport number                           //
//Search guest from the list. If guest is in the list loop through his/her roomList//
//Display the guest detail and room detail                                         //
//If guest roomList is empty will ask the guest to check in to a room              //
//*********************************************************************************//
void dispGuestStay()
{

    Guest SearchGuest(List<Guest> gList, string passportNum)
    {
        for (int i = 0; i < guestList.Count; i++)
        {
            Guest g = guestList[i];
            if (g.passportNum == passportNum)
            {
                return g;
            }
        }
        return null;
    }

    dispAllGuests();

    Console.WriteLine("+================================Guest Stay Details================================+");
    //Can copy paste your code here

    Console.WriteLine("");
    Console.Write("Please enter your passport number: ");
    string passportNo = Console.ReadLine();
    Guest findguest = SearchGuest(guestList, passportNo);
    if (findguest != null)
    {   
        if (findguest.hotelStay == null)
        {
            Console.WriteLine("You have not check in a room");
        }

        else
        {
            foreach (Room r in findguest.hotelStay.roomList)
            {

                if (r != null)
                {
                    if (r.dailyRate < 140)
                    {
                        StandardRoom standardRoom = (StandardRoom)r;
                        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", "Name", "Check In Date", "Check Out Date", "Room", "Wifi", "Breakfast");
                        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", findguest.Name, findguest.hotelStay.checkInDate.ToString("dd/MM/yyyy"), findguest.hotelStay.checkOutDate.ToString("dd/MM/yyyy"), standardRoom.roomNumber, standardRoom.requireWifi, standardRoom.requireBreakfast);
                        Console.WriteLine("");
                    }
                    else
                    {
                        DeluxeRoom deluxeRoom = (DeluxeRoom)r;
                        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "Name", "Check In Date", "Check Out Date", "Room", "Additional Bed");
                        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", findguest.Name, findguest.hotelStay.checkInDate.ToString("dd/MM/yyyy"), findguest.hotelStay.checkOutDate.ToString("dd/MM/yyyy"), deluxeRoom.roomNumber, deluxeRoom.additionalBed);
                        Console.WriteLine("");
                    }
                }
            } 
        }
    }
    else
    {
        Console.WriteLine("You have yet to register");
    }
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
// Loop through each guest roomList                                                  //
// Calculate the charge per day of the room                                          // 
// Caculate total charge for a guest by no of days * per day charge                  //
// Append the year, month, total charge into the total list                          //
// Loop through 12 times to display the total charges of every month                 //
// Month Charges is track the var name call monthlyPayment                           //
// Annual Charges is track the var name call yearPayment                             //
//***********************************************************************************//
void dispMonthCharge()
{
    Console.WriteLine("+================================Monthly Charge================================+");
    //Can copy paste your code here (if you havent gotten this one to work yet we can work on it tgt)
    Guest SearchGuest(List<Guest> gList, string passportNum)
    {
        for (int i = 0; i < gList.Count; i++)
        {
            Guest g = gList[i];
            if (g.passportNum == passportNum)
            {
                return g;
            }
        }
        return null;
    }



    Stays SearchYear(List<Stays> sList, int y)
    {
        for (int i = 0; i < sList.Count; i++)
        {
            Stays s = sList[i];
            if (s.checkOutDate.Year == y)
            {
                return s;
            }
        }
        return null;
    }

    

    string[] stayInfo = File.ReadAllLines("Stays.csv");
    List<double> total = new List<double>();


    for (int i = 1; i < stayInfo.Length; i++)
    {
        double roomCharge = 0;
        string[]? stayContent = stayInfo[i].Split(',');
        Guest guest = SearchGuest(guestList, stayContent[1]);
        List<Room> roomList = guest.hotelStay.roomList;

        double guestCharge = guest.hotelStay.CalculateTotal();
        Console.WriteLine("{0} {1}", guest.Name, guestCharge);
        total.Add(guest.hotelStay.checkOutDate.Year);
        total.Add(guest.hotelStay.checkOutDate.Month);
        total.Add(guestCharge);

    }




    Console.WriteLine("");
    Console.Write("Enter year: ");
    int year = Convert.ToInt32(Console.ReadLine());
    Stays findDate = SearchYear(stayList, year);
    DateTime dateTime = new DateTime(year, 01, 01);
    double monthlyPayment = 0;
    double yearPayment = 0;
    for (int i = 1; i <= 12; i++)
    {
        for (int j = 0; j < total.Count; j++)
        {
            if (dateTime.Year == total[j])
            {
                j++;
                if (dateTime.Month == total[j])
                {
                    j++;
                    monthlyPayment += total[j];

                }
                else
                {
                    j++;
                }
            }

        }
        Console.WriteLine("{0} {1}: ${2}", dateTime.ToString("MMM"), year.ToString(), monthlyPayment.ToString("0.00"));
        yearPayment += monthlyPayment;
        
        monthlyPayment = 0;


        dateTime = dateTime.AddMonths(1);
    }
    Console.WriteLine("");
    Console.WriteLine("Total: ${0}", yearPayment);

    total.Clear();

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

    double totalBill = guestList[selectedGuest].hotelStay.CalculateTotal();

    Console.WriteLine("Your Total Bill is: {0}",totalBill);
    Console.WriteLine("Membership: {0} Points: {1}", guestList[selectedGuest].Member.Status, guestList[selectedGuest].Member.Points);
    if(guestList[selectedGuest].Member.Status != "Ordinary")
    {
        Console.Write("Enter number of points would you like to use: ");
        int numPoints = Convert.ToInt32(Console.ReadLine());
        guestList[selectedGuest].Member.RedeemPoints(numPoints);
        totalBill -= numPoints;
        Console.WriteLine("Your Final Bill is {0}", totalBill);
        Console.WriteLine("You now have {0} points left in your account", guestList[selectedGuest].Member.Points);
    }

    else if (guestList[selectedGuest].Member.Status == "Ordinary")
    {
        Console.WriteLine("Sorry! Membership status is not eligible to redeem points");
    }

    Console.WriteLine("Press any key to make payment...");
    Console.ReadKey();
    guestList[selectedGuest].Member.EarnPoints(totalBill);
    Console.WriteLine("You have {0} points in your account",guestList[selectedGuest].Member.Points);

    if (guestList[selectedGuest].Member.Points >= 100)
    {
        guestList[selectedGuest].Member.Status = "Silver";
        Console.WriteLine("Congratulations! You have been upgraded to Silver membership status!");
    }

    else if (guestList[selectedGuest].Member.Points >= 200)
    {
        guestList[selectedGuest].Member.Status = "Gold";
        Console.WriteLine("Congratulations! You have been upgraded to Gold membership status!");
    }

    guestList[selectedGuest].isCheckedin = false;

    Console.WriteLine("+=======================================+");
    Console.WriteLine("+Successfully Checked Out");
    Console.WriteLine("+Thank you for choosing ICT Hotels!");
    Console.WriteLine("+We hope to serve you again!");
    Console.WriteLine("+=======================================+");



}

//*********************************Main()*****************************************//
//Calls all the functions of the program                                          //
//********************************************************************************//

void Main()
{
    InitRoomData();
    InitGuestData();
    InitStayData();
    AssignRoomAttributes();
    bool check = true;
    
    

    while (check == true)
    {
        dispMenu();
        Console.WriteLine("");
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
            dispGuestStay();
        }

        else if (opt == 6)
        {
            extendStay();
        }

        else if (opt == 7)
        {
            dispMonthCharge();
        }

        else if (opt == 8)
        {
            checkOutGuest();
        }

        else if (opt == 0)
        {
            Console.WriteLine("Goodbye!");
            check = false;
        }

    }


}

Main();