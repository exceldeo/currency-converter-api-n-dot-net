using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currency_Conversion_App   
{
    class CurrencyList
    {
        public Dictionary<string, CurrencyData> results;

        public CurrencyData getCurrencyByID(string id)
        {
            return results[id];
        }

        public CurrencyData GetCurrencyByIndex(int index)
        {
            return results.ElementAt(index).Value;
        }

        public CurrencyData[] ToArray()
        {
            return results.Values.ToArray();
        }

        public static CurrencyList Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<CurrencyList>(data);
        }

    }

    class CurrencyData
    {
        public string currencyName;
        public string currencySymbol;
        public string id;
    }
}