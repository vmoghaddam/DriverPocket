using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DriverPocket
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                DisplayAlert("alert", "this is a alert", "ok");
            };
            menuBtn.GestureRecognizers.Add(tapGestureRecognizer);

        }

       
        public async void btn_clicked(object sender, System.EventArgs e)
    {
        while (true)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync();
            }
            lblLat.Text += location.Latitude.ToString();
            lblLong.Text += location.Longitude.ToString();
            lblAlt.Text += location.Altitude.ToString();


            var lt = location.Latitude.ToString();
            var lng = location.Longitude.ToString();

            RestClient client = new RestClient("http://apipouya.crewpocket.ir/odata/coord/save/" + lt + "/" + lng + "/" + "1");
            var request = new RestRequest(Method.GET);
            client.Execute(request);
            IRestResponse response = client.Execute(request);

            await Task.Delay(30000);
        }
    }
}
}

