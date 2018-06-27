using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Http;
using RemoteFork.Settings;

namespace RemoteFork.Tools {
    public static class Tools {
        #region CheckAccess

        //public static bool CheckAccessPath(DirectoryInfo directory) {
        //    return !CheckHiddenFile(directory.Attributes) && CheckAccessPath(directory.FullName);
        //}

        //public static bool CheckAccessPath(FileInfo file) {
        //    return !CheckHiddenFile(file.Attributes) && CheckAccessPath(file.FullName);
        //}

        public static bool CheckAccessPath(string file) {
            bool result = ProgramSettings.Settings.Dlna;
            if (!result) {
                return false;
            }

            file = Path.GetFullPath(file);

            if (ProgramSettings.Settings.DlnaDirectories != null) {
                var filter = new List<string>(ProgramSettings.Settings.DlnaDirectories);
                switch (ProgramSettings.Settings.DlnaFilterType) {
                    case FilterMode.INCLUSION:
                        if (filter.All(i => !file.StartsWith(i, StringComparison.OrdinalIgnoreCase))) {
                            result = false;
                        }
                        break;
                    case FilterMode.EXCLUSION:
                        if (filter.Any(file.StartsWith)) {
                            result = false;
                        }
                        break;
                }
            }

            if (File.Exists(file)) {
                if ((ProgramSettings.Settings.DlnaFileExtensions != null) &&
                    (ProgramSettings.Settings.DlnaFileExtensions.Length > 0)) {
                    result = ProgramSettings.Settings.DlnaFileExtensions.Any(file.EndsWith);
                }
            }

            return result;
        }

        //public static bool CheckHiddenFile(FileAttributes attributes) {
        //    return !ProgramSettings.Settings.DlnaHiidenFiles &&
        //           (((attributes & FileAttributes.Hidden) == FileAttributes.Hidden) ||
        //            ((attributes & FileAttributes.System) == FileAttributes.System));
        //}

        #endregion CheckAccess

        public static IPAddress[] GetIPAddresses() {
            //return new IPAddress[0];

            return NetworkInterface.GetAllNetworkInterfaces()
                .SelectMany(i => i.GetIPProperties().UnicastAddresses)
                .Select(a => a.Address)
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                .ToArray();
        }

        public static string FSize(long len) {
            float num = len;
            string str = "Байт";
            bool flag = num > 102f;
            if (flag) {
                num /= 1024f;
                str = "КБ";
            }
            bool flag2 = num > 102f;
            if (flag2) {
                num /= 1024f;
                str = "МБ";
            }
            bool flag3 = num > 102f;
            if (flag3) {
                num /= 1024f;
                str = "ГБ";
            }
            return Math.Round(num, 2) + str;
        }

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T> {
            if (val.CompareTo(min) < 0) return min;
            return val.CompareTo(max) > 0 ? max : val;
        }

        public static string ReplaceHexadecimalSymbols(this string text) {
            const string r = "[\x00-\x08\x0B\x0C\x0E-\x1F\x26]";
            return Regex.Replace(text, r, "", RegexOptions.Compiled);
        }

        public static string ReplaceUnicodeSymbols(this string text) {
            return Regex.Replace(text, @"\\u([\dA-Fa-f]{4})", v => ((char)Convert.ToInt32(v.Groups[1].Value, 16)).ToString());
        }

        public static NameValueCollection ConvertToNameValue(this IQueryCollection queries) {
            var result = new NameValueCollection();

            if ((queries != null) && (queries.Count != 0)) {
                foreach (var query in queries) {
                    result.Add(query.Key, query.Value);
                }
            }

            return result;
        }

        public static string QueryParametersToString(NameValueCollection queries) {
            if ((queries == null) || (queries.Count == 0)) {
                return string.Empty;
            }

            string query = string.Join("&", queries.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(queries[a])));

            return query;
        }

        public static string EncodeTo(this string text, string from, string to) {
            var fromEncoding = Encoding.GetEncoding(from);
            var toEncoding = Encoding.GetEncoding(to);
            return text.EncodeTo(fromEncoding, toEncoding);
        }

        public static string EncodeTo(this string text, Encoding fromEncoding, Encoding toEncoding) {
            var fromBytes = fromEncoding.GetBytes(text);
            var toBytes = Encoding.Convert(fromEncoding, toEncoding, fromBytes);

            return toEncoding.GetString(toBytes);
        }
    }
}
