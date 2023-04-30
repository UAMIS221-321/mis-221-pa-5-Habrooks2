// See https://aka.ms/new-console-template for more information
using System;
   using PA5;

    int loop = 1; 
    while (loop != 0) {
        Console.WriteLine("Welcome to Train Like A Champion - Personal Fitness");
        Console.WriteLine("Would you like to:");
        Console.WriteLine("1) Manage Trainer Data");
        Console.WriteLine("2) Manage Listing Data");
        Console.WriteLine("3) Manage Customer Booking Data");
        Console.WriteLine("4) Run Report");
        Console.WriteLine("5) Exit");

        Trainer[] trainers = new Trainer[100];
        Listing[] listings = new Listing[100];
        Booking[] bookings = new Booking[100];
        Reporting[] reports = new Reporting[100];
      
        TrainerUtility tutility = new TrainerUtility(trainers);
        ListingUtility lutility = new ListingUtility(listings);
        BookingReports butility = new BookingReports(bookings);
        ReportReports rutility = new ReportReports(reports);
      

        int decision = int.Parse(Console.ReadLine());
        // Trainer Section
        if (decision == 1) {
             
            Console.WriteLine("Managing Trainer Data...");
            Console.WriteLine("Would you like to add, edit, or delete a trainer?");
            Console.WriteLine("To add, press 1. To edit, press 2. To delete, press 3.");

            int tDecision = int.Parse(Console.ReadLine());
            switch(tDecision) {
                case 1:
                    Console.WriteLine("Preparing addition of trainer...");
                    Console.WriteLine("We will generate an ID for you.");
                    Console.WriteLine("Enter the name:");
                    string tempName = Console.ReadLine();
                    Console.WriteLine("Enter the address:");
                    string tempAdrs = Console.ReadLine();
                    Console.WriteLine("Enter the email address:");
                    string tempEmadrs = Console.ReadLine();
                    bool check = IsAccurate(tempName,tempAdrs,tempEmadrs);
                    if (check = false) {
                        Console.WriteLine("Renter the information.");
                        Console.WriteLine("Enter the name:");
                        tempName = Console.ReadLine();
                        Console.WriteLine("Enter the address:");
                        tempAdrs = Console.ReadLine();
                        Console.WriteLine("Enter the email address:");
                        tempEmadrs = Console.ReadLine(); 
                    }
                    tutility.AddTrainer(tempName,tempAdrs,tempEmadrs);
                    loop = 1;
                break; 
    
                case 2:
                    Console.WriteLine("Preparing edit of trainer...");
                    Console.WriteLine("Enter the ID of trainer.");  
                    string temp = Console.ReadLine();
                    Console.WriteLine("Continuing edit...");
                    trainers = tutility.GetTrainers();
                    bool check4 = tutility.Exist(temp,trainers);
                    if (check4 = true){
                    tutility.EditTrainer(tutility.SearchTrainerID(temp, trainers));
                    }
                    else if (check4 = false) {
                        Console.WriteLine("The ID provided doesn't exist. Try Again.");
                    }
                break;

                case 3:
                    Console.WriteLine("Preparing removal of trainer...");
                    Console.WriteLine("Do you know the ID of the trainer?");
                    Console.WriteLine("Enter Y for yes or N for no.");
                    char choice3 = Char.Parse(Console.ReadLine());
                    char choice4 = Char.ToUpper(choice3); 
                    if (choice4 == 'Y'){
                        Console.WriteLine("Enter the ID.");
                        string temp2 = Console.ReadLine();
                        Console.WriteLine("Continuing removal...");
                        trainers = tutility.GetTrainers();
                        bool check5 = tutility.Exist(temp2,trainers);
                        if (check5 = true){
                            tutility.DeleteTrainer(tutility.SearchTrainerID(temp2,trainers));
                        }
                        else if (check5 = false) {
                            Console.WriteLine("The ID provided doesn't exist. Try Again.");
                        }
                        else Invalid(); 
                    }
                    else if (choice4 == 'N'){
                        Console.WriteLine("Do you the name of the trainer?");
                        char choice5 = Char.Parse(Console.ReadLine());
                        char choice6 = Char.ToUpper(choice5); 
                        if (choice6 == 'Y'){
                            Console.WriteLine("Enter the name.");
                            string tempname = Console.ReadLine();
                            Console.WriteLine("Continuing removal...");
                            trainers = tutility.GetTrainers();
                            bool check7 = tutility.ExistN(tempname,trainers);
                            if (check7 = true){
                            tutility.DeleteTrainer(tutility.SearchTrainerName(tempname, trainers));
                            }
                            else if (check7 = false) {
                                Console.WriteLine("The name provided doesn't exist. Try Again.");
                            }
                        }
                        else if(choice6 == 'N'){
                            Console.WriteLine("Find the name or ID of trainer.");
                        } 
                        else Invalid();
                    }
                    else Invalid();
                loop = 1;
                break;

                default:
                Invalid();
                break;
                
            }
        }
        // Listing Section
        else if (decision == 2) {
            Console.WriteLine("Managing Listing Data...");
            Console.WriteLine("Would you like to add, edit, or delete a listing?");
            Console.WriteLine("To add, press 1. To edit, press 2. To delete, press 3.");

            int lDecision = int.Parse(Console.ReadLine());
            switch(lDecision) {
                case 1:
                    Console.WriteLine("Preparing addition of listing...");
                    Console.WriteLine("We will generate an ID for you.");
                    Console.WriteLine("Enter the name:");
                    string tempName = Console.ReadLine();
                    Console.WriteLine("Enter the date in the format ##/##/##:");
                    string tempDate = Console.ReadLine();
                    Console.WriteLine("Enter the time in the format ##:##:");
                    string tempTime = Console.ReadLine();
                    Console.WriteLine("Enter the cost in the format ##.##:");
                    string tempCost = Console.ReadLine();
                    Console.WriteLine("Enter the taken status (yes for closed and no for open):");
                    string tempTaken = Console.ReadLine();
                    bool check8 = IsAccurateL(tempName,tempDate,tempTime,tempCost,tempTaken);
                    if (check8 = false) {
                        Console.WriteLine("Renter the information.");
                        Console.WriteLine("Enter the name:");
                        tempName = Console.ReadLine();
                        Console.WriteLine("Enter the date in the format ##/##/##:");
                        tempDate = Console.ReadLine();
                        Console.WriteLine("Enter the time in the format ##:##:");
                        tempTime = Console.ReadLine();
                        Console.WriteLine("Enter the cost in the format ##.##:");
                        tempCost = Console.ReadLine();
                        Console.WriteLine("Enter the taken status (yes for closed and no for open):");
                        tempTaken = Console.ReadLine();
                        }
                    lutility.AddListing(tempName,tempDate,tempTime,tempCost,tempTaken);
                    loop = 1;
                break; 
    
                case 2:
                    Console.WriteLine("Preparing edit of listing...");
                    Console.WriteLine("Enter the ID of listing.");  
                    string temp = Console.ReadLine();
                    Console.WriteLine("Continuing edit...");
                    listings = lutility.GetListings();
                    bool check9 = lutility.Exist(temp, listings);
                    if (check9 = true){
                    lutility.EditListing(lutility.SearchListingID(temp, listings));
                    }
                    else if (check9 = false) {
                        Console.WriteLine("The ID provided doesn't exist. Try Again.");
                    }
                break;

                case 3:
                    Console.WriteLine("Preparing removal of listing...");
                    Console.WriteLine("Do you know the ID of the listing?");
                    Console.WriteLine("Enter Y for yes or N for no.");
                    char choice9 = char.Parse(Console.ReadLine());
                    char choice10 = Char.ToUpper(choice9); 
                    if (choice10 == 'Y'){
                        Console.WriteLine("Enter the ID.");
                        string temp3 = Console.ReadLine();
                        Console.WriteLine("Continuing removal...");
                        listings = lutility.GetListings();
                        bool check11 = lutility.Exist(temp3,listings);
                        if (check11 = true){
                            lutility.DeleteListing(lutility.SearchListingID(temp3,listings));
                        }
                        else if (check11 = false) {
                            Console.WriteLine("The ID provided doesn't exist. Try Again.");
                        }
                        else Invalid(); 
                    }
                    else if (choice10 == 'N'){
                        Console.WriteLine("Do you the name of the trainer?");
                        char choice11 = Char.Parse(Console.ReadLine());
                        char choice12 = Char.ToUpper(choice11); 
                        if (choice12 == 'Y'){
                            Console.WriteLine("Enter the name.");
                            string tempname2 = Console.ReadLine();
                            Console.WriteLine("Continuing removal...");
                            listings = lutility.GetListings();
                            bool check14 = lutility.ExistN(tempname2,listings);
                            if (check14 = true){
                            lutility.DeleteListing(lutility.SearchListingName(tempname2,listings));
                            }
                            else if (check14 = false) {
                                Console.WriteLine("The name provided doesn't exist. Try Again.");
                            }
                        }
                        else if(choice12 == 'N'){
                            Console.WriteLine("Find the name or ID of trainer.");
                        } 
                        else Invalid();
                    }
                    else Invalid();
                loop = 1;
                break;

                default:
                Invalid();
                break;
                
            }
        }
        // Booking Section
        else if (decision == 3) {
            Console.WriteLine("Viewing Booking Data...");
            Console.WriteLine("Would you like to view available sessions, book a session, cancel a session, or report a no show ?");
            Console.WriteLine("To view, press 1. To book, press 2. To cancel, press 3. To report, press 4.");

            int bDecision = int.Parse(Console.ReadLine()); 
            if (bDecision == 1){
                    listings = lutility.GetListings();
                 lutility.ViewListing(listings);
            }
            else if (bDecision == 2){
                bookings = butility.GetBookings();
                butility.BookSession(bookings);
            }
            else if (bDecision == 3){
                Console.WriteLine("If you've completed, simply enter your name:");
                string compName = Console.ReadLine();
                bookings = butility.GetBookings();
                butility.CancelONoShow(compName,bookings);
            }
            else if (bDecision == 4){
                Console.WriteLine("To report a no show, or cancel your session, enter the person's name:");
                string noShowName = Console.ReadLine();
                bookings = butility.GetBookings();
                butility.CancelONoShow(noShowName,bookings);
            }
            else {Invalid();}
        }
        // Report Section
        else if (decision == 4) {
            Console.WriteLine("Loading Report Data...");
            Console.WriteLine("Would you like to view individual customer sessions, historical customer sessions, or historical revenue?");
            Console.WriteLine("For individual, press 1. For historical, press 2. For revenue, press 3.");

            int rDecision = int.Parse(Console.ReadLine()); 
            
            if (rDecision == 1) {
                Console.WriteLine("Enter email address to view previous sessions.");
                string addressEntered = Console.ReadLine();
                reports = rutility.GetReportTrans();
                rutility.FindSessions(addressEntered,reports);
            }

            else if (rDecision == 2) {
                Console.WriteLine("Loading all customer information...");
                listings = lutility.GetListings();
                lutility.GetSessionInfo(listings);

            }

            else if (rDecision == 3) {
                Console.WriteLine("Loading revenue information...");
                listings = lutility.GetListings();
                lutility.GetRevenue(listings);
            }

            else {Invalid();}
        }
        // To Exit
        else if (decision == 5) {
            Console.WriteLine("Have a great day.");
            loop = 0;
        }
        // Invalid Option
        else {
            Invalid();
        }

        static void Invalid() {
        Console.WriteLine("This option is invalid. Try again.");
        }

        static bool IsAccurate(string nam, string addy, string emaddy){
            Console.WriteLine("Is this information accurate?");
            Console.WriteLine("{0}; {1}; {2}", nam, addy, emaddy);
            Console.WriteLine("Enter Y for yes or N for no.");
            char choice = char.Parse(Console.ReadLine());
            char choice2 = Char.ToUpper(choice);
            if (choice2 == 'Y') {
                Console.WriteLine("Let's continue");
                return true;
            }
            else if (choice2 == 'N'){
                Console.WriteLine("Returning.");
                return false;

            }
            else {
                Invalid();
                return false;
            }
            
        }

        static bool IsAccurateL(string nam, string date, string time, string cost, string taken){
            Console.WriteLine("Is this information accurate?");
            Console.WriteLine("{0}; {1}; {2}; {3}; {4}", nam, date, time, cost, taken);
            Console.WriteLine("Enter Y for yes or N for no.");
            char choice = char.Parse(Console.ReadLine());
            char choice2 = Char.ToUpper(choice);
            if (choice2 == 'Y') {
                Console.WriteLine("Let's continue");
                return true;
            }
            else if (choice2 == 'N'){
                Console.WriteLine("Returning.");
                return false;

            }
            else {
                Invalid();
                return false;
            }
            
        }

    }
    