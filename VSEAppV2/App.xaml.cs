﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using VSEAppV2.Services;
using VSEAppV2.ViewModels;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace VSEAppV2
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            //this.HttpClient.Timeout = TimeSpan.FromSeconds(5);

            this.ConfigureServices();
            this.RequestedTheme = ApplicationTheme.Dark;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
        public HttpClient HttpClient = new HttpClient(); 

        public void ConfigureServices()
        {
            Ioc.Default.ConfigureServices(new ServiceCollection()
                .AddSingleton<IAPIHelperService, APIHelperService>()
                .AddSingleton<IAppState, AppState>()
                .AddTransient<MainWindowViewModel>()
                .AddTransient<SignUpFormViewModel>()
                .AddTransient<LoginFormViewModel>()
                .AddTransient<LoggedInViewModel>()
                .AddTransient<EditUserFormViewModel>()

                .AddTransient<VSEValuesPageViewModel>()
                .AddTransient<VSEValueCreateUpdateFormViewModel>()
                .AddTransient<VSEValueCreateMultipleFormViewModel>()
                .AddTransient<VSEValueDeleteFormViewModel>()

                .AddTransient<VSESkillsPageViewModel>()
                .AddTransient<VSESkillCreateUpdateFormViewModel>()
                .AddTransient<VSESkillCreateMultipleFormViewModel>()
                .AddTransient<VSESkillDeleteFormViewModel>()

                .AddTransient<VSEExperiencesPageViewModel>()
                .AddTransient<VSEExperienceCreateUpdateFormViewModel>()
                .AddTransient<VSEExperienceCreateMultipleFormViewModel>()
                .AddTransient<VSEExperienceDeleteFormViewModel>()

                .BuildServiceProvider());
        }
    }
}
