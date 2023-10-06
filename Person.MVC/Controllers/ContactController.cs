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
            try
            {
                var movies = await _mediator.Send(new GetAllContactsQuery());
                return View(movies);
            }
            catch(Exception exp)
            {
                return View(exp);

            }
        }
        public async Task<IActionResult> GetContact(int id)
        {
            try
            {
                var command = await _mediator.Send(new GetContactByIdQuery(id));
                return View(command);
            }
            catch(Exception exp)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("GetContact");
                await _mediator.Send(command);
                return RedirectToAction("GetAllContacts");
            }
            catch(Exception exp)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactCommand command)
        {
            try
            {
                if (!ModelState.IsValid) return View();
                await _mediator.Send(command);
                return RedirectToAction("GetAllContacts");
            }
            catch(Exception exp)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ViewResult AddContact() => View();

        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _mediator.Send(new DeleteContactCommand(id));
                return RedirectToAction("GetAllContacts");
            }
            catch(Exception exp)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> GetAllDeletedContacts()
        {
            try
            {
                var deletedContacs = await _contactService.GetAllDeletedContacts();
                return View(deletedContacs);
            }
            catch(Exception exp)
            {
                return View(exp);
            }
        }
        public async Task<ActionResult> SearchContacts(string search)
        {
            try
            {
                var contatcs = await _contactService.LiveSearchForContacts(search);
                return PartialView(contatcs);
            }
            catch(Exception exp)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
