using System;

namespace InsureMe
{
    class Program
    {
     
        static void Main(string[] args)
        {

            Program newProgram = new Program();
            newProgram.runInsureMeQuestionnaire();

        }

        public void runInsureMeQuestionnaire()
        {
            InsureMe insureMe = new InsureMe();

            Console.WriteLine("Welcome to InsureMe \n\nPlease provide the details of your client");
            Console.WriteLine("------------------------\n");

            Console.Write("Client's first name: ");
            string clientFirstName = Console.ReadLine();

            Console.Write("Client's last name: ");
            string clientLastName = Console.ReadLine();

            Console.Write("Client's age: ");
            string clientAgeStr = Console.ReadLine();

            int clientAge = Convert.ToInt32(clientAgeStr);

            bool ageValidty = insureMe.IsAgeValid(clientAge);
            string risk = insureMe.GetRiskRating(clientAge);

            if (!ageValidty)
            {
                Console.WriteLine($"Unfortunately insurance cannot be supplied for {clientFirstName} {clientLastName} as they are not within the insurable age bracket");
                return;
            }

            Console.WriteLine($"The base insurance premium for {clientFirstName} {clientLastName} is R{insureMe.GetBasePremiumForAge(clientAge.ToString())}.00");

            if (risk != "Standard" && risk != "")
            {
                Console.WriteLine($"{clientFirstName} {clientLastName} has a {risk} risk rating");
            }

            Console.WriteLine("------------------------\n");

            Console.Write("Would you like to add any of the additional cover options: \nDread Disease Cover\nSpouse Cover\nHangover Cover\n");

            Console.Write("(y/n)");

            string addAdditionalCover = Console.ReadLine();
            int additionalCoverCost = 0;

            string ddCover = "";
            string sCover = "";
            string hCover = "";

            bool ddCoverAccepted = false;
            bool sCoverAccepted = false;
            bool hCoverAccepted = false;

            if (addAdditionalCover.ToLower() == "y" || addAdditionalCover.ToLower() == "yes")
            {

                Console.Write("Do you wish to add Dread Disease Cover @ R50.00? (y/n)");
                ddCover = Console.ReadLine();
                ddCoverAccepted = (ddCover.ToLower() == "y" || ddCover.ToLower() == "yes");

                Console.Write("Do you wish to add Spouse Cover @ R200.00? (y/n)");
                sCover = Console.ReadLine();
                sCoverAccepted = (sCover.ToLower() == "y" || sCover.ToLower() == "yes");

                Console.Write("Do you wish to add Hangover Cover @ R100.00? (y/n)");
                hCover = Console.ReadLine();
                hCoverAccepted = (hCover.ToLower() == "y" || hCover.ToLower() == "yes");

                additionalCoverCost = insureMe.CalculateAdditionalCover(ddCoverAccepted, sCoverAccepted, hCoverAccepted);

            }

            Console.WriteLine("------------------------\n");
            Console.WriteLine("\n");

            Console.WriteLine($"Thank you for filling in the InsureMe form. Here is the final quotation for {clientFirstName} {clientLastName}");
            Console.WriteLine("\n");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("\n");
            Console.WriteLine($"First Name: {clientFirstName}\n");
            Console.WriteLine($"Last Name: {clientLastName}\n");
            Console.WriteLine($"Age: {clientAge}\n");

            int basePremium = insureMe.GetBasePremiumForAge(clientAge.ToString());

            Console.WriteLine($"Base Premium: R{basePremium}.00\n");

            if (addAdditionalCover.ToLower() == "y" || addAdditionalCover.ToLower() == "yes")
            {
                Console.WriteLine("Additional Cover: Accepted\n");
                Console.WriteLine($"\n");
                Console.WriteLine($"Dread Disease Cover @50:00 - { ddCoverAccepted }\n");
                Console.WriteLine($"Spouse Cover @ R200.00 - { sCoverAccepted }\n");
                Console.WriteLine($"Hangover Cover @ R100.00 - { hCoverAccepted }\n");
            }
            else
            {
                Console.WriteLine("Additional Cover: Declined\n");
            }

            Console.WriteLine($"------------------------\n");

            Console.WriteLine($"The total monthly insurance premium for {clientFirstName} {clientLastName} will be {insureMe.CalculateTotalCover(basePremium, additionalCoverCost)}.00");

            if (risk != "Standard" && risk != "")
            {
                Console.WriteLine($"{clientFirstName} {clientLastName} has a {risk} risk rating");
            }

        }

    }
}