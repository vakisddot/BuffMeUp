namespace BuffMeUp.Backend.Common;

public static class Endpoints
{
    public const string FrontendPort = "25565";

    public static readonly string[] FrontendEndpoints = new[] 
    { 
        "http://localhost", 
        "https://localhost",
        "http://172.16.1.110",
        "https://172.16.1.110",
        "http://77.78.55.50", 
        "https://77.78.55.50",
    };
}
