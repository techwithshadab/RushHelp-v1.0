using Microsoft.WindowsAzure.Messaging;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TempApp { 
      
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

public class VictimLocation
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Latitude")]
        public  double Latitude { get; set; }
        [JsonProperty(PropertyName = "Longitude")]
        public  double Longitude { get; set; }
        [JsonProperty(PropertyName = "Town")]
         public string Town { get; set; }


    }






    public sealed partial class secondpage : Page
    {


        private MobileServiceCollection<VictimLocation, VictimLocation> deta;
        private IMobileServiceTable<VictimLocation> dattable =
            App.rushhelpClient.GetTable<VictimLocation>();


        public async Task Detailsinsert(VictimLocation victimlocation)
        {
            await dattable.InsertAsync(victimlocation);
            deta.Add(victimlocation);


        }





        public secondpage()
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

        private async void Accident_tap(object sender, TappedRoutedEventArgs e)
        {
            double vlatitude, vlongitude;
            string town;
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;


            try
                 {
                       Geoposition geoposition = await geolocator.GetGeopositionAsync(
                            maximumAge: TimeSpan.FromMinutes(5),
                             timeout: TimeSpan.FromSeconds(10)
                );
             
                vlatitude = geoposition.Coordinate.Latitude;
                vlongitude = geoposition.Coordinate.Longitude;



               


             
                    BasicGeoposition location = new BasicGeoposition();
            location.Latitude = vlatitude;
            location.Longitude =vlongitude;
            Geopoint pointToReverseGeocode = new Geopoint(location);

           
            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            
               town= result.Locations[0].Address.Street;




                    VictimLocation item = new VictimLocation
                    {
                        Latitude = vlatitude,
                        Longitude = vlongitude,
                        Town = town
                    };
                
                



               await Detailsinsert(item);


               

            }



                   
                      catch (Exception )
                      {
                       //exception 
                      }

            Frame.Navigate(typeof(Accidentout));





            TempApp.rushhelpPush.UploadChannel();




        }

        private async void blooddonate_tap(object sender, TappedRoutedEventArgs e)
        {
            
             
        double vlatitude, vlongitude;
            string town;
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;


            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                     maximumAge: TimeSpan.FromMinutes(5),
                      timeout: TimeSpan.FromSeconds(10)
         );
              
                vlatitude = geoposition.Coordinate.Latitude;
                vlongitude = geoposition.Coordinate.Longitude;






       
                BasicGeoposition location = new BasicGeoposition();
                location.Latitude = vlatitude;
                location.Longitude = vlongitude;
                Geopoint pointToReverseGeocode = new Geopoint(location);

                // Reverse geocode the specified geographic location.
                MapLocationFinderResult result =
                    await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

                // If the query returns results, display the name of the town
                // contained in the address of the first result.


                town = result.Locations[0].Address.Street;




                VictimLocation item = new VictimLocation
                {
                    Latitude = vlatitude,
                    Longitude = vlongitude,
                    Town = town
                };





                await Detailsinsert(item);


            }



           
            catch (Exception)
            {
                //exception 
            }
            Frame.Navigate(typeof(donationform));

            TempApp.rushhelpPush.UploadChannel();

        }

        private async void medicalhelp_tap(object sender, TappedRoutedEventArgs e)
        {


            double vlatitude, vlongitude;
            string town;
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;


            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                     maximumAge: TimeSpan.FromMinutes(5),
                      timeout: TimeSpan.FromSeconds(10)
         );
                
                vlatitude = geoposition.Coordinate.Latitude;
                vlongitude = geoposition.Coordinate.Longitude;






                //private async void ReverseGeocode()

                // Location to reverse geocode.
                BasicGeoposition location = new BasicGeoposition();
                location.Latitude = vlatitude;
                location.Longitude = vlongitude;
                Geopoint pointToReverseGeocode = new Geopoint(location);

                // Reverse geocode the specified geographic location.
                MapLocationFinderResult result =
                    await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);


                town = result.Locations[0].Address.Street;




                VictimLocation item = new VictimLocation
                {
                    Latitude = vlatitude,
                    Longitude = vlongitude,
                    Town = town
                };





                await Detailsinsert(item);




            }


            
            catch (Exception)
            {
                //exception 
            }


            Frame.Navigate(typeof(Medicalout));


            TempApp.rushhelpPush.UploadChannel();



          
        }

        private async void womenharrasement_tap(object sender, TappedRoutedEventArgs e)
        {



            double vlatitude, vlongitude;
            string town;
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;


            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                     maximumAge: TimeSpan.FromMinutes(5),
                      timeout: TimeSpan.FromSeconds(10)
         );
                
                vlatitude = geoposition.Coordinate.Latitude;
                vlongitude = geoposition.Coordinate.Longitude;






                

                // Location to reverse geocode.
                BasicGeoposition location = new BasicGeoposition();
                location.Latitude = vlatitude;
                location.Longitude = vlongitude;
                Geopoint pointToReverseGeocode = new Geopoint(location);

                // Reverse geocode the specified geographic location.
                MapLocationFinderResult result =
                    await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

                // If the query returns results, display the name of the town
                // contained in the address of the first result.


                town = result.Locations[0].Address.Street;




                VictimLocation item = new VictimLocation
                {
                    Latitude = vlatitude,
                    Longitude = vlongitude,
                    Town = town
                };





                await Detailsinsert(item);




            }



           
            catch (Exception)
            {
                //exception 
            }







            Frame.Navigate(typeof(Womenout));

          TempApp.rushhelpPush.UploadChannel();


            
        }



    }
}
