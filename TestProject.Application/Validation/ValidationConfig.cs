namespace TestProject.Application.Validation
{
    public static class ValidationConfig
    {
        public readonly static string[] AllowedImageExtensions = new string[] { ".jpg", ".png" };

        public const string PersonalNumberPattern = @"^(\d{11})$";

        public const string PersonalNumberFilterPattern = @"^(\d{1,11})$";

        public const string OnlyGeoOrLatFilterPattern = @"^[A-Za-z]{1,50}$|^[\u10D0-\u10F0]{1,50}$";

        public const string PhoneNumberPattern = @"^(\d{4,50})$";

        public const string PhoneNumberFilterPattern = @"^(\d{1,50})$";

        public const string CityNamePattern = @"^[A-Za-z]{2,50}$";

        public const string CityNameFilterPattern = @"^[A-Za-z]{1,50}$";

        public const string IntegerPattern = @"^[1-9]\d*$";

        public const string FastSearchValuePattern = @"^[(0-9)]{1,11}$|^[A-Za-z]{1,50}$|^[\u10D0-\u10F0]{1,50}$";
        
        public const string OnlyGeoOrLatPattern = @"^[A-Za-z]{2,50}$|^[\u10D0-\u10F0]{2,50}$";

        public const int MinimumAge = 18;

        public const int MinimumPhoneNumbers = 1;

        public const int MaximumPhoneNumbers = 3;

        public const int MaximumFileSize = 5 * 1024 * 1024;
    }
}
