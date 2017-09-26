﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace YoutubeLight
{
    internal static class HTTPHelperYoutube
    {
        public static string DownloadString(string url)
        {
#if PORTABLE
            var request = WebRequest.Create(url);
            request.Method = "GET";

            System.Threading.Tasks.Task<WebResponse> task = System.Threading.Tasks.Task.Factory.FromAsync(
                request.BeginGetResponse,
                asyncResult => request.EndGetResponse(asyncResult),
                null);

            return task.ContinueWith(t => ReadStreamFromResponse(t.Result)).Result;
#else
            using (var client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                return client.DownloadString(url);
            }
#endif
        }

        public static string HtmlDecode(string value)
        {
#if PORTABLE
            return  DecodeHtmlChars(value);
#else
            return DecodeHtmlChars(value);
#endif
        }

        public static string DecodeHtmlChars(this string source)
        {
            string[] parts = source.Split(new string[] { "&#x" }, StringSplitOptions.None);
            for (int i = 1; i < parts.Length; i++)
            {
                int n = parts[i].IndexOf(';');
                string number = parts[i].Substring(0, n);
                try
                {
                    int unicode = Convert.ToInt32(number, 16);
                    parts[i] = ((char)unicode) + parts[i].Substring(n + 1);
                }
                catch { }
            }
            return String.Join("", parts);
        }

        public static IDictionary<string, string> ParseQueryString(string s)
        {
            // remove anything other than query string from url
            if (s.Contains("?"))
            {
                s = s.Substring(s.IndexOf('?') + 1);
            }

            var dictionary = new Dictionary<string, string>();

            foreach (string vp in Regex.Split(s, "&"))
            {
                string[] strings = Regex.Split(vp, "=");
                dictionary.Add(strings[0], strings.Length == 2 ? UrlDecode(strings[1]) : string.Empty);
            }

            return dictionary;
        }

        public static string ReplaceQueryStringParameter(string currentPageUrl, string paramToReplace, string newValue)
        {
            var query = ParseQueryString(currentPageUrl);

            query[paramToReplace] = newValue;

            var resultQuery = new StringBuilder();
            bool isFirst = true;

            foreach (KeyValuePair<string, string> pair in query)
            {
                if (!isFirst)
                {
                    resultQuery.Append("&");
                }

                resultQuery.Append(pair.Key);
                resultQuery.Append("=");
                resultQuery.Append(pair.Value);

                isFirst = false;
            }

            var uriBuilder = new UriBuilder(currentPageUrl)
            {
                Query = resultQuery.ToString()
            };

            return uriBuilder.ToString();
        }

        public static string UrlDecode(string url)
        {
#if PORTABLE
            return WWW.UnEscapeURL(url);
#else

            return WWW.UnEscapeURL(url);
#endif
        }

        private static string ReadStreamFromResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(responseStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}