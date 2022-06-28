using System;
using System.Globalization;
namespace Los_Pollos_Hermanos.Helpers.Models
{
    public class ApiException : Exception
    {
        public ApiException() :base()
        {
        
        }
        public ApiException(string message) 
        {

        }
        public ApiException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
                
        }
    }
}
