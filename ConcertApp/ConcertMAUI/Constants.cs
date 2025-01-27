namespace ConcertMAUI
{
    public static class Constants
    {
        public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "https"; // or http
        public static string Port = "7254";

        // Dynamisk RestUrl metod för att hantera olika endpoints
        public static string RestUrl(string endpoint, string id)
        {
            return $"{Scheme}://{LocalhostUrl}:{Port}/api/{endpoint}/{id}";
        }
    }
}
