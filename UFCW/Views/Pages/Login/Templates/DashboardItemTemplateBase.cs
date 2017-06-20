﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UFCW
{
	public abstract class DashboardItemTemplateBase : ContentView
	{
		public uint animationDuration = 250;
		public bool _processingTag = false;

		public static readonly BindableProperty ShowBackgroundImageProperty =
			BindableProperty.Create(
				nameof(ShowBackgroundImage),
				typeof(bool),
				typeof(DashboardItemTemplate),
				true,
				defaultBindingMode: BindingMode.OneWay
			);

		public bool ShowBackgroundImage
		{
			get { return (bool)GetValue(ShowBackgroundImageProperty); }
			set { SetValue(ShowBackgroundImageProperty, value); }
		}

		public static readonly BindableProperty ShowBackgroundColorProperty =
			BindableProperty.Create(
				nameof(ShowBackgroundColor),
				typeof(bool),
				typeof(DashboardItemTemplate),
				false,
				defaultBindingMode: BindingMode.OneWay
			);

		public bool ShowBackgroundColor
		{
			get { return (bool)GetValue(ShowBackgroundColorProperty); }
			set { SetValue(ShowBackgroundColorProperty, value); }
		}

		public static readonly BindableProperty ShowiconColoredCircleBackgroundProperty =
			BindableProperty.Create(
				nameof(ShowiconColoredCircleBackground),
				typeof(bool),
				typeof(DashboardItemTemplate),
				true,
				defaultBindingMode: BindingMode.OneWay
			); 
        public static readonly BindableProperty ShowiconBadgeProperty =
			 BindableProperty.Create(
				 nameof(ShowiconBadge),
				 typeof(bool),
				 typeof(DashboardItemTemplate),
				 true,
				 defaultBindingMode: BindingMode.OneWay
			 );

		public bool ShowiconColoredCircleBackground
		{
			get { return (bool)GetValue(ShowiconColoredCircleBackgroundProperty); }
			set { SetValue(ShowiconColoredCircleBackgroundProperty, value); }
		}

		public bool ShowiconBadge
		{
            get { return (bool)GetValue(ShowiconBadgeProperty); }
			set { SetValue(ShowiconBadgeProperty, value); }
		}

		public static readonly BindableProperty TextColorProperty =
			BindableProperty.Create(
				nameof(TextColor),
				typeof(Color),
				typeof(DashboardItemTemplate),
				defaultValue: Color.White,
				defaultBindingMode: BindingMode.OneWay
			);

		public Color TextColor
		{
			get { return (Color)GetValue(TextColorProperty); }
			set { SetValue(TextColorProperty, value); }
		}

		public async void OnWidgetTapped(object sender, EventArgs e)
		{
			if (_processingTag)
			{
				return;
			}
            SampleCategory scatagory = (SampleCategory)BindingContext;
			_processingTag = true;

			try
			{
				await AnimateItem(this, animationDuration);
                await Navigation.PushAsync(scatagory.page);
			}
			finally
			{
				_processingTag = false;
			}
		}

		private async Task AnimateItem(View uiElement, uint duration)
		{
			var originalOpacity = uiElement.Opacity;

			await uiElement.FadeTo(.5, duration / 2, Easing.CubicIn);
			await uiElement.FadeTo(originalOpacity, duration / 2, Easing.CubicIn);

		}
	}
}
