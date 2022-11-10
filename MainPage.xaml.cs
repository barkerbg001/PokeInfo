using PokeApiNet;
using PokeInfo.Class;

namespace PokeInfo;
 
public partial class MainPage : ContentPage
{
    public bool isLoaded = false;
	public MainPage()
	{
		InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        if (!isLoaded)
        {
            App.iPokemonCount = await App.PokeService.GetNumberOfPokemons();
            App.lstPokemon = await App.PokeService.GetListOfPokemons();
            cvPokemonList.ItemsSource = App.lstPokemon;
            cvPokemonList.RemainingItemsThreshold = 6;
            cvPokemonList.RemainingItemsThresholdReached += CvPokemonList_RemainingItemsThresholdReached;
            isLoaded = true;
        }
    }

    private void CvPokemonList_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

    private async void cvPokemonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = (PokemonDto)((CollectionView)sender)?.SelectedItem;
        var data = await App.PokeService.GetPokemonByName(item.Name);
    }
}

