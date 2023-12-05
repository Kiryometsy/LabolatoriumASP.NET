using Labolatorium3App.Controllers;
using Labolatorium3App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_9___Test
{
    public class ContactControllerTest
    {
        private ContactController _controller;
        private IContactService _service;

        public ContactControllerTest()
        {
            _service = new MemoryContactService(new CurrentDateTimeProvider());
            _service.Add(new Contact() { Id = 1 });
            _service.Add(new Contact() { Id = 2 });
            _controller = new ContactController(_service);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            var model = view.Model as List<Contact>;
            Assert.Equal(2, model.Count);

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsTestForExistingContacts(int id)
        {
            var result = _controller.Details(id);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            var model = view.Model as Contact;
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public void DetailsTestForNonExistingContact()
        {
            var result = _controller.Details(3);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}