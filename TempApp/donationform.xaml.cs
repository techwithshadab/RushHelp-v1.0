using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.ApplicationModel.Background;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TempApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class Donationdetails
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "PhoneNumber")]
        public int PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "BloodGroup")]
        public string BloodGroup { get; set; }

    }








    public sealed partial class donationform : Page
    {







        private MobileServiceCollection<Donationdetails, Donationdetails> deta;
        private IMobileServiceTable<Donationdetails> dattable =
            App.rushhelpClient.GetTable<Donationdetails>();



        public async Task Detailsinsert(Donationdetails donationdetails)
        {
            await dattable.InsertAsync(donationdetails);
            deta.Add(donationdetails);


        }
        public donationform()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }



        private async void request_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(contact.Text) || string.IsNullOrWhiteSpace(group.Text))
            {
                Missing.Text = "Missing detatils!!!";

            }
            else { 
            try {

                Donationdetails item = new Donationdetails
                {
                    PhoneNumber = ToInt32(contact.Text),
                    BloodGroup = group.Text
                };









                await Detailsinsert(item);


            }
            catch (Exception) { }

            TempApp.rushhelpPush.UploadChannel();

            Frame.Navigate(typeof(Blooddonateout));

            }
        }
        private int ToInt32(string text)
        {
            int x = 0;
            Int32.TryParse(text, out x);
            return x;

            throw new NotImplementedException();
        }
    }

}