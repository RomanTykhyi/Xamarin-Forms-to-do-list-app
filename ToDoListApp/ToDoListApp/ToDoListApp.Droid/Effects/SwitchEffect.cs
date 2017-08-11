using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Widget;
using ToDoListApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(SwitchEffect), "SwitchEffect")]

namespace ToDoListApp.Droid.Effects
{
    public class SwitchEffect : PlatformEffect
    {        
        protected override void OnAttached()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
            {
                _trueColor = (Xamarin.Forms.Color)Element.GetValue(ToDoListApp.Effects.SwitchColorEffect.TrueColorProperty);
                _falseColor = (Xamarin.Forms.Color)Element.GetValue(ToDoListApp.Effects.SwitchColorEffect.FalseColorProperty);

                if (((SwitchCompat)Control).Checked)
                {
                    ((SwitchCompat)Control).TrackDrawable.SetColorFilter(Xamarin.Forms.Color.Silver.ToAndroid(), PorterDuff.Mode.Multiply);

                    ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(_trueColor.ToAndroid(), PorterDuff.Mode.Multiply);
                }
                else
                {
                    ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(_falseColor.ToAndroid(), PorterDuff.Mode.Multiply);
                }
            }
            
            ((Xamarin.Forms.Switch)Element).Toggled += OnCheckedChange;            
        }

        private void OnCheckedChange(object sender, ToggledEventArgs checkedChangeEventArgs)
        {
            if (checkedChangeEventArgs.Value)
            {
                ((SwitchCompat)Control).TrackDrawable.SetColorFilter(Xamarin.Forms.Color.Silver.ToAndroid(), PorterDuff.Mode.Multiply);
            
                // to change the colour of the thumb-drawable to the 'true' (or false) colour, enable the line below
                ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(_trueColor.ToAndroid(), PorterDuff.Mode.Multiply);
            }
            else
            {
                //((SwitchCompat)Control).TrackDrawable.SetColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.Multiply);
                // to change the colour of the thumb-drawable to the 'true' (or false) colour, enable the line below
                ((SwitchCompat)Control).ThumbDrawable.SetColorFilter(_falseColor.ToAndroid(), PorterDuff.Mode.Multiply);
            }
        }

        protected override void OnDetached()
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
            {
                ((Xamarin.Forms.Switch)Element).Toggled -= OnCheckedChange;
            }
        }

        private Xamarin.Forms.Color _trueColor;
        private Xamarin.Forms.Color _falseColor;
    }
}