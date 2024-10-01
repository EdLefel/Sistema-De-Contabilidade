namespace Services.GlobalVars{
    public class AppState
    {
        public string GlobalUrl { get; set;} = "http://localhost:5200/";
        public static string UserName { get; set;}
    }

    // no Proggram.cs: services.AddSingleton<AppState>();

    // private readonly AppState _appState;
}