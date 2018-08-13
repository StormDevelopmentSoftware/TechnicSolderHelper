using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TechnicSolderHelper
{
	public static class Utilities
	{
		public static string GenerateSlug(this string text)
		{
			var slug = text.RemoveAccent();
			slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
			slug = Regex.Replace(slug, @"\s+", " ").Trim();
			slug = Regex.Replace(slug, @"\s", "-");

			if (slug.Length >= 45)
				slug = slug.Substring(0, 45);

			return slug.ToLowerInvariant();
		}

		public static string RemoveAccent(this string text)
		{
			byte[] buffer = Encoding
				.GetEncoding("Cyrillic")
				.GetBytes(text);

			return Encoding.ASCII.GetString(buffer);
		}
	}
}
