   M S B A M L   `   `   `  ????D  @CryptoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CryptoApp.Views.PagesCryptoApp.Views.Pages  5      &     CryptoApp.Views.Pages.SearchPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CryptoApp.Views.Pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=2.0.3.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5        N? Title$  
SearchPage??5	         TextFillColorPrimaryBrush N? 
Foreground# ?   5      .??5      ? $
??56,0q?6   $	??Top=?6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      $
??Auto ?6#   ?? 5      $??* ?6#   .+?5        Wpf.Ui.Controls.TextBox  -   5        $??TextBox??5       $??0??5      $??0??5      $??Stretch=?5!      $??Center=?5"      $	??224??5#         PlaceholderText$ Search??5%      $	??200??5&      ??5$      ?? *ViewModel.Search+ ?? Mode$ TwoWay=?5&        Wpf.Ui.Controls.Button  5'      $??0??5)      $??1??5*      $
??Left=?5,      $??Center=?5-         Icon$ Search48=?5.      ??5(      ?? *ActualHeight+ ?? ElementName$ TextBox????5+      ?? *ViewModel.SearchCommand+$ OneWay=?5.        5/      $??0??50      $??1??51      $??Center=?54      $??Right=?55      $ Link48=?56      $??	Home page??57      {?52      ?? *ViewModel.IsEnableButton+$ OneWay=???53      ?? *ActualHeight+$ TextBox????58      ?? *ViewModel.OpenHomePageCommand+$ OneWay=?59      ? 5:   
   $??1??5;      $
??0,10q?5<       5=      ?? 5>      $
??Auto ?6#   ?? 5?      $??60 ?6#   ?? 5@      $
??Auto ?6#   ?? 5A      $
??Auto ?6#   .+?5C      ?? -   5        $??CoinName??5D      $??0??5E      $??28(?5F      $
??12,0q?5G      $??Center=?5H      ??5I      ?? *ViewModel.Name+$ OneWay=??? 5J      $??1??5K      $??20(?5L      $??0q?5N      $??Center=?5O      ??5M      ?? *Height+$ CoinName????5P      ?? *ViewModel.Symbol+$ OneWay=??? 5Q      $??2??5R      $??28(?5S      $
??12,0q?5T      $??Center=?5U      ??5V      ?? *ViewModel.CurrentPrice+$ OneWay=??? 5W      $??3??5X      $??28(?5Y      $
??12,0q?5Z      $??Center=?5[      ??5\      ?? *ViewModel.PriceChange+$ OneWay=?5]      ? 5^   
   $??2??6    5_      ?? 5`      $
??Auto ?6#   ?? 5a      $??* ?6#   .+?5c      ?? $??0??5d      $??28(?5e      $
??12,0q?5f      $??Bottom=?5g      ??5h      ?? *ViewModel.TotalVolume+$ OneWay=?5i      5j      5k      