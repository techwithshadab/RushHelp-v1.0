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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TempApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>





    public class Registartion
    {



        public string Id { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string fullname { get; set; }
        [JsonProperty(PropertyName = "Age")]
        public int Age { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public string gender { get; set; }
        [JsonProperty(PropertyName = "Officecity")]
        public string Officecity { get; set; }
        [JsonProperty(PropertyName = "Homecity")]
        public string Homecity { get; set; }
        [JsonProperty(PropertyName = "Country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "State")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "District")]
        public string District { get; set; }
        [JsonProperty(PropertyName = "PhoneNumber")]
        public int PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "EmergencyNumber1")]
        public int EmergencyNumber1 { get; set; }
        [JsonProperty(PropertyName = "EmergencyNumber2")]
        public int EmergencyNumber2 { get; set; }
        [JsonProperty(PropertyName = "Latitude")]
        public string Latitude { get; set; }
        [JsonProperty(PropertyName = "Longitude")]
        public string Longitude { get; set; }




    }










    public sealed partial class startpage : Page
    {


        private MobileServiceCollection<Registartion, Registartion> deta;
        private IMobileServiceTable<Registartion> dattable =
            App.rushhelpClient.GetTable<Registartion>();



        public async Task Detailsinsert(Registartion registartion)
        {
            await dattable.InsertAsync(registartion);
            deta.Add(registartion);


        }




        public startpage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void SignUp(object sender, RoutedEventArgs e)
        {   if (string.IsNullOrWhiteSpace(FullName.Text) || string.IsNullOrWhiteSpace(age.Text) || string.IsNullOrWhiteSpace(Gender.Text) || string.IsNullOrWhiteSpace(phoneNumber.Text) || string.IsNullOrWhiteSpace(emergencyNumber1.Text) || string.IsNullOrWhiteSpace(emergencyNumber2.Text) || string.IsNullOrWhiteSpace(officeCity.Text) || string.IsNullOrWhiteSpace(homeCity.Text) || string.IsNullOrWhiteSpace(country.Text) || string.IsNullOrWhiteSpace(state.Text) || string.IsNullOrWhiteSpace(district.Text))
           
            { error.Text = "Missing detatils!!!"; }
            else {
                string latitude, longitude;
                Geolocator geolocator = new Geolocator();
                geolocator.DesiredAccuracyInMeters = 50;
                try
                {

                    Geoposition geoposition = await geolocator.GetGeopositionAsync(
                               maximumAge: TimeSpan.FromMinutes(5),
                                timeout: TimeSpan.FromSeconds(10)
                   );
                    
                    latitude = geoposition.Coordinate.Latitude.ToString("0.00");
                    longitude = geoposition.Coordinate.Longitude.ToString("0.00");








                    Registartion item = new Registartion
                    {
                        fullname = FullName.Text,
                        Age = ToInt32(age.Text),
                        gender = Gender.Text,
                        PhoneNumber = ToInt32(phoneNumber.Text),
                        EmergencyNumber1 = ToInt32(emergencyNumber1.Text),
                        EmergencyNumber2 = ToInt32(emergencyNumber2.Text),
                        Officecity = officeCity.Text,
                        Homecity = homeCity.Text,
                        Country = country.Text,
                        State = state.Text,
                        District = district.Text,
                        Latitude = latitude,
                        Longitude = longitude


                    };



                    

                    await Detailsinsert(item);
                    //after succeessful insertion in the table,
                    // you need to save it in local storagee.
                    //you can serialize to json and save it as a file.
                    //sample code :
                     string jsonData = JsonConvert.SerializeObject(item);
                    // it says localstorage does not exist?
                     localstorage.SaveFile(jsonData, "JsonFileName");
                }
                catch (Exception)
                {

                }




                // TODO store data in remote database
                Frame.Navigate(typeof(firstpage));
            }


             

           



        }

        private int ToInt32(string text)
        {
            int x = 0;
            Int32.TryParse(text, out x);
            return x;

            throw new NotImplementedException();
        }



     /*   public static BackgroundTaskRegistration RegisterBackgroundTask(string taskEntryPoint,
                                                                        string taskName,
                                                                        IBackgroundTrigger trigger,
                                                                        IBackgroundCondition condition)
        {
            //
            // Check for existing registrations of this background task.
            //

            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {

                if (cur.Value.Name == taskName)
                {
                    // 
                    // The task is already registered.
                    // 

                    return (BackgroundTaskRegistration)(cur.Value);
                }
            }


            //
            // Register the background task.
            //

            var builder = new BackgroundTaskBuilder();

            builder.Name = taskName;
            builder.TaskEntryPoint = taskEntryPoint;

            builder.SetTrigger(new Windows.ApplicationModel.Background.PushNotificationTrigger());



            if (condition != null)
            {

                builder.AddCondition(condition);
            }

            BackgroundTaskRegistration task = builder.Register();

            return task;
        }*/






    }









}


