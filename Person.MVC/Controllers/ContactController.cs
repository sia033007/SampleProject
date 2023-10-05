using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.Application;
using Person.Application.Commands;
using Person.Application.Queries;

namespace Person.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IContactService _contactService;

        public ContactController(IMediator mediator, IContactService contactService)
        {
            _mediator = mediator;
            _contactService = contactService;
        }
        public async Task<IActionResult> GetAllContacts()
        {
            var movies = await _mediator.Send(new GetAllContactsQuery());
            return View(movies);
        }
        public async Task<IActionResult> GetContact(int id)
        {
            var command = await _mediator.Send(new GetContactByIdQuery(id));
            return View(command);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            if (!ModelState.IsValid) return RedirectToAction("GetContact");
            await _mediator.Send(command);
            return RedirectToAction("GetAllContacts");
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactCommand command)
        {
            if (!ModelState.IsValid) return View();
            await _mediator.Send(command);
            return RedirectToAction("GetAllContacts");
        }
        public ViewResult AddContact() => View();

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _mediator.Send(new DeleteContactCommand(id));
            return RedirectToAction("GetAllContacts");
        }
        public async Task<IActionResult> GetAllDeletedContacts()
        {
            var deletedContacs = await _contactService.GetAllDeletedContacts();
            return View(deletedContacs);
        }
    }
}
