using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneTest.Data;
using PhoneTest.Models;
using PhoneTest.Models.Domain;

namespace PhoneTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(ContactlyDbContext contactlyDbContext) : ControllerBase
    {
        public readonly ContactlyDbContext dbContext = contactlyDbContext;

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbContext.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Faforite = request.Faforite
            };
            dbContext.Contacts.Add(domainModelContact);
            dbContext.SaveChanges();

            return Ok(domainModelContact);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id) 
        {
            var contact = dbContext.Contacts.Find(id);

            if (contact is not null)
            {
                dbContext.Contacts.Remove(contact);
                dbContext.SaveChanges();
            }

            return Ok();
        }
    }
}
