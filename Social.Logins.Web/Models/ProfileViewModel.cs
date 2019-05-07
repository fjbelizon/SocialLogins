namespace Social.Logins.Web.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;

    public class ProfileViewModel
    {
        #region Properties

        public string Name { get; set; }

        public IEnumerable<Claim> Claims { get; set; }

        #endregion
    }
}