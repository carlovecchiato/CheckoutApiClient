using System.Collections.Generic;

namespace Checkout.ApiServices.Drinks.ResponseModels
{
    public class DrinkList
    {
        public int Count
        {
            get { return Data.Count; }
        }

        public List<Drink> Data;
    }
}
