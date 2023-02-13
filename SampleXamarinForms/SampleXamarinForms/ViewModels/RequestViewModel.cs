using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SampleXamarinForms.Models;
using SampleXamarinForms.Views;

namespace SampleXamarinForms.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class RequestViewModel : BaseViewModel
    {
        public Command ItemTapped { get; }
        private string displayText;
        private string itemId;

        public string DisplayText
        {
            get => displayText;
            set => SetProperty(ref displayText, value);
        }

        public RequestViewModel()
        {
            Title = "Request";
            DisplayText = "Select Item";

            ItemTapped = new Command(OnItemSelected);
        }

        async void OnItemSelected()
        {

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemsPage)}");
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                SetDisplayText(value);
            }
        }

        public async void SetDisplayText(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                DisplayText = item.Text;
            }
            catch(Exception)
            {
                Debug.WriteLine("Failed to set DisplayText");
            }
        }
    }
}
