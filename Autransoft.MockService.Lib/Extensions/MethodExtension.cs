using Autransoft.MockService.Lib.Enums;

namespace Autransoft.MockService.Lib.Extensions
{
    internal static class MethodExtension
    {
        internal static string Method(this Methods verb)
        {
            var method = string.Empty;

            switch(verb)
            {
                case Methods.Delete:
                    method = "Delete";
                    break;
                case Methods.Post:
                    method = "Post";
                    break;
                case Methods.Put:
                    method = "Put";
                    break;
                case Methods.Get:
                    method = "Get";
                    break;
                case Methods.Patch:
                    method = "Patch";
                    break;
            }

            return method;
        }
    }
}