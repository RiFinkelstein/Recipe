using RecipeSystem;
using System.Data;

namespace RecipeMaui;

public partial class RecipeSearch : ContentPage
{
	public RecipeSearch()
	{
		InitializeComponent();
	}

    private void SearchRecipe()
    {
        DataTable dt = Recipe.SearchRecipe(RecipeNameTxt.Text);
        Recipelst.ItemsSource = dt.Rows;
    }

    private void Searchbtn_Clicked(object sender, EventArgs e)
    {
        SearchRecipe();
    }
}