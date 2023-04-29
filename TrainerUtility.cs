using System;
namespace PA5 {

    public class TrainerUtility {
        private Trainer[] trainers;
        //private static int count;
        
        public TrainerUtility(Trainer[] trainers) {
            this.trainers = trainers;
        }
        // Gets information from trainers.txt
        public Trainer[] GetTrainers(){
            Trainer[] trainers = new Trainer[100];
            string[] arrLine = File.ReadAllLines("trainers.txt");
            int size = arrLine.Length; 
            StreamReader inFile = new StreamReader("trainers.txt");
            int count = 0;
            string dataRow = inFile.ReadLine();
            while(dataRow != null){
                string[] tempData = dataRow.Split("#");
                //int tempID = int.Parse(tempData[0]);
                trainers[count] = new Trainer(tempData[0], tempData[1], tempData[2], tempData[3]);

                dataRow = inFile.ReadLine();
                count++;
            }
            Trainer.SetCount(count);
            inFile.Close();
            return trainers;

        }
        // Add a trainer
        public void AddTrainer(string nValue, string aValue, string eValue){
            Random rnd = new Random();
            int generate = rnd.Next(1000000,9999999);
            string generate2 = generate.ToString();
            StreamWriter inTrainer = File.AppendText("trainers.txt");
            inTrainer.WriteLine("{0}#{1}#{2}#{3}", generate, nValue, aValue, eValue);
            inTrainer.Close();
            GetTrainers();
        }
        // Delete a trainer
        public void DeleteTrainer(int search){
            StreamReader readFile = new StreamReader("trainers.txt");
            StreamWriter tempFile = new StreamWriter("trainers2.txt");
            //int lineVal = search - 1;
            string[] arrLine = File.ReadAllLines("trainers.txt");
            string toDelete = arrLine[search];
            //string tempLine = readFile.ReadLine();
            int i = 0;
            while (arrLine[i] != toDelete){
                tempFile.WriteLine(arrLine[i]);
                i++;
            }
            
            readFile.Close();
            File.Delete("trainers.txt");
            File.Move("trainers2.txt", "trainers.txt");
            tempFile.Close();
            File.Delete("trainers2.txt");
        }
        // Edit a trainer
        public void EditTrainer(int search){
            //StreamReader readFile = new StreamReader("trainers.txt");
            //StreamWriter editFile = new StreamWriter("trainers.txt");
            StreamWriter inFile = new StreamWriter("trainers2.txt");
            //int lineVal = search - 1;

            Console.WriteLine("What would you like to edit?");
            Console.WriteLine("Enter 1 to edit name, Enter 2 to edit the address, or Enter 3 to edit the email address.");
            int what = int.Parse(Console.ReadLine());
            if (what == 1) {
                Console.WriteLine("What would you like to edit the name to?");
                string replaceN = Console.ReadLine();
                
                Console.WriteLine("Editing name...");
                string[] arrLine = File.ReadAllLines("trainers.txt");
                string[] change = arrLine[search].Split("#");
                string temp = change[0] + "#" + replaceN + "#" + change[2] + "#" + change[3];
                arrLine[search] = temp;

                File.WriteAllLines("trainers2.txt", arrLine);
                //readFile.Close();
                File.Delete("trainers.txt");
                File.Move("trainers2.txt","trainers.txt");
                File.Delete("trainers2.txt");
                inFile.Close();

                Console.WriteLine("Done!");
            }
            else if (what == 2) {
                Console.WriteLine("What would you like to edit the address to?");
                string replaceA = Console.ReadLine();

                string[] arrLine = File.ReadAllLines("trainers.txt");
                string[] change = arrLine[search].Split("#");
                string temp = change[0] + "#" + change[1] + "#" + replaceA + "#" + change[3];
                arrLine[search] = temp;

                File.WriteAllLines("trainers2.txt", arrLine);
                //readFile.Close();
                File.Delete("trainers.txt");
                File.Move("trainers2.txt","trainers.txt");
                File.Delete("trainers2.txt");
                inFile.Close();


                Console.WriteLine("Done!");
            }
            else if (what == 3) {
                Console.WriteLine("What would you like to edit the email address to?");
                string replaceE = Console.ReadLine();

                string[] arrLine = File.ReadAllLines("trainers.txt");
                string[] change = arrLine[search].Split("#");
                string temp = change[0] + "#" + change[1] + "#" + change[2] + "#" + replaceE;
                arrLine[search] = temp;

                File.WriteAllLines("trainers2.txt", arrLine);
                //readFile.Close();
                File.Delete("trainers.txt");
                File.Move("trainers2.txt","trainers.txt");
                File.Delete("trainers2.txt");
                inFile.Close();


                Console.WriteLine("Done!");
            }
            else {Console.WriteLine("Invalid. Try Again.");}
        }
        // Searches for index for a trainer by ID
        public int SearchTrainerID(string tempi, Trainer[] trainers){
            int lineNumber = 0;
                for (int i = 0; i < Trainer.GetCount(); i++){
                    if(trainers[i].GetTrainerID() == tempi) {
                        lineNumber = i;
                    }
                }
            return lineNumber;
        }
        // Searches for index for a trainer by name
        public int SearchTrainerName(string tempn, Trainer[] trainers){
            int lineNumber = 0;
                for (int i = 0; i < Trainer.GetCount(); i++){
                    if(trainers[i].GetName() == tempn) {
                        lineNumber = i;
                    }
                }
            return lineNumber;
        }
        
        // Sees if trainer exists (by id)
        public bool Exist(string temp, Trainer[] trainers){
            bool see = false;
            for (int i = 0; i < Trainer.GetCount(); i ++){
                if (trainers[i].GetTrainerID() == temp){
                    see = true;
                }
                else {see = false;}
            } 
            return see;
        }
        // Sees if trainer exists (by name)
        public bool ExistN(string temp, Trainer[] trainers){
            bool see = false;
            for (int i = 0; i < Trainer.GetCount(); i ++){
                if (trainers[i].GetName() == temp){
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
    }
}