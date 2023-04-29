using System;
namespace PA5 {

    public class ReportReports {
        private Reporting[] reports;
        //private static int count;
        
        public ReportReports(Reporting[] reports) {
            this.reports = reports;
        }
        // Gets information from transactions.txt
        public Reporting[] GetReportTrans() {
                Reporting[] reports = new Reporting[100];
                StreamReader inFile = new StreamReader("transactions.txt");
                int countT = 0;
                string dataRow = inFile.ReadLine();
                while(dataRow != null){
                string[] tempData = dataRow.Split("#");
                //int tempID = int.Parse(tempData[0]);
                reports[countT] = new Reporting(tempData[0], tempData[1], tempData[2], tempData[3], tempData[4], tempData[5], tempData[6]);

                dataRow = inFile.ReadLine();
                countT++;
                }
            Reporting.SetCount(countT);
            inFile.Close();
            return reports;
        } 
        // Lists sessions for individual customer
        public void FindSessions(string email, Reporting[] reports){

            Console.WriteLine("Your previous sessions were:");
            for (int i = 0; i < Reporting.GetCount(); i++){
                if(reports[i].GetAddress() == email){
                    if(reports[i].GetStatus() == "yes"){
                        Console.WriteLine("You are scheduled for one on {0}",reports[i].GetTDate());
                    } 
                    if (reports[i].GetStatus() == "no") {
                        Console.WriteLine("You have completed one on {0}", reports[i].GetTDate());
                    }
                }
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
                    toFile.WriteLine("Your previous sessions were:");
                    for (int i = 0; i < Reporting.GetCount(); i++){
                    if(reports[i].GetAddress() == email){
                    if(reports[i].GetStatus() == "yes"){
                        toFile.WriteLine("You are scheduled for one on {0}",reports[i].GetTDate());
                    } 
                    if (reports[i].GetStatus() == "no") {
                        toFile.WriteLine("You have completed one on {0}", reports[i].GetTDate());
                    }
                    }
                    } 
                    toFile.Close();
                    Console.WriteLine("File creation complete!");

                }
                else {Console.WriteLine("Incorrect Password..");}

            }
            else {Console.WriteLine("Returning to Menu.");}
        }
        // Returns index of transaction (by name)
        public int SearchReportN(string tempNn){
            //GetBookings();
            int lineNumber = 0;
                for (int i = 0; i < Reporting.GetCount(); i++){
                    if(reports[i].GetName() == tempNn) {
                        lineNumber = i;
                    }
                }
            return lineNumber;
        }
    
    }
}