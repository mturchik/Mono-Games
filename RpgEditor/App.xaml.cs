﻿namespace RpgEditor;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        if (window != null) window.Title = "RPG Editor";

        return window;
    }
}
