﻿/*
 Licensed to the Apache Software Foundation (ASF) under one
 or more contributor license agreements.  See the NOTICE file
 distributed with this work for additional information
 regarding copyright ownership.  The ASF licenses this file
 to you under the Apache License, Version 2.0 (the
 "License"); you may not use this file except in compliance
 with the License.  You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing,
 software distributed under the License is distributed on an
 "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 KIND, either express or implied.  See the License for the
 specific language governing permissions and limitations
 under the License. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Navigation;
using System.Collections;


namespace $safeprojectname$
{
    public partial class MainPage : PhoneApplicationPage
    {
        string path;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.CordovaView.Loaded += CordovaView_Loaded;
            this.CordovaView.Browser.LoadCompleted += LoadCompletedEventHandler;
        }

        private void LoadCompletedEventHandler(object sender, NavigationEventArgs e)
        {
            try
            {
                if (path != null)
                {
                    this.CordovaView.CordovaBrowser.InvokeScript("handleOpenURL", new string[] {path});
                }
            }
            catch (Exception /*ex*/)
            {
                System.Diagnostics.Debug.WriteLine("ERROR OPENURL.");
            }
        }

        private void CordovaView_Loaded(object sender, RoutedEventArgs e)
        {
            this.CordovaView.Loaded -= CordovaView_Loaded;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            IDictionary<string, string> queryString = this.NavigationContext.QueryString;
            if (queryString.ContainsKey("url"))
            {
                path = queryString["url"].ToString();
            }
        }


    }
}
