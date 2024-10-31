﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMauiApp.Views.Controls
{
    public class MainEntry : Entry
    {

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MainEntry), default(Color));
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(MainEntry), default(float));
        public float BorderWidth
        {
            get => (float)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(MainEntry), default(float));
        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly BindableProperty LeftPaddingProperty =
            BindableProperty.Create(nameof(LeftPadding), typeof(float), typeof(MainEntry), 8.0f);
        public float LeftPadding
        {
            get => (float)GetValue(LeftPaddingProperty);
            set => SetValue(LeftPaddingProperty, value);
        }

        public static readonly BindableProperty RightPaddingProperty =
            BindableProperty.Create(nameof(RightPadding), typeof(float), typeof(MainEntry), 8.0f);
        public float RightPadding
        {
            get => (float)GetValue(RightPaddingProperty);
            set => SetValue(RightPaddingProperty, value);
        }

        public static readonly BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(MainEntry), default(bool));
        public bool HasShadow
        {
            get => (bool)GetValue(HasShadowProperty);
            set => SetValue(HasShadowProperty, value);
        }

        /*
         * There is a bug on Xamarin.Forms EntryRenderer where the view background color stays on all of the view's
         * area even if we set a rounded corner, so we can always see the sharp corners underneath.
         * So we set "BackgroundColor" to transparent and use EntryBackgroundColor as our real background color.
         */
        public static readonly BindableProperty EntryBackgroundColorProperty =
            BindableProperty.Create(nameof(EntryBackgroundColor), typeof(Color), typeof(MainEntry), default(Color));
        public Color EntryBackgroundColor
        {
            get => (Color)GetValue(EntryBackgroundColorProperty);
            set
            {
                SetValue(EntryBackgroundColorProperty, value);
                BackgroundColor = Colors.Transparent;
            }
        }

        public static readonly BindableProperty IsBorderErrorVisibleProperty =
            BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(MainEntry), default(bool));
        public bool IsBorderErrorVisible
        {
            get => (bool)GetValue(IsBorderErrorVisibleProperty);
            set => SetValue(IsBorderErrorVisibleProperty, value);
        }

        public static readonly BindableProperty ErrorTextProperty =
            BindableProperty.Create(nameof(ErrorText), typeof(bool), typeof(MainEntry), default(bool));
        public bool ErrorText
        {
            get => (bool)GetValue(ErrorTextProperty);
            set => SetValue(ErrorTextProperty, value);
        }

    }
}
