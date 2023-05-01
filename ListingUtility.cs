using System; 
namespace PA5 {
    public class ListingUtility{

        private Listing[] listings;
        //private static int count;

        public ListingUtility(Listing[] listings){
            this.listings = listings;
        } 
        // Gets information from listings.txt 
        public Listing[] GetListings()
        {
            Listing[] listings = new Listing[100];
            string[] arrLine = File.ReadAllLines("listings.txt");
            int size = arrLine.Length; 
            StreamReader inFile = new StreamReader("listings.txt");
            int count = 0;
            string dataRow = inFile.ReadLine();
            for (int i = 0; i < size; i++){
                string[] tempData = dataRow.Split("#");
                listings[count] = new Listing(tempData[0], tempData[1], tempData[2], tempData[3], tempData[4], tempData[5]);
                //dataRow = inFile.ReadLine();
                count++;
                dataRow = inFile.ReadLine();
                }
                Listing.SetCount(count);
                inFile.Close();
                return listings;
        }
        // Shows revenue by year and month
        public void GetRevenue(Listing[] listings){
           
            Sort(listings);
            double sum = 0;
            int year = 0;
            for (int i = 0; i < Listing.GetCount(); i++){
                
                if (DateTime.Parse(listings[i].GetDate()).Year == DateTime.Parse(listings[i+1].GetDate()).Year){
                    sum =+ double.Parse(listings[i].GetCost());
                }
                Console.WriteLine("Total revenue for the year is ${}.", sum);
            }

            Console.WriteLine("Would you like to save this report?");
            char answer = Char.Parse(Console.ReadLine());
            char answer2 = Char.ToUpper(answer);
            if (answer2 == 'Y'){
                Console.WriteLine("Enter password to save report:");
                string password = "project5";
                string scan = Console.ReadLine();
                if (scan == password){
                    Console.WriteLine("What filename would you like to save to? Remember to include .txt");
                    string name = Console.ReadLine();

                    StreamWriter toFile = new StreamWriter(name);
                    Sort(listings);
                    sum = 0;
                    year = 0;
                    for (int i = 0; i < Listing.GetCount(); i++){
                        
                        if (DateTime.Parse(listings[i].GetDate()).Year == DateTime.Parse(listings[i+1].GetDate()).Year){
                            sum =+ double.Parse(listings[i].GetCost());
                        }
                        toFile.WriteLine("Total revenue for the year is ${}.", sum);
                    }                    
                    toFile.Close();
                    Console.WriteLine("File creation complete!");

                }
                else {Console.WriteLine("Incorrect Password..");}

            }
            else {Console.WriteLine("Returning to Menu.");}

        }
        // Reports total sessions by customer and date
        public void GetSessionInfo(Listing[] listings){
            SortC(listings);
            int sum = 0;
            for (int i = 0; i < Listing.GetCount(); i++){
                Console.WriteLine("{0}", listings[i].GetListingName());
                if (listings[i].GetListingName() == listings[i+1].GetListingName()){
                    sum++;
                    Console.WriteLine("Session at {0}", listings[i].GetDate());
                }
                Console.WriteLine("Total Sessions = {0}", sum);
            }
            
            Console.WriteLine("Would you like to save this report?");
            char answer = Char.Parse(Console.ReadLine());
            char answer2 = char.ToUpper(answer);
            if (answer2 == 'Y'){
                Console.WriteLine("Enter password to save report:");
                string password = "project5";
                string scan = Console.ReadLine();
                if (scan == password){
                    Console.WriteLine("What filename would you like to save to? Remember to include .txt");
                    string name = Console.ReadLine();

                    StreamWriter toFile = new StreamWriter(name);
                    SortC(listings);
                    sum = 0;
                    for (int i = 0; i < Listing.GetCount(); i++){
                        toFile.WriteLine("{0}", listings[i].GetListingName());
                        if (listings[i].GetListingName() == listings[i+1].GetListingName()){
                            sum++;
                            toFile.WriteLine("Session at {0}", listings[i].GetDate());
                        }
                        toFile.WriteLine("Total Sessions = {0}", sum);
                    }
            
                    toFile.Close();
                    Console.WriteLine("File creation complete!");

                }
                else {Console.WriteLine("Incorrect Password..");}

            }
            else {Console.WriteLine("Returning to Menu.");}



        }
        // Add a listing
        public void AddListing(string nValue, string dValue, string tValue, string cValue, string taValue){
                Random rnd = new Random();
                int generate = rnd.Next(10000,99999);
                string generate2 = generate.ToString();
                StreamWriter inListing = File.AppendText("listings.txt");
                inListing.WriteLine("{0}#{1}#{2}#{3}#{4}#{5}", generate2, nValue, dValue, tValue, cValue, taValue);
                inListing.Close();
        }
        /// Delete a listing
        public void DeleteListing(int search){
            StreamReader readFile = new StreamReader("listings.txt");
            StreamWriter tempFile = new StreamWriter("listings2.txt");
            string[] arrLine = File.ReadAllLines("listings.txt");
            string toDelete = arrLine[search];
            int i = 0;
            while (arrLine[i] != toDelete){
                tempFile.WriteLine(arrLine[i]);
                i++;
            }
            readFile.Close();
            File.Delete("listings.txt");
            File.Move("listings2.txt", "listings.txt");
            tempFile.Close();
            File.Delete("listings2.txt");
        }
        // Edit a listing
        public void EditListing(int search){
                StreamWriter inFile = new StreamWriter("listings2.txt");
                //int lineVal = search - 1;

                Console.WriteLine("What would you like to edit?");
                Console.WriteLine("Enter 1 to edit name, Enter 2 to edit the date, Enter 3 to edit the time, Enter 4 to edit the cost, or Enter 5 to edit the taken status.");
                int what = int.Parse(Console.ReadLine());
                if (what == 1) {
                    Console.WriteLine("What would you like to edit the name to?");
                    string replaceN = Console.ReadLine();
                    
                    Console.WriteLine("Editing name...");
                    string[] arrLine = File.ReadAllLines("listings.txt");
                    string[] change = arrLine[search].Split("#");
                    string temp = change[0] + "#" + replaceN + "#" + change[2] + "#" + change[3] + "#" + change[4] + "#" + change[5];
                    arrLine[search] = temp;

                    File.WriteAllLines("listings2.txt", arrLine);
                    //readFile.Close();
                    File.Delete("listings.txt");
                    File.Move("listings2.txt","listings.txt");
                    File.Delete("listings2.txt");
                    inFile.Close();

                    Console.WriteLine("Done!");
                }
                else if (what == 2) {
                    Console.WriteLine("What would you like to edit the date to? Enter in the following format: ##/##/## ");
                    string replaceA = Console.ReadLine();

                    string[] arrLine = File.ReadAllLines("listings2.txt");
                    string[] change = arrLine[search].Split("#");
                    string temp = change[0] + "#" + change[1] + "#" + replaceA + "#" + change[3] + "#" + change[4] + "#" + change[5];
                    arrLine[search] = temp;

                    File.WriteAllLines("listings2.txt", arrLine);
                    //readFile.Close();
                    File.Delete("listings.txt");
                    File.Move("listings2.txt","listings.txt");
                    File.Delete("listings2.txt");
                    inFile.Close();


                    Console.WriteLine("Done!");
                }
                else if (what == 3) {
                    Console.WriteLine("What would you like to edit the time to? Enter in the following format: ##:##");
                    string replaceE = Console.ReadLine();

                    string[] arrLine = File.ReadAllLines("listings.txt");
                    string[] change = arrLine[search].Split("#");
                    string temp = change[0] + "#" + change[1] + "#" + change[2] + "#" + replaceE + "#" + change[4] + "#" + change[5];
                    arrLine[search] = temp;

                    File.WriteAllLines("listings2.txt", arrLine);
                    //readFile.Close();
                    File.Delete("listings.txt");
                    File.Move("listings2.txt","listings.txt");
                    File.Delete("listings2.txt");
                    inFile.Close();


                    Console.WriteLine("Done!");
                }
                else if (what == 4) {
                    Console.WriteLine("What would you like to edit the cost to? Enter in the following format: ##.##");
                    string replaceC = Console.ReadLine();

                    string[] arrLine = File.ReadAllLines("listings.txt");
                    string[] change = arrLine[search].Split("#");
                    string temp = change[0] + "#" + change[1] + "#" + change[2] + "#" + change[3] + "#" + replaceC + "#" + change[5];
                    arrLine[search] = temp;

                    File.WriteAllLines("listings2.txt", arrLine);
                    //readFile.Close();
                    File.Delete("listings.txt");
                    File.Move("listings2.txt","listings.txt");
                    File.Delete("listings2.txt");
                    inFile.Close();


                    Console.WriteLine("Done!");
                }
                else if (what == 5) {
                    Console.WriteLine("What would you like to edit the taken status to? Enter yes for closed and no for open.");
                    string replaceT = Console.ReadLine();

                    string[] arrLine = File.ReadAllLines("listings.txt");
                    string[] change = arrLine[search].Split("#");
                    string temp = change[0] + "#" + change[1] + "#" + change[2] + "#" + change[3] + "#" + change[4] + "#" + replaceT;
                    arrLine[search] = temp;

                    File.WriteAllLines("listings2.txt", arrLine);
                    //readFile.Close();
                    File.Delete("listings.txt");
                    File.Move("listings2.txt","listings.txt");
                    File.Delete("listings2.txt");
                    inFile.Close();


                    Console.WriteLine("Done!");
                }
                else {Console.WriteLine("Invalid. Try Again.");}
        }
        // Shows available listings and available listings by name or date if need
        public void ViewListing(Listing[] listings){
            Console.WriteLine("Would you rather view all open sessions or open sessions for a specific trainer?");
            Console.WriteLine("Enter 1 for all and 2 for specific trainer.");
            int what = int.Parse(Console.ReadLine());
            //GetListings();
            if (what == 1){
                Console.WriteLine("The following sessions are open:");
                //GetListings();
                for (int i = 0; i < Listing.GetCount(); i++){
                if (listings[i].GetListingTaken() == "no") {
                    Console.WriteLine("Session {0} on {1}.", listings[i].GetListingID(), listings[i].GetDate());
                }
            } 
            }
            else if (what == 2) {
                Console.WriteLine("What is the name of the trainer you would like?");
                string sessionName = Console.ReadLine();
                Console.WriteLine("The following sessions are open:"); 
                //GetListings();
                for (int i = 0; i < Listing.GetCount(); i++){
                    if (listings[i].GetListingName() == sessionName){
                        if (listings[i].GetListingTaken() == "no"){
                            Console.WriteLine("{0}'s session on {1}.", sessionName, listings[i].GetDate());
                        } 
                    }
                }

            }
            else {Console.WriteLine("Invalid Option. Try Again.");}
        }
        // Searches for index for a listing by ID
        public int SearchListingID(string tempi, Listing[] listings){
                int lineNumber = 0;
                    for (int i = 0; i < Listing.GetCount(); i++){
                        if(listings[i].GetListingID() == tempi) {
                            lineNumber = i;
                        }
                    }
                return lineNumber;
        }
        // Searches for index for a trainer by name
        public int SearchListingName(string tempn, Listing[] listings){
                int lineNumber = 0;
                    for (int i = 0; i < Listing.GetCount(); i++){
                        if(listings[i].GetListingName() == tempn) {
                            lineNumber = i;
                        }
                    }
                return lineNumber;
        }
        // Sees if trainer exists (by id)
        public bool Exist(string tempi,Listing[] listings){
                bool see = false;
                for (int i = 0; i < Listing.GetCount(); i ++){
                    if (listings[i].GetListingID() == tempi){
                        see = true;
                    }
                    else {see = false;}
                } 
                return see;
        }
        // Sees if trainer exists (by name)
        public bool ExistN(string temp, Listing[] listings){
                bool see = false;
                for (int i = 0; i < Listing.GetCount(); i ++){
                    if (listings[i].GetListingName() == temp){
                        see = true;
                    }
                    else {see = false;}
                } 
                return see;
        }
        // Asks operator if the info scanned is accurate
        public bool IsAccurateOne(string info){
                Console.WriteLine("Is this information accurate?");
                Console.WriteLine("{0}", info);
                Console.WriteLine("Enter Y for yes or N for no.");
                char choice = char.Parse(Console.ReadLine());
                char choice2 = Char.ToUpper(choice);
                if (choice == 'Y') {
                    Console.WriteLine("Let's continue");
                    return true;
                }
                else if (choice == 'N'){
                    Console.WriteLine("Returning.");
                    return false;

                }
                else {
                    Console.WriteLine("This option is invalid. Try again.");
                    return false;
                }
                
        }
        
        // Sorts listings by Date
        public void Sort(Listing[] listings){
                var n = listings.Length;
                for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                if (DateTime.Parse(listings[j+1].GetDate()) < DateTime.Parse(listings[j].GetDate()))
                {
                    var tempVar = listings[j];
                    listings[j] = listings[j+1];
                    listings[j+1] = tempVar;
                }
        }
        // Sorts listings by Customer
        public void SortC(Listing[] listings){
                var n = listings.Length;
                for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                if (DateTime.Parse(listings[j+1].GetListingName()) < DateTime.Parse(listings[j].GetListingName()))
                {
                    var tempVar = listings[j];
                    listings[j] = listings[j+1];
                    listings[j+1] = tempVar;
                }
            }
    }   
}