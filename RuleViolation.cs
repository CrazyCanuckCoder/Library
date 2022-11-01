namespace Library
{
    /// <summary>
    /// A class to contain business rule errors.
    /// </summary>
    /// 
    /// <remarks>
    /// Originally from a blog article about creating a web application using ASP.NET MVC.
    /// 
    /// Reference:
    /// 
    /// http://nerddinnerbook.s3.amazonaws.com/Part3.htm
    /// </remarks>
    /// 
    public class RuleViolation 
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string NewErrorMessage, string NewPropertyName)
        {
            ErrorMessage = NewErrorMessage;
            PropertyName = NewPropertyName;
        }
    }
}
