using PokeApiNet;

namespace PokeInfo;
 
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		var data = await App.PokeService.GetListOfPokemons();
		cvPokemonList.ItemsSource= data;
    }

    private async void cvPokemonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = (NamedApiResource<Pokemon>)((CollectionView)sender)?.SelectedItem;
        var data = await App.PokeService.GetPokemonByName(item.Name);
    }
}

