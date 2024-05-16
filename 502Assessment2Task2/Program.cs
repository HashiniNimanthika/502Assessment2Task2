using System;
using System.IO;
using System.Linq.Expressions;
namespace LanghamHotelManagementSystemSystem
{

 //Custom class- room

    public class Room
    {
        public int RoomNumberI;
        public bool IsAllocated;
    }

    //custom class-Customer
    public class Customer 
    {
        public string CustomerName;
    }

    //Custom class RoomAllocations
    public class Roomallocations
    {
        public int allocatedRoomNumber;
        public string AllocatedCustomer;
    }
    class Programme
    {
        public static Room[] ListOfRooms;
        public static int[] ListOfRoomAllocations;
        public static string filePath;

        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\hashi\source\lhms.764705995.txt";
            string fileName = "lhms.764705995.txt";
            filePath = Path.Combine(folderPath, fileName);

            bool running = true;
            char answer;

            do
            {
                Console.Clear();
                Console.WriteLine("************************************************************************************************************************");
                Console.WriteLine("                                              LANGHAM HOTEL MANAGEMENT SYSTEM                                 ");
                Console.WriteLine("                                                       MENU                                  ");
                Console.WriteLine("************************************************************************************************************************");

                Console.WriteLine("1. Add Rooms");
                Console.WriteLine("2. Display Rooms");
                Console.WriteLine("3. Allocate Rooms");
                Console.WriteLine("4. DeAllocate Rooms");
                Console.WriteLine("5. Display Room Allocations Details");
                Console.WriteLine("6. Billing");
                Console.WriteLine("7. Save The Room Allocation to a File ");
                Console.WriteLine("8. Show the Room Allocation From a File");
                Console.WriteLine("9. Exit");
                Console.WriteLine("10.Backup");
                Console.WriteLine("************************************************************************************************************************");
                Console.Write("Enter your Choice number here: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddRooms(); break;
                    case 2: DisplayRooms(); break;
                    case 3: AllocateRooms(); break;
                    case 4: DeAllocateRooms(); break;
                    case 5: DisplayRoomAllocationDetails(); break;
                    case 6: Billing(); break;
                    case 7: SaveTheRoomAllocationToAFile(); break;
                    case 8: ShowTheRoomAllocationFromAFile(); break;
                    case 9: Exit(); break;
                    case 10: BackUp(); break;
                    default: Console.WriteLine("Invalid Input"); break;
                }
                Console.WriteLine(" Would you like to continue(Y or N)");
                answer = Convert.ToChar(Console.ReadLine());
            }
            while (answer == 'Y' || answer == 'y'); Console.Clear();

        }
            static void AddRooms()
            {
                try
                {
                    Console.WriteLine("Add rooms");
                    Console.Write("Please Enter total number of rooms in the hotel: ");
                    int totalRooms = Convert.ToInt32(Console.ReadLine());
                    ListOfRooms = new Room[totalRooms];
                   
                    for (int i = 0; i <totalRooms; i++) 
                    {

                        Console.Write("Please Enter the room number for room " +( i+1)+"  :" );
                        int roomNumberI= Convert.ToInt32(Console.ReadLine());
                         ListOfRooms[i] = new Room() { RoomNumberI = roomNumberI };
                        Console.WriteLine($"Room {roomNumberI} has been successfully added");
                        
                    }
                    if (!int.TryParse(Console.ReadLine(),out int roomNumber)) { Console.WriteLine("Unhandeled exception: Input was not in correct format"); }
                }
                catch (Exception ex) { Console.WriteLine("Unhandled exception : "  +ex.GetType().FullName+  ":" + ex.Message); }
            }

        static void DisplayRooms()
        {
            Console.WriteLine("Display Rooms");
            foreach (var room in ListOfRooms)
            {
                Console.WriteLine($"Room Number: {room.RoomNumberI}");
            }

            Console.ReadLine();
        }  


        static void AllocateRooms() 
        {
            Console.Write("Enter the room number to allocate: ");
            int roomNumber= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter your your name :");
            string customerName= Console.ReadLine();
            Console.WriteLine($"Room Number {roomNumber} successfully allocated to {customerName}.");    
        }
        static void DeAllocateRooms() 
        {
            try
            {
                Console.Write("Enter the room number for De-Allocate:");
                int roomNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Enter Customer name : ");
                string customerName = Console.ReadLine();
                Console.WriteLine($"Room number {roomNumber} De-Allocated from {customerName}");
                Console.WriteLine($"Room Number{roomNumber} is now empty.");
            }
            catch (InvalidOperationException ex) { Console.WriteLine( ex.Message); }    
        }
       
        static void DisplayRoomAllocationDetails() 
        { 
            Console.WriteLine("Display Room allocation Details");
            foreach(var room in ListOfRooms) 
            {
                Console.WriteLine($"Room Number: {room.RoomNumberI}| allocated: {(room.IsAllocated? "yes" : "no")}");
            }
        }
        static void Billing()
        { 
         Console.WriteLine("Billing Features is under construction and will be added soon....!");
        }
        static void SaveTheRoomAllocationToAFile()
        {
            try
            {
                string filePath = @"C:\Users\hashi\source\lhms.764705995.txt";


                using (StreamWriter sw = new StreamWriter(filePath))
                {


                    foreach (var room in ListOfRooms)
                    {
                        sw.WriteLine($"RoomNumber: {room.RoomNumberI}, Allocated:{(room.IsAllocated ? "Yes" : "No")}");

                    }
                }
                  Console.WriteLine("Room Allocation have been saved to file." + filePath);
            }
            catch (UnauthorizedAccessException ex ) { Console.WriteLine("Unauthorized Access Exception: " + ex.Message);}
        }

        static void ShowTheRoomAllocationFromAFile() 
        {
            try
            {
                if (!File.Exists(filePath)) { throw new FileNotFoundException($"could not find file'{filePath}'"); }
                else
                {


                    string[] Lines = File.ReadAllLines(filePath);
                    Console.WriteLine("Room allocations from file");
                    foreach (string line in Lines) { Console.WriteLine(line); }
                }
            }
            catch(FileNotFoundException ex)
            { Console.WriteLine(ex.Message);}
        }
        static void Exit() 
        {
            Console.WriteLine("You are successfully exiting");
            Environment.Exit(0);
        }
            static void BackUp() { }
            




        






    }











































}