﻿using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace zuzudemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();

            Firebase.Core.App.Configure();

            LoadApplication(new App(new IosInitializer()));

            return base.FinishedLaunching(app, options);
        }

        public class IosInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {

            }
        }
    }
}