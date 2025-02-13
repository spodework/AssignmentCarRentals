using Microsoft.AspNetCore.Http;

namespace CarRentalsAssignmentV2.Data
{
    public class SessionHelper
    {
        public static void SetSessionStrings(HttpContext context, int userId, string userName, string userRole, string userEmail)
        {
            context.Session.SetInt32("UserId", userId);
            context.Session.SetString("UserName", userName);
            context.Session.SetString("UserRole", userRole);
            context.Session.SetString("UserEmail", userEmail);
        }

        public static bool IsAdminSession(HttpContext context)
        {
            return context.Session.GetString("UserRole") == "Admin";
        }
    }
}
