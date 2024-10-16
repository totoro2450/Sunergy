using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Classes
{
    public class GetGoogleMapLocationsRequest(string input, string inputType = "textquery")
    {
        public string Input { get; set; } = input;
        public string Inputtype { get; set; } = inputType;
    }
}
