using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;
        private IRepository<IDelicacy> delicacies;
        private IRepository<ICocktail> cocktails;       
      
        public Controller()
        {
            booths = new BoothRepository();
            delicacies = new DelicacyRepository();
            cocktails = new CocktailRepository();

        }

        public string AddBooth(int capacity)
        {
            Booth booth = new Booth(booths.Models.Count +1, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booths.Models.Count, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);

            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (cocktails.Models.Any(x=>x.Name == cocktailName && x.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail = null;
            if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            cocktails.AddModel(cocktail);
            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);


            if (delicacies.Models.Any(x=>x.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IDelicacy delicacy = null;

            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            delicacies.AddModel(delicacy);
            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);

            double boothBill = booth.CurrentBill;
          
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {boothBill:f2} lv");
            sb.AppendLine($"Booth {booth.BoothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            foreach (var booth in booths.Models.Where(x=>x.IsReserved == false).Where(x=>x.Capacity >= countOfPeople).OrderBy(x=>x.Capacity).ThenByDescending(x=>x.BoothId))
            {
                booth.ChangeStatus();
                return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
            }

            return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);

        }

        public string TryOrder(int boothId, string order)
        {
            string[] currOrder = order.Split("/").ToArray();

            string itemTypeName = currOrder[0];
            string itemName = currOrder[1];
            int countOfOrderPieces = int.Parse(currOrder[2]);

          
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);

            if (itemTypeName != "Hibernation" && itemTypeName != "MulledWine" && itemTypeName != "Gingerbread" && itemTypeName != "Stolen" )
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
            
            if (!cocktails.Models.Any(x=>x.Name == itemName) && !delicacies.Models.Any(x=>x.Name == itemName)) 
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (currOrder.Length > 3) // If Length is bigger we have cocktail
            {
               string sizeOfCocktail = currOrder[3];

                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName && x.Size == sizeOfCocktail);
                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, sizeOfCocktail, itemName); 
                }
                else
                {
                    booth.UpdateCurrentBill(cocktail.Price * countOfOrderPieces);

                    return string.Format(OutputMessages.SuccessfullyOrdered,booth.BoothId, countOfOrderPieces, itemName);    
                }
            }
           
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName);
            if (delicacy == null)
            {
                return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
            }
            else
            {
                booth.UpdateCurrentBill(delicacy.Price * countOfOrderPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderPieces, itemName);
            }
        }
    }
}
