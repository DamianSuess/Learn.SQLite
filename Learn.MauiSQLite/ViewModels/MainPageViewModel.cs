using System.Collections.ObjectModel;
using Test.PrismMaui.Models;
using Test.PrismMaui.Services;

namespace Test.PrismMaui.ViewModels
{
  public class MainPageViewModel : BindableBase
  {
    private readonly INavigationService _navigationService;
    private readonly ISemanticScreenReader _screenReader;
    private readonly ISqliteService _db;

    private ObservableCollection<Customer> _items;
    private Customer _itemSelected;

    public MainPageViewModel(INavigationService navigationService, ISemanticScreenReader screenReader, ISqliteService db)
    {
      _navigationService = navigationService;
      _screenReader = screenReader;
      _db = db;
    }

    public string Title => "Prism Maui - Intro";

    public DelegateCommand CmdAdditem => new DelegateCommand(() =>
    {
      ; // TODO: Add item to list and save it
    });

    public ObservableCollection<Customer> Items
    {
      get => _items;
      set => SetProperty(ref _items, value);
    }

    public Customer ItemSelected
    {
      get => _itemSelected;
      set => SetProperty(ref _itemSelected, value);
    }
  }
}
