using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Appwidget;
using System.Net.Http;
using Newtonsoft.Json;

namespace FootballUpdateWidget
{
    [BroadcastReceiver(Label = "EPL Standing")]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
    [MetaData("android.appwidget.provider", Resource = "@xml/appwidgetprovider")]
    class AppWidget : AppWidgetProvider
    {

        public string team1, team2, team3, team4, team5;
        public string team1points, team2points, team3points, team4points, team5points;
        public static List<System.String> listTeamName = new List<System.String>();
        public static List<System.String> listTeamPoints = new List<System.String>();

        public async void OnEnabledAsync(Context context)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //Console.Out.WriteLine("Inside Enabled : 2");
                    // send a GET request  
                    //var uri = "https://ankitpassi.000webhostapp.com/file_exp.php";
                    //var uri = "https://testankit.000webhostapp.com/eplStandingData.php";
                    //var uri = "http://xonshiz.heliohost.org/public/eplStandingData.php";
                    var uri = "http://xonshiz.heliohost.org/ankit_passi/eplStandingData.php";
                    var result = await client.GetStringAsync(uri);
                    //Console.Out.WriteLine("Inside Enabled : 1");
                    dynamic dynJson = JsonConvert.DeserializeObject(result);
                    foreach (var item in dynJson)
                    {

                        listTeamName.Add(Convert.ToString(item.teamName));
                        listTeamPoints.Add(Convert.ToString(item.teamPoints));
                    }
                }
            }
            catch(Exception e)
            {
                Console.Out.WriteLine("Exception is: {0}", e);
                listTeamName.Clear();
                listTeamPoints.Clear();
            }
        }

        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
            //Console.Out.WriteLine("uPDATE Called : 2");
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context, appWidgetIds));
            //Console.Out.WriteLine("uPDATE Called : 3");
            
            //Console.Out.WriteLine("uPDATE Called : 4");
        }

        private RemoteViews BuildRemoteViews(Context context, int[] appWidgetIds)
        {

            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.eplLineupWidget);
            OnEnabledAsync(context);
            SetTextViewText(widgetView);
            RegisterClicks(context, appWidgetIds, widgetView);
            return widgetView;

        }
        private void SetTextViewText(RemoteViews widgetView)
        {
            //    if (listTeamName.Count==0)
            //    {
            //        team1 = "1";
            //        team1points = "2";
            //    }
            //    else
            //    {
            //        //team1 = listTeamName[0];
            //        //team1points = listTeamPoints[0];
            //        team1 = "3";
            //        team1points = "4";
            //    }
            //team2 = MainActivity.listTeamName[1];
            //team2points = MainActivity.listTeamPoints[1];
            //team3 = MainActivity.listTeamName[2];
            //team3points = MainActivity.listTeamPoints[2];
            //team4 = MainActivity.listTeamName[3];
            //team4points = MainActivity.listTeamPoints[3];
            //team5 = MainActivity.listTeamName[4];
            //team5points = MainActivity.listTeamPoints[4];

            ////Typeface tf = Typeface.CreateFromAsset(Context, "epl.ttf");

            //widgetView.SetTextViewText(Resource.Id.widget_team1, string.Format(team1));
            //widgetView.SetTextViewText(Resource.Id.widget_team1points, string.Format(team1points));
            //widgetView.SetTextViewText(Resource.Id.widget_team2, string.Format(team2));
            //widgetView.SetTextViewText(Resource.Id.widget_team2points, string.Format(team2points));
            //widgetView.SetTextViewText(Resource.Id.widget_team3, string.Format(team3));
            //widgetView.SetTextViewText(Resource.Id.widget_team3points, string.Format(team3points));
            //widgetView.SetTextViewText(Resource.Id.widget_team4, string.Format(team4));
            //widgetView.SetTextViewText(Resource.Id.widget_team4points, string.Format(team4points));
            //widgetView.SetTextViewText(Resource.Id.widget_team5, string.Format(team5));
            //widgetView.SetTextViewText(Resource.Id.widget_team5points, string.Format(team5points));
            if (listTeamName.Count == 0)
            {
                widgetView.SetViewVisibility(Resource.Id.eplTeamsGrid, ViewStates.Visible);
                widgetView.SetViewVisibility(Resource.Id.eplNeedRefresh, ViewStates.Gone);
                //team1 = "Refresh Needed";
                //team1points = "6";
                //widgetView.SetTextViewText(Resource.Id.widget_team1, string.Format(team1));
                //widgetView.SetTextViewText(Resource.Id.widget_team1points, string.Format(team1points));
                widgetView.SetTextViewText(Resource.Id.updateTime, string.Format("Last updated on: Update Needed"));
            }
            else
            {
                widgetView.SetViewVisibility(Resource.Id.eplTeamsGrid, ViewStates.Gone);
                widgetView.SetViewVisibility(Resource.Id.eplNeedRefresh, ViewStates.Visible);
                team1 = listTeamName[0];
                team1points = listTeamPoints[0];
                team2 = listTeamName[1];
                team2points = listTeamPoints[1];
                team3 = listTeamName[2];
                team3points = listTeamPoints[2];
                team4 = listTeamName[3];
                team4points = listTeamPoints[3];
                team5 = listTeamName[4];
                team5points = listTeamPoints[4];
                widgetView.SetTextViewText(Resource.Id.widget_team1, string.Format(team1));
                widgetView.SetTextViewText(Resource.Id.widget_team1points, string.Format(team1points));
                widgetView.SetTextViewText(Resource.Id.widget_team2, string.Format(team2));
                widgetView.SetTextViewText(Resource.Id.widget_team2points, string.Format(team2points));
                widgetView.SetTextViewText(Resource.Id.widget_team3, string.Format(team3));
                widgetView.SetTextViewText(Resource.Id.widget_team3points, string.Format(team3points));
                widgetView.SetTextViewText(Resource.Id.widget_team4, string.Format(team4));
                widgetView.SetTextViewText(Resource.Id.widget_team4points, string.Format(team4points));
                widgetView.SetTextViewText(Resource.Id.widget_team5, string.Format(team5));
                widgetView.SetTextViewText(Resource.Id.widget_team5points, string.Format(team5points));
                widgetView.SetTextViewText(Resource.Id.updateTime, string.Format("Last updated on: {0:H:mm:ss}", DateTime.Now));
            }
        }

        private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView)
        {
            var intent = new Intent(context, typeof(AppWidget));
            intent.SetAction(AppWidgetManager.ActionAppwidgetUpdate);
            intent.PutExtra(AppWidgetManager.ExtraAppwidgetIds, appWidgetIds);

            // Register click event for the Background
            var piBackground = PendingIntent.GetBroadcast(context, 0, intent, PendingIntentFlags.UpdateCurrent);
            widgetView.SetOnClickPendingIntent(Resource.Id.standingUpdate, piBackground);
            //Console.Out.WriteLine("Something happened");
        }

        //private static string AnnouncementClick = "AnnouncementClickTag";

        //private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView)
        //{
        //    widgetView.SetOnClickPendingIntent(Resource.Id.standingUpdate,GetPendingSelfIntent(context, AnnouncementClick));
        //}

        //private PendingIntent GetPendingSelfIntent(Context context, string action)
        //{
        //    var intent = new Intent(context, typeof(AppWidget));
        //    intent.SetAction(action);
        //    return PendingIntent.GetBroadcast(context, 0, intent, 0);
        //}

        //public override void OnReceive(Context context, Intent intent)
        //{
        //    base.OnReceive(context, intent);

        //    // Check if the click is from the "Announcement" button
        //    if (AnnouncementClick.Equals(intent.Action))
        //    {
        //        Console.Out.WriteLine("Something happened");
        //    }
        //    else
        //    {
        //        Console.Out.WriteLine("Something happened Not");
        //    }
        //}
    }
}