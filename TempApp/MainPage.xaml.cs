using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Credentials;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace TempApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 


    public sealed partial class MainPage : Page
    {

        // Define a member variable for storing the signed-in user. 
        private MobileServiceUser user;

        // Define a method that performs the authentication process
        // using a Microsoft account 


       public MainPage()
        {
            this.InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(localStorage.FileExists("JsonFileName"))
            {
                string fileData = localStorage.ReadFile("JsonFileName");
                Registartion userInformation = JsonConvert.DeserializeObject<Registration>(fileData);
                //then he is logged in..take him yo dashboard
                //the userInformation object will give you all the saved info
            }
            else
            {
                //take him to signup screen
            }
                }

      

        private void Register_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(startpage));
        }

        private  void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
           
                Frame.Navigate(typeof(secondpage));
            }
        }

        
    }
