using System;

namespace PA5 { 
    public class Trainer {

        private string ID;
        private string name;
        private string address;
        private string emailAddress;
        private static int count;

        public Trainer(string ID, string name, string address, string emailAddress){
            this.ID = ID; this.name = name; this.address = address; this.emailAddress = emailAddress;
        }
        
        public string GetTrainerID(){
            return ID;
        }
        
        public void SetTrainerID(string idValue){
            this.ID = idValue;
        }

        public string GetName(){
            return name;
        }

        public void SetName(string nameValue){
            this.name = nameValue;
        }

        public string GetAddress(){
            return address;
        }

        public void SetAddress(string addressValue){
            this.address = addressValue;
        }

        public string GetEmailAddress(){
            return emailAddress;
        }

        public void SetEmailAddress(string emailValue){
            this.emailAddress = emailValue;
        }

        public static void SetCount(int tempCount){
            count = tempCount;
        }
       
        public static void InCount(){
            count++;
        }
       
        public static int GetCount(){
            return count;
        }
    }
}