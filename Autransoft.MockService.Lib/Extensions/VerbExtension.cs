using Autransoft.MockService.Lib.Enums;

namespace Autransoft.MockService.Lib.Extensions
{
    internal static class VerbExtension
    {
        internal static string Method(this Verbs verb)
        {
            var method = string.Empty;

            switch(verb)
            {
                case Verbs.Delete:
                    method = "Delete";
                    break;
                case Verbs.Post:
                    method = "Post";
                    break;
                case Verbs.Put:
                    method = "Put";
                    break;
                case Verbs.Get:
                    method = "Get";
                    break;
                case Verbs.Patch:
                    method = "Patch";
                    break;
            }

            return method;
        }
    }
}