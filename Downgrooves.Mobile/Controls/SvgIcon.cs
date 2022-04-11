using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Downgrooves.Mobile.Controls
{
    public class SvgIcon : Frame
    {
        private const string StringToReplace = "<path ";
        private readonly SvgCachedImage _icon;

        public enum IconPositionType
        {
            Top,
            Right,
            Bottom,
            Left
        }

        public SvgIcon()
        {
            Background = Color.Transparent;

            _icon = new SvgCachedImage()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Aspect = Aspect.AspectFit,
                BackgroundColor = Color.Transparent,
                ReplaceStringMap = new Dictionary<string, string>()
                {
                    {StringToReplace, $"{StringToReplace} fill=\"#FFFFFF\" "}
                }
            };

            _icon.SetBinding(WidthRequestProperty, new Binding(nameof(IconSize), source: this));
            _icon.SetBinding(HeightRequestProperty, new Binding(nameof(IconSize), source: this));

            Padding = 0;
            Margin = 0;
            Content = _icon;
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(SvgIcon),
                defaultValue: Color.Black,
                propertyChanged: (bindable, value, newValue) =>
                {
                    if (!(bindable is SvgIcon control)) return;
                    if (!(newValue is Color color)) return;

                    control._icon.ReplaceStringMap[StringToReplace] =
                        $"{StringToReplace} fill=\"#{(int)(color.R * 255):X2}{(int)(color.G * 255):X2}{(int)(color.B * 255):X2}\" ";
                    if (control._icon.IsVisible)
                    {
                        control._icon.Source = ImageSource.FromUri(new Uri(control.Icon.ResourceId));
                    }
                });

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(Icon), typeof(SvgIcon),
                propertyChanged: (bindable, value, newValue) =>
                {
                    if (!(bindable is SvgIcon control)) return;
                    if (newValue is Icon icon)
                    {
                        control._icon.Source = ImageSource.FromUri(new Uri(icon.ResourceId));
                        control._icon.IsVisible = true;
                    }
                    else
                    {
                        control._icon.IsVisible = false;
                    }
                });

        public Icon Icon
        {
            get => (Icon)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create(nameof(IconSize), typeof(double), typeof(SvgIcon), defaultValue: 30d);

        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create(nameof(Spacing), typeof(double), typeof(SvgIcon), defaultValue: 5d);

        public double Spacing
        {
            get => (double)GetValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }
    }

    public class Icon
    {
        public static readonly Icon AngleLeft = new Icon("angle-left.svg");
        public static readonly Icon CompactDisc = new Icon("compact-disc.svg");
        public static readonly Icon Ellipsis = new Icon("ellipsis.svg");
        public static readonly Icon Envelope = new Icon("envelope.svg");
        public static readonly Icon Headphones = new Icon("headphones.svg");
        public static readonly Icon Heart = new Icon("heart.svg");
        public static readonly Icon HeartOutline = new Icon("heart-o.svg");
        public static readonly Icon Music = new Icon("music.svg");
        public static readonly Icon Pause = new Icon("pause.svg");
        public static readonly Icon Play = new Icon("play.svg");
        public static readonly Icon RecordVinyl = new Icon("record-vinyl.svg");
        public static readonly Icon Spinner = new Icon("spinner.svg");
        public static readonly Icon Stop = new Icon("stop.svg");
        public static readonly Icon VolumeHigh = new Icon("volume-high.svg");
        public static readonly Icon VolumeLow = new Icon("volume-low.svg");
        public static readonly Icon VolumeOff = new Icon("volume-off.svg");

        public Icon(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; set; }
        public string ResourceId => $"resource://Downgrooves.Mobile.Resources.svg.{FileName}";
    }
}