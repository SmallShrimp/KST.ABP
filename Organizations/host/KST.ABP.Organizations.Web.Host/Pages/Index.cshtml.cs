using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace KST.ABP.Organizations.Pages
{
    public class IndexModel : OrganizationsPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}