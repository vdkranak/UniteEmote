using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitePlugin.ClientUI
{
    class ClientUISetup
    {
        public static string getHtml()
        {
            var task = ReadHtmlContentAsync();
            task.Wait();
            return task.Result;
        }
        public static async Task<string> ReadHtmlContentAsync()
        {
            var sitecss = await
                GetFileContentAsStringAsync("UnitePlugin.ClientUI.Source.css.site.min.css");

            var ControlJS = await
                GetFileContentAsStringAsync("UnitePlugin.ClientUI.Source.js.Control.main.js");

            var html = await
                GetFileContentAsStringAsync("UnitePlugin.ClientUI.Source.HtmlContent.html");

            return html.Replace("{sitecss}", sitecss).Replace("{ControlJS}", ControlJS);
        }
        public static async Task<string> GetFileContentAsStringAsync(string resource)
        {
            using (var sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resource) ?? throw new InvalidOperationException()))
            {
                return await sr.ReadToEndAsync();
            }
        }
    }
}
