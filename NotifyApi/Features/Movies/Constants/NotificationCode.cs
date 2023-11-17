namespace NotifyApi.Features.Movies.Constants
{
    public static class NotificationCode
    {
        public const long MovieNotFound = 10000;
        public const long CantRemoveUnregisteredMovie = 20000;
        public const long InvalidMovieIdentifier = 30000;
        public const long TitleCantBeNullOrEmpty = 40000;
    }
}
