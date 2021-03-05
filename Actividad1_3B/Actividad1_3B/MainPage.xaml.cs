using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Fingerprint;


namespace Actividad1_3B
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnFinger(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);
            
            if (result)
            {
                var auth = await CrossFingerprint.Current.AuthenticateAsync("Presiona el sensor");

                if (auth.Authenticated)
                {
                    Resultado.Text = "Ingreso exitoso huella reconocida";
                }
                else
                {
                    Resultado.Text = "Ingreso fallido huella no reconocida";
                }
            }

            else
            {
                await DisplayAlert("Error", "Dispositivo no compatible.", "OK");
            }
        }
    }
}
