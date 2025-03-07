using JobSearch.DBModels;
using JobSearch.UIModels;

namespace JobSearch.Pages
{
    public partial class ContactFormCpnt
    {
        private ContactUI newContact = new ContactUI();

        private async Task AddContactAsync()
        {
            var contact = new Contact()
            {
                FirstName = newContact.FirstName,
                LastName = newContact.LastName,
                Email = newContact.Email,
                Phone = newContact.Phone,
                CompanyName = newContact.CompanyName,
                IsHiring = newContact.IsHiring,

                ProfileId = PageState.Profile.Id
            };

            await JobSearchService.AddContactAsync(contact);

            newContact = new ContactUI();
            PageState.NotifyStateChanged();
        }

       
    }
}
