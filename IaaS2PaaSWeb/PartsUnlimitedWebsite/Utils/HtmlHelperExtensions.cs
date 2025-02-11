using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;

namespace PartsUnlimited.Utils
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent Image(this IHtmlHelper helper, string src, string alt = null)
        {
            if (string.IsNullOrWhiteSpace(src))
            {
                throw new ArgumentOutOfRangeException(nameof(src), src, "Must not be null or whitespace");
            }

            var img = new TagBuilder("img");

            img.MergeAttribute("src", GetCdnSource(src));

            if (!string.IsNullOrWhiteSpace(alt))
            {
                img.MergeAttribute("alt", alt);
            }

using (var writer = new StringWriter())
            {
                img.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                return new HtmlString(writer.ToString());
            }
        }

        private static string GetCdnSource(string src)
        {
            return string.Format("{0}/{1}", ConfigurationHelpers.GetString("ImagePath"), src);
        }
    }
}