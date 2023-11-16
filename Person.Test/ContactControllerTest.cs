using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Person.Application;
using Person.Application.Commands;
using Person.Application.Queries;
using Person.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Person.Test
{
    public class ContactControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IContactService> _contactService;
        private readonly ContactController _controller;
        public ContactControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _contactService = new Mock<IContactService>();
            _controller = new ContactController(_mediator.Object, _contactService.Object);
        }
        [Fact]
        public async Task ContactController_GetAllContacts_ShouldReturnsAListOfContactDTO()
        {
            //arrange
            var expected = new List<ContactDTO>();
            _mediator.Setup(m=> m.Send(It.IsAny<GetAllContactsQuery>(), default(CancellationToken))).ReturnsAsync(expected);

            //act
            var result = await _controller.GetAllContacts();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            viewResult.Model.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task ContactController_GetContact_ShouldReturnOneContactDTO()
        {
            //arrange
            var expected = new ContactDTO();
            _mediator.Setup(m => m.Send(It.IsAny<GetContactByIdQuery>(), default(CancellationToken))).ReturnsAsync(expected);

            //act
            var result = await _controller.GetContact(It.IsAny<int>());

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            viewResult.Model.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public async Task ContactController_UpdateContact_ShouldRedirectToAction()
        {
            //arrange
            var dto = new ContactDTO();
            _mediator.Setup(m => m.Send(It.IsAny<UpdateContactCommand>(), default(CancellationToken)));

            //act
            var result = await _controller.UpdateContact(dto);

            //assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            redirect.ActionName.Should().Be("GetAllContacts");
        }
        [Fact]
        public async Task ContactController_AddContact_ShouldRedirectToAction()
        {
            //arrange
            var dto = new ContactDTO();
            _mediator.Setup(m => m.Send(It.IsAny<AddContactCommand>(), default(CancellationToken)));

            //act
            var result = await _controller.AddContact(dto);

            //assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            redirect.ActionName.Should().Be("GetAllContacts");
        }
        [Fact]
        public async Task ContactController_DeleteContact_ShouldRedirectToAction()
        {
            //arrange
            _mediator.Setup(m => m.Send(It.IsAny<DeleteContactCommand>(), default(CancellationToken)));

            //act
            var result = await _controller.DeleteContact(It.IsAny<int>());

            //assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            redirect.ActionName.Should().Be("GetAllContacts");
        }

    }
}
