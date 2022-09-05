using System;
using System.Collections.Generic;
using SkiaSharp;
using Xamarin.Forms;

namespace BudgetApp.Controls
{
    public partial class PercentView : ContentView
    {
        public PercentView()
        {
            InitializeComponent();
        }

        SKPath path=new SKPath()

        #region Bindable Properties

        public static BindableProperty ValueProperty = BindableProperty.Create(
                                                        propertyName: nameof(Value),
                                                        returnType: typeof(double),
                                                        declaringType: typeof(PercentView),
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: OnValueChanged);

        public static BindableProperty FontSizeProperty = BindableProperty.Create(
                                                        propertyName: nameof(FontSize),
                                                        returnType: typeof(double),
                                                        declaringType: typeof(PercentView),
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: OnFontSizeChanged);

        public static BindableProperty FontFamilyProperty = BindableProperty.Create(
                                                        propertyName: nameof(FontFamily),
                                                        returnType: typeof(string),
                                                        declaringType: typeof(PercentView),
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: OnFontFamilyChanged);

        public static BindableProperty ColorProperty = BindableProperty.Create(
                                                        propertyName: nameof(Color),
                                                        returnType: typeof(Color),
                                                        declaringType: typeof(PercentView),
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: OnColorChanged);

        public static BindableProperty TextColorProperty = BindableProperty.Create(
                                                        propertyName: nameof(TextColor),
                                                        returnType: typeof(Color),
                                                        declaringType: typeof(PercentView),
                                                        defaultBindingMode: BindingMode.TwoWay,
                                                        propertyChanged: OnTextColorChanged);
        #endregion

        #region Property Changed
        private static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((PercentView)bindable).Value = (double)newValue;
            ((PercentView)bindable).animText.Text = $"{((double)newValue).ToString("0")}%";
        }

        private static void OnFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((PercentView)bindable).FontSize = (double)newValue;
            ((PercentView)bindable).animText.FontSize = (double)newValue;
        }

        private static void OnFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((PercentView)bindable).FontFamily = (string)newValue;
            ((PercentView)bindable).animText.FontFamily = (string)newValue;
        }

        private static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var val = (Color)newValue;
            ((PercentView)bindable).Color = val;
        }

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var val = (Color)newValue;
            ((PercentView)bindable).TextColor = val;
            ((PercentView)bindable).animText.TextColor = val;
        }
        #endregion

        #region Properties

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
                OnPropertyChanged();
            }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set
            {
                SetValue(FontSizeProperty, value);
                OnPropertyChanged();
            }
        }

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set
            {
                SetValue(FontFamilyProperty, value);
                OnPropertyChanged();
            }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set
            {
                SetValue(ColorProperty, value);
                OnPropertyChanged();
            }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set
            {
                SetValue(TextColorProperty, value);
                OnPropertyChanged();
            }
        }

        #endregion

        void CanvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;

            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            SKPaint strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColor.Parse(Color.ToHex()),
                StrokeWidth = 10,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
            };

            SKPaint bgPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Transparent,
                StrokeWidth = 10,
                IsAntialias = true
            };

            SKPaint outlinePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.LightGray,
                StrokeWidth = 10,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
            };

            canvas.Clear();

            SKRect rect = new SKRect(10, 10, info.Width - 10, info.Height - 10);
            SKRect bgRect = new SKRect(10, 10, info.Width - 15, info.Height - 15);

            //Draw Transparent Background
            canvas.DrawOval(bgRect, bgPaint);
            //Draw Gray Outline
            canvas.DrawOval(rect, outlinePaint);

            //Draw Progress Arc
            var arc = (float)(Value / 100) * 360;
            path.ArcTo(rect, -90, arc, true);
            canvas.DrawPath(path, strokePaint);

            canvas.Save();
        }
    }
}

