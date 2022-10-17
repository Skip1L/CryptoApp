using System;
using System.Collections.Generic;
using System.Net.Http;
using CoinGecko.Clients;
using CoinGecko.Entities.Response.Coins;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Wpf.Ui.Common.Interfaces;
using MessageBox = System.Windows.MessageBox;

namespace CryptoApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject, INavigationAware
    {
         private bool _isInitialized = false;
         private readonly List<CoinMarkets> _coinMarketsList = new();
         private static readonly HttpClient HttpClient = new();
         private static readonly JsonSerializerSettings SerializerSettings = new();


         private readonly CoinsClient _coinsClient = new(HttpClient, SerializerSettings);

        [ObservableProperty]
        private IEnumerable<CoinMarkets>? _coinMarketsEnumerable;
        private List<CoinMarkets>? _response;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
                
        }

        public void OnNavigatedFrom()
        {
        }

        private async void InitializeViewModel()
        {
            try
            {
                _response = (await _coinsClient.GetCoinMarkets("usd", new string[1] , "market_cap_desc", 10, 1, false, "1h"));
                foreach (var text in _response)
                {
                    _coinMarketsList.Add(new CoinMarkets
                    {
                        Symbol = text.Symbol,
                        Name = text.Name,
                        CurrentPrice = text.CurrentPrice
                        
                    });
                }
                CoinMarketsEnumerable = _coinMarketsList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            
            _isInitialized = true;
        }
    }
}
