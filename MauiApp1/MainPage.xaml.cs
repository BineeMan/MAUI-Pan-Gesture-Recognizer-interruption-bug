

using Microsoft.Maui.Controls.Shapes;
using System;
using System.Diagnostics;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        /////
	}

    double x, y;
    private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
		Rectangle rect = (Rectangle)sender;
		switch (e.StatusType)
		{
			case GestureStatus.Started:
				Debug.WriteLine("GestureStatus.Started");
				break;
			case GestureStatus.Running:
#if ANDROID
                x = rect.TranslationX + e.TotalX;
                y = rect.TranslationY + e.TotalY;
#endif
#if WINDOWS
                x = e.TotalX;
                y = e.TotalY;
#endif
                rect.TranslationX = x;
                rect.TranslationY = y;
				break;
			case GestureStatus.Canceled:
                Debug.WriteLine("GestureStatus.Canceled");
                break;
            case GestureStatus.Completed:
                Debug.WriteLine("GestureStatus.Canceled");
                break;
        }
    }
}

