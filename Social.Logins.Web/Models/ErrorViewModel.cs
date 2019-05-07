namespace Social.Logins.Web.Models
{
    public class ErrorViewModel
    {
        #region Properties

        public string RequestId { get; set; }

        public bool ShowRequestId
        {
            get => !string.IsNullOrEmpty(RequestId);
        }

        #endregion
    }
}