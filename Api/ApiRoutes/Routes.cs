namespace Api.ApiRoutes
{
    public static class Routes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;




        public static class General
        {
            public const string RootPath = Base + "/RootPath";
            public const string Test = Base + "/Test";
        }

    }
}
