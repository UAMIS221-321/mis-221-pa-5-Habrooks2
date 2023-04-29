using System;

namespace PA5 { 
    public class Booking {

        private string bID;
        private string traineeName;
        private string traineeAddress;
        private string trainDate;
        private string trainerID;
        private string trainerName;
        private string takenStatus;
        private static int count;
        public Booking(string ID, string name, string address, string date, string ID2, string name2, string taken){
            this.bID = ID; this.traineeName = name; this.traineeAddress = address; this.trainDate = date; this.trainerID = ID2; this.trainerName = name2; this.takenStatus = taken;
        }
        
        public string GetTranID(){
            return bID;
        }
        
        public void SetTranID(string i){
            this.bID = i;
        }

        public string GetBName(){
            return traineeName;
        }

        public void SetBName(string n){
            this.traineeName = n;
        }

        public string GetAddress(){
            return traineeAddress;
        }

        public void SetAddress(string a){
            this.traineeAddress = a;
        }

        public string GetTDate(){
            return trainDate;
        }

        public void SetTDate(string d){
            this.trainDate = d;
        }

        public void SetName(string n){
            this.traineeName = n;
        }

        public string GetName(){
            return traineeName;
        }
        public string GetID(){
            return trainerID;
        }

        public void SetID(string id){
            this.trainerID = id;
        }

        public string GetTName(){
            return trainerName;
        }

        public void SetTName(string na){
            this.trainerName = na;
        }

        public string GetStatus(){
            return takenStatus;
        }

         public void SetStatus(string set){
            this.takenStatus = set;
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