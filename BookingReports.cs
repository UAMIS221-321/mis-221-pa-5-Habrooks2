using System;
namespace PA5 {

    public class BookingReports {
        private Booking[] bookings;
        //private static int count;
        
        public BookingReports(Booking[] bookings) {
            this.bookings = bookings;
        }
        // Allows operator to book a session
        public void BookSession(Booking[] bookings){
            Console.WriteLine("Loading Booking Site...");
            Console.WriteLine("Booking session are the same as listing sessions.");
            Console.WriteLine("What is the listing ID?");
            string sessionID = Console.ReadLine();
           
                Console.WriteLine("Enter your name:");
                string sessionPersonName = Console.ReadLine();
                Console.WriteLine("Enter your email address:");
                string eAddress = Console.ReadLine();
                Console.WriteLine("Enter the session date:");
                string date = Console.ReadLine();
                Console.WriteLine("Enter your trainer's id:");
                string trainID = Console.ReadLine();
                Console.WriteLine("Enter the trainer's name:");
                string name = Console.ReadLine();

                Console.WriteLine("One second to confirm.");

                for (int i = 0; i < Booking.GetCount(); i++){
                    if(bookings[i].GetTDate() == date){
                        if (bookings[i].GetID() == trainID){
                            if (bookings[i].GetTName() == name){
                                Console.WriteLine("Confirmed. Let's Continue!!");
                                    string takenInsert = "yes";
                                    StreamWriter inFile = File.AppendText("transactions.txt");
                                    inFile.WriteLine("{0}#{1}#{2}#{3}#{4}#{5}#{6}",sessionID, sessionPersonName, eAddress, date,trainID,name,takenInsert);
                                    inFile.Close();
                                    Console.WriteLine("Your session has been booked!!");
                            }
                            else {Console.WriteLine("Incorrec. Please reenter information.");}
                        }
                        else {Console.WriteLine("Incorrec. Please reenter information.");}
                    }
                    else {Console.WriteLine("Incorrec. Please reenter information.");}

                }
        }
        // Notifies transaction when operator cancels or reports a no show
        public void CancelONoShow(string name, Booking[] bookings){
                string closed = "no";
         
                StreamWriter inFile = new StreamWriter("transactions2.txt");
                string[] readLi = File.ReadAllLines("transactions.txt");
                int search = SearchBookingN(name,bookings);
                string[] changeIt = readLi[search].Split("#");
                string temp = changeIt[0] + "#" + changeIt[1] + "#" + changeIt[2] + "#" + changeIt[3] + "#" + changeIt[4] + "#" + changeIt[5] + "#" + closed;
                readLi[search] = temp;

                File.WriteAllLines("transactions2.txt", readLi);
                //readFile.Close();
                File.Delete("transactions.txt");
                File.Move("transactions2.txt","transactions.txt");
                File.Delete("transactions2.txt");
                inFile.Close();
            Console.WriteLine("We've made note in the system.. Thank you.");
        }
        //Searches booking by name
        public int SearchBookingN(string tempNn, Booking[] bookings){
            int lineNumber = 0;
                for (int i = 0; i < Booking.GetCount(); i++){
                    if(bookings[i].GetName() == tempNn) {
                        lineNumber = i;
                    }
                }
            return lineNumber;
        }
        // Gets information from transactions.txt
        public Booking[] GetBookings(){
            Booking[] bookings = new Booking[50];
            StreamReader inFile = new StreamReader("transactions.txt");
             string[] arrLine = File.ReadAllLines("transactions.txt");
            int size = arrLine.Length; 
            int count = 0;
            string dataRow = inFile.ReadLine();
             for (int i = 0; i < size; i++){
                string[] tempData = dataRow.Split("#");
                //int tempID = int.Parse(tempData[0]);
                bookings[count] = new Booking(tempData[0], tempData[1], tempData[2], tempData[3], tempData[4], tempData[5], tempData[6]);

                //dataRow = inFile.ReadLine();
                count++;
                dataRow = inFile.ReadLine();
            }
            Booking.SetCount(count);
            inFile.Close();
            return bookings;

        }
       
    }
}