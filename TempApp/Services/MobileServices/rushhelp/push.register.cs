using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

// http://go.microsoft.com/fwlink/?LinkId=290986&clcid=0x409

namespace TempApp
{
    internal class rushhelpPush
    {
        public async static void UploadChannel()

        {
           

            var channel = await Windows.Networking.PushNotifications.PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
           // var tags = new List<string>();
           // tags.Add("Town");

            try
            { 
                await App.rushhelpClient.GetPush().RegisterNativeAsync(channel.Uri);    
                await App.rushhelpClient.InvokeApiAsync("insert",
     
                    new JObject(new JProperty("toast", "Please help your help is required")));
            }
            catch (Exception exception)
            {
                HandleRegisterException(exception);
            }
        }

        private static void HandleRegisterException(Exception exception)
        {

        }
    }
}
