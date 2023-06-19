namespace GeographyStracture.Data
{
    public class DataConstraints
    {
        public class Continent
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 20;

            public const int MaxUrlLength = 200;
        }

        public class Country
        {
            public const int MaxCountryNameLength = 20;
            public const int MinCountryNameLength = 2;

            public const int MaxUrlLength = 200;
        }

        public class City
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 30;

            public const int MaxUrlLength = 200;
        }

        public class Desert
        {
            public const int MinNameLength = 3; 
            public const int MaxNameLength = 50;
        }

    }
}
