using CryptoApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Media;
using CoinGecko.Clients;
using CoinGecko.Entities.Response.Coins;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Wpf.Ui.Common.Interfaces;

namespace CryptoApp.ViewModels
{
    public partial class DataViewModel : ObservableObject, INavigationAware
    {
         private bool _isInitialized = false;

        [ObservableProperty]
        private IEnumerable<DataColor>? _colors;
        private List<CoinMarkets>? _response;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
                _isInitialized = false;
            }
                
        }

        public void OnNavigatedFrom()
        {
        }

        private async void Crypto()
        {
            HttpClient httpClient = new HttpClient();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            var colorCollection = new List<DataColor>();

            PingClient pingClient = new PingClient(httpClient, serializerSettings);
            SimpleClient simpleClient = new SimpleClient(httpClient, serializerSettings);
            CoinsClient coinsClient = new CoinsClient(httpClient, serializerSettings);

            // Check CoinGecko API status
            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)
            {
                // Getting current price of tether in usd
                string vsCurrencies = "usd";
                _response = (await coinsClient.GetCoinMarkets(vsCurrencies, new string[1] , "market_cap_desc", 10, 1, false, "1h"));
                foreach (var text in _response)
                {
                    colorCollection.Add(new DataColor
                    {
                        CryptoSymbol = text.Symbol,
                        CryptoName = text.Name,
                        CryptoCurrency= text.CurrentPrice.ToString()
                    });
                }
                Colors = colorCollection;
            }

        }


        private void InitializeViewModel()
        {
            Crypto();
            
            _isInitialized = true;
        }
    }
}
