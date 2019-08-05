using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace InsureMe
{
    public class InsureMe
    {
        public InsureMe() { }

        public int GetBasePremiumForAge(string age)
        {
            using (StreamReader r = new StreamReader("insuremedata.json"))
            {
                string json = r.ReadToEnd();
                List<BasePremium> listOfPremiums = JsonConvert.DeserializeObject<List<BasePremium>>(json);
                return listOfPremiums.Find(x => x.age == age).premium;
            }
        }


        public bool IsAgeValid(int age)
        {
            if (age < 25)
            {
                return false;
            }
            else if (age > 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GetRiskRating(int age)
        {

            if (age >= 45 && age <= 50)
            {
                return "High";
            }
            else if (age > 35 && age < 45)
            {
                return "Low";
            }
            else
            {
                return "Standard";
            }

        }

        public int CalculateAdditionalCover(bool dreadDiseaseCover, bool spouseCover, bool hangoverCover)
        {
            int additionalCover = 0;

            additionalCover += (dreadDiseaseCover || dreadDiseaseCover) ? 50 : 0;
            additionalCover += (spouseCover || spouseCover) ? 200 : 0;
            additionalCover += (hangoverCover || hangoverCover) ? 100 : 0;

            return additionalCover;
        }

        public int CalculateTotalCover(int baseCover, int additionalCover)
        {
            return baseCover + additionalCover;
        } 
    }
}
