using Microsoft.AspNetCore.Html;
using System;
using System.IO;
using System.Text.Encodings.Web;

namespace Autokool.Tests
{
    internal class MockHtmlContent : IHtmlContent
    {
        public string Value { get; private set; }

        public MockHtmlContent(string s) => Value = s;
        public MockHtmlContent(IHtmlContent c)
        {
            using var writer = new StringWriter();
            c.WriteTo(writer, HtmlEncoder.Default);
            Value = writer.ToString();
        }
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
            => throw new NotImplementedException();
    }
}