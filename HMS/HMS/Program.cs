using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    class Hotel
    {
        private Room[] rooms;
        private Customer[] customers;
        private int num;
        private static int cusNo;
        private bool[] cusIn;

        public Hotel(int n)
        {
            cusNo = 0;
            num = n;
            rooms = new Room[num];
            customers = new Customer[num];
            cusIn=new bool[num];
            for (int i = 0; i < num; i++)
            {
                rooms[i] = new Room();
                customers[i] = new Customer();
                cusIn[i] = false;
            }
        }
        public void listAllRoom()
        {
            Console.WriteLine("Room#\tPrice\tType\tStatus");
            for (int i = 0; i < num;i++)
            {
                if(rooms[i].isVecant())
                    Console.WriteLine("{0}\t{1}\t{2}\tVecant",i,rooms[i].price,rooms[i].type);
                else
                    Console.WriteLine("{0}\t{1}\t{2}\tNot Vecant",i,rooms[i].price,rooms[i].type);
            }
        }
        public void listAvailableRoom()
        {
            Console.WriteLine("Room#\tPrice\tType\tStatus");
            for (int i = 0; i < num; i++)
            {
                if (rooms[i].isVecant())
                    Console.WriteLine("{0}\t{1}\t{2}\tVecant", i, rooms[i].price, rooms[i].type);
            }
 
        }

        public void booking()
        {
            Console.Write("Enter your name :\t");
            string name=Console.ReadLine();

            Console.Write("Enter your CNIC :\t");
            string cnic = Console.ReadLine();

            Console.Write("Enter your Gender :\t");
            string gender = Console.ReadLine();


            Console.Write("Enter your Contact# :\t");
            string con = Console.ReadLine();

            Console.Write("Please enter a date like yyyy-mm-dd:\t");
            DateTime time = DateTime.Parse(Console.ReadLine());


            Console.Write("Enter your room No:\t");
            string romS = Console.ReadLine();
            int rom = Int32.Parse(romS);

            customers[cusNo].name = name;
            customers[cusNo].CNIC = cnic;
            customers[cusNo].contact = con;
            customers[cusNo].date = time;
            customers[cusNo].gender = gender;
            customers[cusNo].roomNo = rom;
            cusIn[cusNo] = true;
            rooms[rom].status = false;
            cusNo++;


        }
        public void custReside()
        {
            Console.WriteLine("Name\tCNIC\tGender\tContact#\tCheckInDate\troom#");
            for (int i = 0; i < cusNo;i++ )
            {
                if (cusIn[i])
                {
                    
                    Console.WriteLine(customers[i].name + "\t" + customers[i].CNIC + "\t" + customers[i].gender + "\t" + customers[i].contact + "\t\t" + customers[i].date.Year + "/" + customers[i].date.Month + "/" + customers[i].date.Day + "\t" + customers[i].roomNo.ToString());
 
                }
            }
        }

        public int searchByCNIC(string cnic)
        {
            int cusN = -1;
            for (int i = 0; i < cusNo; i++)
            {
                if (cusIn[i])
                {
                    if (cnic.Equals(customers[i].CNIC))
                    {
                        printCustDetail(i);
                        cusN = i;
                    }
                }
            }
            return cusN;
        }
        public int searchByroomNo(int rm)
        {
            int cusN = -1;
            for (int i = 0; i < cusNo; i++)
            {
                if (cusIn[i])
                {
                    if (customers[i].roomNo == rm)
                    {
                        printCustDetail(i);
                        cusN = i;
                    }
                }
            }
            return cusN;
        }

        public void checkOut(int num)
        {
            cusIn[num] = false;
            Console.Write("Please enter a checkout date like yyyy-mm-dd:\t");
            DateTime time = DateTime.Parse(Console.ReadLine());
            int day = Int32.Parse(time.Subtract(customers[num].date).Days.ToString());
            rooms[customers[num].roomNo].status = true;
            Console.WriteLine("Thanks for Visiting us Hope you enjoy\nYou spand {0} days\nYour total bill is {1}",day,day*rooms[customers[num].roomNo].price);

 
        }

        private void printCustDetail(int i)
        {
            Console.WriteLine("Name\tCNIC\tGender\tContact#\tCheckInDate\troom#");
            Console.WriteLine(customers[i].name + "\t" + customers[i].CNIC + "\t" + customers[i].gender + "\t" + customers[i].contact + "\t\t" + customers[i].date.Year + "/" + customers[i].date.Month + "/" + customers[i].date.Day + "\t" + customers[i].roomNo.ToString());
        }

        public void setRoom(Room room,int i)
        {
            rooms[i] = room;
        }
        public static void Main(string[] args)
        {
            string hotelName = "default";
            int num = 0;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("-n"))
                {
                    hotelName = args[i + 1];
 
                }
                if (args[i].Contains("-a"))
                {
                    num = Int32.Parse(args[i + 1]);
                }
 
            }
            Room room;
            Hotel hotel = new Hotel(num);
            for (int i = 0; i < num; i++)
            {
                room = new Room();
                if (i % 4 == 0)
                {
                    room.price = 1100;
                    room.type = "Luxury";
                    room.status = true;
                }
                else
                {
                    room.price = 500;
                    room.type = "Reqular";
                    room.status = true;
                }
                hotel.setRoom(room, i);

            }
            int next = 1;
            while (next>0)
            {
                Console.WriteLine("WelCome to {0} Hotel\nWe have {1} rooms with high service", hotelName, num);
                Console.WriteLine("####################################");
                Console.WriteLine("For list all Rooms hit:\t\t1\nFor list of avaible room hit:\t2\nFor booking hit:\t\t3");
                Console.WriteLine("For Searching Customer hit:\t4\nFor Checkout hit:\t\t5\nFor Customer residing in Hotel:\t6");
                int n = Int32.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        hotel.listAllRoom();
                        break;
                    case 2:
                        hotel.listAvailableRoom();
                        break;
                    case 3:
                        hotel.booking();
                        break;
                    case 4:
                        hotel.searching();
                        break;
                    case 5:
                        hotel.checkOut();
                        break;
                    case 6:
                        hotel.custReside();
                        break;
                }
                Console.WriteLine("For exit hit:\t\t\t0\nFor next operation hit:\t\t1");
                next = Int32.Parse(Console.ReadLine());
                Console.Clear();
            }
            hotel.listAllRoom();
            hotel.booking();
            hotel.booking();
            hotel.custReside();
            Console.Read();

        }

        private void checkOut()
        {
            Console.WriteLine("Please enter the CNIC");
            string str = Console.ReadLine();
            int a=searchByCNIC(str);
            checkOut(a);
        }

        private void searching()
        {
            Console.WriteLine("For searching by CNIC hit:\t1\nFor seaching by RoomNo hit:\t2\n");
            int num = Int32.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine("Please enter the CNIC");
                    string str = Console.ReadLine();
                    searchByCNIC(str);
                    break;
                case 2:
                    Console.WriteLine("Please enter the room#");
                    int nu =Int32.Parse(Console.ReadLine());
                    searchByroomNo(nu);
                    break;
            }
        }
       
    }
    class Room
    {
        private double _price;
        private string _type;
        private bool _status;

        public double price
        {
            set
            {
                _price = value;
            }
            get
            {
                return _price;
            }
        }
        public string type
        {
            get
            {
                return _type;
            }
            set 
            {
                _type = value;
            }
        }
        public bool status
        {
            set
            {
                _status = value;
            }
        }

        public bool isVecant()
        {
            return _status;
        }
    }

    class Customer
    {
        private string _name;
        private string _CNIC;
        private string _gender;
        private string _contact;
        private DateTime _date;
        private int _roomNo;

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string CNIC
        {
            get
            {
                return _CNIC;
            }
            set
            {
                _CNIC = value;
            }
        }
        public string gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
        public string contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
            }
        }
        public DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        public int roomNo
        {
            get
            {
                return _roomNo;
            }
            set
            {
                _roomNo = value;
            }
        }
    }
}
