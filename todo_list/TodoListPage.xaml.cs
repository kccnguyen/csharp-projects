using Project5.Data;
using Project5.Models;
using Project5.Views;

namespace Project5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TodoListPage : ContentPage
{
    public TodoListPage()
    {
            InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        listView.ItemsSource = await database.GetItemsAsync();
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.TodoItemPage
        {
            BindingContext = new TodoItem()
        });
    }

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = e.SelectedItem as TodoItem
            });
        }
    }
}
}