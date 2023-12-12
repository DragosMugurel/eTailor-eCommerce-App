using Repository_DBFirst;

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

public class AdminController : Controller
{
    private readonly eTailorEntities dbContext;

    public AdminController()
    {
        dbContext = new eTailorEntities();
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LibrarieModele.User model)
    {
        if (ModelState.IsValid)
        {
            var adminUser = dbContext.Users.FirstOrDefault(u =>
                u.email.Equals(model.Email, StringComparison.OrdinalIgnoreCase) &&
                u.password == model.Password);

            if (adminUser != null)
            {
                // Determine the role based on the user_type field
                string[] roles = { adminUser.user_type };

                // Create the authentication ticket
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    1,
                    adminUser.email,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(20), // Adjust the expiration time as needed
                    false, // Persistent cookie
                    string.Join(",", roles), // User data (roles)
                    FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket and add it to the response
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid login credentials for user.";
            }
        }

        // If already authenticated, redirect to Home
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }


    public ActionResult Logout()
    {
        FormsAuthentication.SignOut();
        Session["UserEmail"] = null;
        Session["UserType"] = null;

        return RedirectToAction("Login", "Admin");
    }
    public ActionResult AdminDashboard()
    {
        return View();
    }
}
