﻿using Newtonsoft.Json;

namespace CornyClient
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void LoadJoke(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/cornyapi/");
            HttpResponseMessage response = client.GetAsync("random").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                JokeJson joke = JsonConvert.DeserializeObject<JokeJson>(jsonResponse) ?? new JokeJson();
                JokeLabel.Text = joke.joke;
            }
        }
    }

}
