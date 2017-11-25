namespace LearningSystem.Service.Implementations.Html
{
    using Ganss.XSS;
    using Interfaces.Html;
    public class SanitizerHtml : ISanitizerHtml
    {
        private readonly HtmlSanitizer sanitizer;

        public SanitizerHtml()
        {
            this.sanitizer = new HtmlSanitizer();
            this.sanitizer.AllowedAttributes.Add("class");
        }

        public string Sanitize(string htmlContent)
            => this.sanitizer.Sanitize(htmlContent);
    }
}
