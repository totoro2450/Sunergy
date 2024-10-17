namespace BlazorApp.Shared.Classes
{
    public class GetGoogleMapLocationsRequest(string input, string inputType = "textquery")
    {
        public string Input { get; set; } = input;
        public string Inputtype { get; set; } = inputType;
    }
}
