using System;

namespace PA5 { 
    public class Listing {
        private string lID;
        private string lName;
        private string lDate;
        private string lTime;
        private string lCost;
        private string lTaken;
        private static int count;
        public Listing(string lID, string lName, string lDate, string lTime, string lCost, string lTaken){
            this.lID = lID; this.lName = lName; this.lDate = lDate; this.lTime = lTime; this.lCost = lCost; this.lTaken = lTaken;
        }

        public string GetListingID(){
            return lID;
        }
        
        public void SetListingID(string idValue){
            this.lID = idValue;
        }

        public string GetListingName(){
            return lName;
        }

        public void SetListingName(string nameValue){
            this.lName = nameValue;
        }

        public string GetDate(){
            return lDate;
        }

        public void SetDate(string dateValue){
            this.lDate = dateValue;
        }

        public void SetTime(string timeValue){
            this.lTime = timeValue;
        }

        public string GetTime(){
            return lTime;
        }

        public void SetCost(string costValue){
            this.lCost = costValue;
        }

        public string GetCost(){
            return lCost;
        }

        public void SetListingTaken(string takenValue){
            this.lTaken = takenValue;
        }

        public string GetListingTaken(){
            return lTaken;
        }

          public static void SetCount(int tempCount){
            count = tempCount;
        }
        // Increment Count
        public static void InCount(){
            count++;
        }
        // Get Count
        public static int GetCount(){
            return count;
        }

    }
}
