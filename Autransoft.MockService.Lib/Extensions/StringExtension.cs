namespace Autransoft.MockService.Lib.Extensions
{
    internal static class StringExtension
    {
        internal static string CutFirstCaracterWithSlash(this string path)
        {
            if (!string.IsNullOrEmpty(path) && path[..1] == "/")
                path = path[1..];

            return path;
        }
    }
}