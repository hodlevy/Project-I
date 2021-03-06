﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for SettingsWin.xaml
    /// </summary>
    public partial class SettingsWin : Window
    {
        public SettingsWin()
        {
            InitializeComponent();
        }

        private void checkBoxHE_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxEN.IsChecked = false;
            checkBoxCH.IsChecked = false;
            Uri dictUri = new Uri(@"/res/languages/AppStrings_HE.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void checkBoxEN_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxHE.IsChecked = false;
            checkBoxCH.IsChecked = false;
            Uri dictUri = new Uri(@"/res/languages/AppStrings_EN.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void checkBoxCH_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxHE.IsChecked = false;
            checkBoxEN.IsChecked = false;
            Uri dictUri = new Uri(@"/res/languages/AppStrings_CH.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(dictUri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are You Sure?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                GetBL.bl.Reset();
                MessageBox.Show("Mission Complete!", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (result == MessageBoxResult.No) 
            {
                MessageBox.Show("Mission Complete!\nAll The Data Was Deleted.", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("Just KIDDING! :D", "HaHaHa", MessageBoxButton.OK);
            }
        }
    }
}