
#if IOS || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiTextField;
using UIKit;
#elif ANDROID
using PlatformView = AndroidX.AppCompat.Widget.AppCompatEditText;
using Android.Graphics.Drawables;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Android.Views;
using Android.Content;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.TextBox;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using PlatformView = System.Object;
#endif
using Microsoft.Maui.Handlers;
using System;
using TestMauiApp.Views.Controls;
using System.Runtime.InteropServices;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Controls;
namespace TestMauiApp.Handlers
{
    public partial class CustomEntryHandler : EntryHandler
    {

        private static readonly IPropertyMapper<MainEntry, CustomEntryHandler> PropertyMapper = new PropertyMapper<MainEntry, CustomEntryHandler>(Mapper)
        {
            [nameof(MainEntry.BorderColor)] = MapText,

        };

        public CustomEntryHandler() : base(PropertyMapper)
        {
        }

        protected override void ConnectHandler(PlatformView platformView)
        {


            base.ConnectHandler(platformView);
        }
        protected override void DisconnectHandler(PlatformView platformView)
        {
            base.DisconnectHandler(platformView);
        }

        private static void MapText(CustomEntryHandler handler, MainEntry entry)
        {


#if IOS

                        handler.PlatformView.Layer.BorderColor = ((MainEntry)entry).BorderColor.ToCGColor();
                        handler.PlatformView.Layer.BorderWidth = new NFloat(0.8);
                        handler.PlatformView.Layer.CornerRadius = 15;

#elif ANDROID


            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(15);

            if (entry.IsBorderErrorVisible)
                shape.SetStroke(3, (entry).BorderColor.ToAndroid());
            else
                shape.SetStroke(3, (entry.BorderColor.ToAndroid()));

            handler.PlatformView.Background = shape;




#endif
        }


    }
}
