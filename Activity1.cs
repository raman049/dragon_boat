﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Android.OS;

using Microsoft.Xna.Framework;

namespace com.dragon_boat.Droid
{
	[Activity(Label = "com.dragon_boat.Droid",
			   MainLauncher = true,
			   Icon = "@drawable/icon",
			   Theme = "@style/Theme.Splash",
				AlwaysRetainTaskState = true,
		   ScreenOrientation = ScreenOrientation.Portrait,
			   LaunchMode = LaunchMode.SingleInstance,
			   ConfigurationChanges = ConfigChanges.Orientation |
									  ConfigChanges.KeyboardHidden |
									  ConfigChanges.Keyboard)]
	public class Activity1 : AndroidGameActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create our OpenGL view, and display it
			//Game1.Activity = this;
			//var g = new Game1();
			//SetContentView(g.Window);
			//g.Run();
	var g = new Game1();

	SetContentView((View)g.Services.GetService(typeof(View)));
    g.Run();
		}

	}
}

