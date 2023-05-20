using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpfulNeighbor.web.Data;
using HelpfulNeighbor.web.Features.Centers;
using HelpfulNeighbor.web.Common;
using System.Runtime.InteropServices;

namespace HelpfulNeighbor.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailCenterController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public MailCenterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();
            var mailCenter = _dataContext
                .MailCenter
                .Select(mailCenter => new MailCenterGetDto
                {
                    Id = mailCenter.Id,
                    Name = mailCenter.Name,
                    Location = mailCenter.Location,
                    HoursOfOperation = mailCenter.HoursOfOperation,
                    TypeId = mailCenter.TypeId,
                })
                .ToList();
            response.Data = mailCenter;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();
            var mailCenterToReturn = _dataContext.MailCenter.Select(mailCenter => new MailCenterGetDto
            {
                Id = mailCenter.Id,
                Name = mailCenter.Name,
                Location = mailCenter.Location,
                HoursOfOperation = mailCenter.HoursOfOperation,
                TypeId = mailCenter.TypeId,
            })
                .FirstOrDefault(MailCenter => MailCenter.Id == id);
           if (mailCenterToReturn == null)
            {
                response.AddError("id", "Mail Center Could Not Be Found.");
                return BadRequest(response);
            }
            response.Data = mailCenterToReturn;
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MailCenterCreateDto mailCenterCreateDto)
        {
            var response = new Response();
            if(string.IsNullOrEmpty(mailCenterCreateDto.Name))
            {
                response.AddError("name", "Mail Center Name Cannot Be Empty");
            }
            if (response.HasErrors)
            {
                return BadRequest(Response);
            }

            var mailCenterToAdd = new MailCenter
            {
                Name = mailCenterCreateDto.Name,
                Location = mailCenterCreateDto.Location,
                HoursOfOperation = mailCenterCreateDto.HoursOfOperation,
                TypeId = mailCenterCreateDto.TypeId,
            };

            _dataContext.MailCenter.Add(mailCenterToAdd);
            _dataContext.SaveChanges();

            var mailCenterToReturn = new MailCenterGetDto
            {
                Name = mailCenterToAdd.Name,
                Location = mailCenterToAdd.Location,
                HoursOfOperation = mailCenterToAdd.HoursOfOperation,
                TypeId = mailCenterToAdd.TypeId,
            };

            response.Data = mailCenterToReturn;
            return Created("", Response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] MailCenterUpdateDto mailCenterUpdateDto)
        {
            var response = new Response();
            var mailCenterToUpdate = _dataContext.MailCenter.FirstOrDefault(mailCenter => mailCenter.Id == id);
            if(mailCenterToUpdate == null)
            {
                response.AddError("id", "Mail Center Could Not Be Found.");
                return BadRequest(response);
            }

            mailCenterToUpdate.Name = mailCenterUpdateDto.Name;
            mailCenterToUpdate.Location = mailCenterUpdateDto.Location;
            mailCenterToUpdate.HoursOfOperation = mailCenterUpdateDto.HoursOfOperation;
            mailCenterToUpdate.TypeId = mailCenterUpdateDto.TypeId;
            _dataContext.SaveChanges();

            var mailCenterToReturn = new MailCenterGetDto
            {
                Id = mailCenterToUpdate.Id,
                Name = mailCenterToUpdate.Name,
                Location = mailCenterToUpdate.Location,
                HoursOfOperation = mailCenterToUpdate.HoursOfOperation,
                TypeId = mailCenterToUpdate.TypeId,
            };

            response.Data = mailCenterToReturn;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();
            var mailCenterToDelete = _dataContext.MailCenter.FirstOrDefault(MailCenter => MailCenter.Id == id);
            if(mailCenterToDelete == null)
            {
                response.AddError("id", "Mail Center Could Not Be Found.");
                return BadRequest(response);
            }

            _dataContext.Remove(mailCenterToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
