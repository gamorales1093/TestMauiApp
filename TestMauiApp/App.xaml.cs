#if ANDROID
using Android.Graphics.Drawables;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Android.Content;
#endif
using System.Runtime.InteropServices;
using TestMauiApp.Handlers;
using TestMauiApp.Views;
using TestMauiApp.Views.Controls;
namespace TestMauiApp;
#if IOS
using CoreGraphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using UIKit;
#endif
public partial class App : Application
{

    public App(LoginPage loginPage)
    {
        InitializeComponent();
        InicializeRenderEntry();
        ChangeThemelight();
        Current.RequestedThemeChanged += (s, a) =>
        {
            if (Current.UserAppTheme != AppTheme.Light)
            {
                ChangeThemelight();
            }
        };
        var logged = Preferences.Get("logged", string.Empty);
        if (string.IsNullOrEmpty(logged))
        {
            MainPage = loginPage;
        }
        else
        {
            MainPage = new AppShell();
        }


    }
    private void ChangeThemelight()
    {
        Current.UserAppTheme = AppTheme.Light;
    }

    public void InicializeRenderEntry()
    {


        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(IEntry.Background), (handler, entry) =>
        {
            if (entry is MainEntry)
            {
                var backgroundColor = ((MainEntry)entry).EntryBackgroundColor;
                var borderColor = ((MainEntry)entry).BorderColor;
                var borderWidth = ((MainEntry)entry).BorderWidth;
                var cornerRadius = ((MainEntry)entry).CornerRadius;

#if ANDROID


                borderWidth = borderWidth > 0 ? borderWidth : 0;
                cornerRadius = cornerRadius > 0 ? cornerRadius : 0;

                var strokeWidth = 3;
                var radius = 15;

                var background = new GradientDrawable();
                background.SetColor(backgroundColor.ToAndroid());

                if (radius > 0)
                {
                    background.SetCornerRadius(radius);
                }
                if (strokeWidth > 0)
                {
                    background.SetStroke(strokeWidth, borderColor.ToAndroid());
                }


                if (((MainEntry)entry).HasShadow)
                {
                    var shadowColors = new int[] {
                    -1,
                    0856918
                };
                    var shadow = new GradientDrawable(GradientDrawable.Orientation.TopBottom, shadowColors);
                    shadow.SetCornerRadius(radius);

                    int inset = strokeWidth / 2;
                    var drawables = new Drawable[] { shadow, background };
                    var layer = new LayerDrawable(drawables);
                    layer.SetLayerInset(0, 0, 0, 0, 0);
                    layer.SetLayerInset(1, inset, strokeWidth, inset, strokeWidth);

                    handler.PlatformView.Background = layer;
                }
                else
                {
                    handler.PlatformView.Background = background;
                }
                handler.PlatformView.SetPadding(50, 0, 20, 0);

                GradientDrawable shape = new GradientDrawable();
                shape.SetShape(ShapeType.Rectangle);
                shape.SetCornerRadius(15);




#elif IOS
                if (borderColor.Red == 0 && borderColor.Green == 0 && borderColor.Blue == 0 && borderColor.Alpha == 0)
                {
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                }
                else
                {

                    handler.PlatformView.Layer.BorderColor = ((MainEntry)entry).BorderColor.ToCGColor();
                    handler.PlatformView.Layer.BorderWidth = new NFloat(1);
                    handler.PlatformView.Layer.CornerRadius = 15;
                }

                //if (!string.IsNullOrWhiteSpace(((MainEntry)entry).Placeholder))
                  //  handler.PlatformView.Text = ((MainEntry)entry).Placeholder;

                handler.PlatformView.LeftView = new UIView(new CGRect(0, 0, ((MainEntry)entry).LeftPadding, 0));
                handler.PlatformView.LeftViewMode = UITextFieldViewMode.Always;
                handler.PlatformView.ShouldEndEditing += (textField) =>
                {
                    var seletedDate = (UITextField)textField;
                    var text = seletedDate.Text;

                   // if (text == ((MainEntry)entry).Placeholder)
                     //   handler.PlatformView.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    if (borderColor.Red == 0 && borderColor.Green == 0 && borderColor.Blue == 0 && borderColor.Alpha == 0)
                    {
                        handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                    }
                    else
                    {

                        handler.PlatformView.Layer.BorderColor = ((MainEntry)entry).BorderColor.ToCGColor();
                        handler.PlatformView.Layer.BorderWidth = new NFloat(1);
                        handler.PlatformView.Layer.CornerRadius = 15;
                    }

                    return true;
                };


#elif WINDOWS
                //
#endif

            }
        });


    }
}
