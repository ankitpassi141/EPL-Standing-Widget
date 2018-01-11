using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FootballUpdateWidget
{
    [Activity(MainLauncher = false)]
    public class MainActivity : Activity
    {
        public TextView team1, team2, team3, team4, team5;
        public TextView team1Score, team2Score, team3Score, team4Score, team5Score, updateTimer;
        public ImageButton teamUpdate;
        public WebClient client;
        public Uri APIurl;
        public static List<System.String> listTeamName = new List<System.String>();
        public static List<System.String> listTeamPoints = new List<System.String>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);



            FindViews();
            //ClientCall();
            ClickEvents();
        }

        private void ClickEvents()
        {
            try
            {
                teamUpdate.Click += async delegate
                {

                    using (var client = new HttpClient())
                    {
                        // send a GET request  
                        //var uri = "https://ankitpassi.000webhostapp.com/file_exp.php";
                        //var uri = "http://xonshiz.heliohost.org/public/eplStandingData.php";
                        var uri = "http://xonshiz.heliohost.org/ankit_passi/eplStandingData.php";
                        //var uri = "http://api.football-data.org//v1/competitions/445/leagueTable";	
                        var result = await client.GetStringAsync(uri);

                        dynamic dynJson = JsonConvert.DeserializeObject(result);
                        listTeamName.Clear();
                        foreach (var item in dynJson)
                        {
                            Console.WriteLine("{0} {1}\n",item.teamName,item.teamPoints);
                            listTeamName.Add(Convert.ToString(item.teamName));
                            listTeamPoints.Add(Convert.ToString(item.teamPoints));
                        }

                        team1.Text = listTeamName[0];
                        team1Score.Text = listTeamPoints[0];
                        team2.Text = listTeamName[1];
                        team2Score.Text = listTeamPoints[1];
                        team3.Text = listTeamName[2];
                        team3Score.Text = listTeamPoints[2];
                        team4.Text = listTeamName[3];
                        team4Score.Text = listTeamPoints[3];
                        team5.Text = listTeamName[4];
                        team5Score.Text = listTeamPoints[4];
                        string date = DateTime.Now.ToString("00:H:mm:ss");
                        string time = "Last updated on: " + date;
                        updateTimer.Text = time;
                    }
                };
            }
            catch (Exception e)
            {
                listTeamName.Clear();
                listTeamPoints.Clear();
                Console.Out.WriteLine("Exception form Main is: {0}", e);
            }
        }

        private void FindViews()
        {
            team1 = FindViewById<TextView>(Resource.Id.team1);
            team1Score = FindViewById<TextView>(Resource.Id.team1Points);
            team2 = FindViewById<TextView>(Resource.Id.team2);
            team2Score = FindViewById<TextView>(Resource.Id.team2Points);
            team3 = FindViewById<TextView>(Resource.Id.team3);
            team3Score = FindViewById<TextView>(Resource.Id.team3Points);
            team4 = FindViewById<TextView>(Resource.Id.team4);
            team4Score = FindViewById<TextView>(Resource.Id.team4Points);
            team5 = FindViewById<TextView>(Resource.Id.team5);
            team5Score = FindViewById<TextView>(Resource.Id.team5Points);
            teamUpdate = FindViewById<ImageButton>(Resource.Id.teamUpdateButton);
            updateTimer = FindViewById<TextView>(Resource.Id.exp2);
        }
    }
}

