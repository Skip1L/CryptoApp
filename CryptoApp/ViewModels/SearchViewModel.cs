using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;
using CoinGecko.Clients;
using CoinGecko.Entities.Response.Coins;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CryptoApp.Models;
using CryptoApp.Views.Pages;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using Newtonsoft.Json;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;
using CoinList = CoinGecko.Entities.Response.Coins.CoinList;
using MessageBox = System.Windows.MessageBox;

namespace CryptoApp.ViewModels
{
    public partial class SearchViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private string _name = "";
        [ObservableProperty]
        private string _symbol = "";
        [ObservableProperty]
        private string? _currentPrice = "";
        [ObservableProperty]
        private string? _totalVolume = "";
        [ObservableProperty]
        private string? _priceChange = "";
        [ObservableProperty]
        private string _search = "";
        [ObservableProperty]
        private bool _isEnableButton = false;

        private string[]? HomePageLink { get; set; }
        private static readonly HttpClient HttpClient = new();
        private static readonly JsonSerializerSettings SerializerSettings = new();
        private readonly CoinsClient _coinsClient = new(HttpClient, SerializerSettings);
        public IReadOnlyList<CoinList>? ColorCollection { get; private set; }
        public IReadOnlyList<CoinMarkets>? Enumerable { get; private set; }
        public void OnNavigatedTo()
        {
            GetCoinList();
        }
        
        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        private void OnSearch()
        {
            foreach (var text in ColorCollection!)
            {
                if (text.Name != Search & text.Id != Search)
                {
                    Name = Symbol = CurrentPrice = TotalVolume = PriceChange = "";
                    IsEnableButton = false;
                }
                else
                {
                    var task = GetCoinData(text.Id);
                    task.ContinueWith(task1 =>
                    {
                        PriceChange = Enumerable![0].PriceChangePercentage24H.ToString()!.Contains('-')
                            ? Enumerable![0].PriceChangePercentage24H + "% (24h)"
                            : "+" + Enumerable![0].PriceChangePercentage24H + "% (24h)";
                        Name = text.Name;
                        Symbol = text.Symbol;
                        CurrentPrice = Enumerable![0].CurrentPrice + " usd";
                        TotalVolume = "Volume: "+Enumerable![0].TotalVolume;
                        
                    });
                    break;
                }
            }
        }

        [RelayCommand]
        private void OpenHomePage()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = HomePageLink![0],
                    UseShellExecute = true
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                /*throw;*/
            }
            
        }

        [RelayCommand]
        private async void GetCoinList()
        {
            try
            {
                ColorCollection = (await _coinsClient.GetCoinList(false));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        private async Task GetCoinData(string id)
        {
            try
            {
                Enumerable = (await _coinsClient.GetCoinMarkets("usd", new[] {id}, "market_cap_desc", 1, 1, true, "24h"));
                HomePageLink = (await _coinsClient.GetAllCoinDataWithId(id, "false", false, false,false,false,false)).Links.Homepage;
                IsEnableButton = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        
    }
}
