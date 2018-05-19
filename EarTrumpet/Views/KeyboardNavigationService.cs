﻿using EarTrumpet.Extensions;
using EarTrumpet.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EarTrumpet.Views
{
    public class KeyboardNavigationService
    {
        public static void OnKeyDown(FrameworkElement host, ref KeyEventArgs evt)
        {
            var focused = FocusManager.GetFocusedElement(host);
            var listItem = focused as ListViewItem;

            if (listItem != null)
            {
                var app = listItem.DataContext as AppItemViewModel;

                if (app != null)
                {
                    switch (evt.Key)
                    {
                        case Key.OemPeriod:
                            app.IsMuted = !app.IsMuted;
                            evt.Handled = true;
                            break;
                        case Key.Right:
                        case Key.OemPlus:
                            app.Volume++;
                            evt.Handled = true;
                            break;
                        case Key.Left:
                        case Key.OemMinus:
                            app.Volume--;
                            evt.Handled = true;
                            break;
                        case Key.Space:
                            var volControl = listItem.FindVisualChild<AppVolumeControl>();
                            volControl.ExpandApp();
                            evt.Handled = true;
                            break;
                    }
                }
                else
                {
                    var device = ((DeviceAndAppsControl)listItem.DataContext).Device;
                    switch (evt.Key)
                    {
                        case Key.OemPeriod:
                            device.IsMuted = !device.IsMuted;
                            evt.Handled = true;
                            break;
                        case Key.Right:
                        case Key.OemPlus:
                            device.Volume++;
                            evt.Handled = true;
                            break;
                        case Key.Left:
                        case Key.OemMinus:
                            device.Volume--;
                            evt.Handled = true;
                            break;
                    }
                }
            }
        }
    }
}