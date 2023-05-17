using HelpfulNeighbor.web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using HelpfulNeighbor.web.Features.Centers;
using HelpfulNeighbor.web.Common;

namespace HelpfulNeighbor.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCenterController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public DonationCenterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var donationCenter = _dataContext
                .DonationCenter
                .Select(donationCenter => new DonationCenterGetDto
                {
                    Id = donationCenter.Id,
                    Name = donationCenter.Name,
                    Location = donationCenter.Location,
                    HoursOfOperation = donationCenter.HoursOfOperation,
                    TypeId = donationCenter.TypeId,

                })
                .ToList();
            response.Data = donationCenter;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var donationCenterToReturn = _dataContext.DonationCenter.Select(donationCenter => new DonationCenterGetDto
            {
                Id = donationCenter.Id,
                Name = donationCenter.Name,
                Location = donationCenter.Location,
                HoursOfOperation = donationCenter.HoursOfOperation,
                TypeId = donationCenter.TypeId,
            })
                .FirstOrDefault(donationCenter => donationCenter.Id == id);

            if (donationCenterToReturn == null)
            {
                response.AddError("id", "Donation Center Could Not Be Found.");
                return BadRequest(response);
            }

            response.Data = donationCenterToReturn;
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DonationCenterCreateDto donationCenterCreateDto)
        {
            var response = new Response();

            if (string.IsNullOrEmpty(donationCenterCreateDto.Name))
            {
                response.AddError("name", "Donation Center Name Cannot Be Empty.");
            }
            if (response.HasErrors)
            {
                return BadRequest(Response);
            }

            var donationCenterToAdd = new DonationCenter
            {
                Name = donationCenterCreateDto.Name,
                Location = donationCenterCreateDto.Location,
                HoursOfOperation = donationCenterCreateDto.HoursOfOperation,
                TypeId = donationCenterCreateDto.TypeId,
            };

            _dataContext.DonationCenter.Add(donationCenterToAdd);
            _dataContext.SaveChanges();

            var donationCenterToReturn = new DonationCenterGetDto
            {
                Name = donationCenterToAdd.Name,
                Location = donationCenterToAdd.Location,
                HoursOfOperation = donationCenterToAdd.HoursOfOperation,
                TypeId = donationCenterToAdd.TypeId,
            };

            response.Data = donationCenterToReturn;
            return Created("", Response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] DonationCenterUpdateDto donationCenterUpdateDto)
        {
            var response = new Response();

            var donationCenterToUpdate = _dataContext.DonationCenter.FirstOrDefault(donationCenter => donationCenter.Id == id);
            if (donationCenterToUpdate == null)
            {
                response.AddError("id", "Donation Center Could Not Be Found.");
                return BadRequest(response);
            }

            donationCenterToUpdate.Name = donationCenterUpdateDto.Name;
            donationCenterToUpdate.Location = donationCenterUpdateDto.Location;
            donationCenterToUpdate.HoursOfOperation = donationCenterUpdateDto.HoursOfOperation;
            donationCenterToUpdate.TypeId = donationCenterUpdateDto.TypeId;
            _dataContext.SaveChanges();


            var donationCenterToReturn = new DonationCenterGetDto
            {
                Id = donationCenterToUpdate.Id,
                Name = donationCenterToUpdate.Name,
                Location = donationCenterToUpdate.Location,
                HoursOfOperation = donationCenterToUpdate.HoursOfOperation,
                TypeId = donationCenterToUpdate.TypeId,
            };

            response.Data = donationCenterToReturn;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var donationCenterToDelete = _dataContext.DonationCenter.FirstOrDefault(DonationCenter => DonationCenter.Id == id);
            if (donationCenterToDelete == null)
            {
                response.AddError("id", "Donation Center Could Not Be Found.");
                return BadRequest(response);
            }

            _dataContext.Remove(donationCenterToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
