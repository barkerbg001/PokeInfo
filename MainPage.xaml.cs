using PokeApiNet;
using PokeInfo.Service;

namespace PokeInfo;

public partial class MainPage : ContentPage
{
	PokeService PokeService = new PokeService();

	public MainPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		var data = await PokeService.GetListOfPokemons();
		cvPokemonList.ItemsSource= data;
    }

    private async void cvPokemonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = (NamedApiResource<Pokemon>)((CollectionView)sender)?.SelectedItem;
        var data = await PokeService.GetPokemonByName(item.Name);
    }
}

