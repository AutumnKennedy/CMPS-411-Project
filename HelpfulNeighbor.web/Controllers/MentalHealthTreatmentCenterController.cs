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
    public class MentalHealthTreatmentCenterController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public MentalHealthTreatmentCenterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Get all centers

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new Response();

            var mentalHealthTreatmentCenter = _dataContext
                .MentalHealthTreatmentCenter
                .Select(mentalHealthTreatmentCenter => new MentalHealthTreatmentCenterGetDto
                {
                    Id = mentalHealthTreatmentCenter.Id,
                    Name = mentalHealthTreatmentCenter.Name,
                    Location = mentalHealthTreatmentCenter.Location,
                    HoursOfOperation = mentalHealthTreatmentCenter.HoursOfOperation,
                    TypeId = mentalHealthTreatmentCenter.TypeId,

                })
                .ToList();
            response.Data = mentalHealthTreatmentCenter;
            return Ok(response);
        }


        // Get the center by its ID

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();

            var mentalHealthTreatmentCenterToReturn = _dataContext.MentalHealthTreatmentCenter.Select(mentalHealthTreatmentCenter => new MentalHealthTreatmentCenterGetDto
            {
                Id = mentalHealthTreatmentCenter.Id,
                Name = mentalHealthTreatmentCenter.Name,
                Location = mentalHealthTreatmentCenter.Location,
                HoursOfOperation = mentalHealthTreatmentCenter.HoursOfOperation,
                TypeId = mentalHealthTreatmentCenter.TypeId,
            })
                .FirstOrDefault(mentalHealthTreatmentCenter => mentalHealthTreatmentCenter.Id == id);

            if (mentalHealthTreatmentCenterToReturn == null)
            {
                response.AddError("id", "Mental Health Treatment Center Could Not Be Found.");
                return BadRequest(response);
            }

            response.Data = mentalHealthTreatmentCenterToReturn;
            return Ok(response);
        }


        // Create new center

        [HttpPost]
        public IActionResult Create([FromBody] MentalHealthTreatmentCenterCreateDto mentalHealthTreatmentCenterCreateDto)
        {
            var response = new Response();

            if (string.IsNullOrEmpty(mentalHealthTreatmentCenterCreateDto.Name))
            {
                response.AddError("name", "Mental Health Treatment Center Name Cannot Be Empty.");
            }
            if (response.HasErrors)
            {
                return BadRequest(Response);
            }

            var mentalHealthTreatmentCenterToAdd = new MentalHealthTreatmentCenter
            {
                Name = mentalHealthTreatmentCenterCreateDto.Name,
                Location = mentalHealthTreatmentCenterCreateDto.Location,
                HoursOfOperation = mentalHealthTreatmentCenterCreateDto.HoursOfOperation,
                TypeId = mentalHealthTreatmentCenterCreateDto.TypeId,
            };

            _dataContext.MentalHealthTreatmentCenter.Add(mentalHealthTreatmentCenterToAdd);
            _dataContext.SaveChanges();

            var mentalHealthTreatmentCenterToReturn = new MentalHealthTreatmentCenterGetDto
            {
                Name = mentalHealthTreatmentCenterToAdd.Name,
                Location = mentalHealthTreatmentCenterToAdd.Location,
                HoursOfOperation = mentalHealthTreatmentCenterToAdd.HoursOfOperation,
                TypeId = mentalHealthTreatmentCenterToAdd.TypeId,
            };

            response.Data = mentalHealthTreatmentCenterToReturn;
            return Created("", Response);
        }


        // Update current center

        [HttpPut("id")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] MentalHealthTreatmentCenterUpdateDto mentalHealthTreatmentCenterUpdateDto)

        {
            var response = new Response();

            var mentalHealthTreatmentCenterToUpdate = _dataContext.MentalHealthTreatmentCenter.FirstOrDefault(mentalHealthTreatmentCenter => mentalHealthTreatmentCenter.Id == id);
            if (mentalHealthTreatmentCenterToUpdate == null)
            {
                response.AddError("id", "Mental Health Treatment Center Could Not Be Found.");
                return BadRequest(response);
            }

            mentalHealthTreatmentCenterToUpdate.Name = mentalHealthTreatmentCenterUpdateDto.Name;
            mentalHealthTreatmentCenterToUpdate.Location = mentalHealthTreatmentCenterUpdateDto.Location;
            mentalHealthTreatmentCenterToUpdate.HoursOfOperation = mentalHealthTreatmentCenterUpdateDto.HoursOfOperation;
            mentalHealthTreatmentCenterToUpdate.TypeId = mentalHealthTreatmentCenterUpdateDto.TypeId;
            _dataContext.SaveChanges();

            var mentalHealthTreatmentCenterToReturn = new MentalHealthTreatmentCenterGetDto
            {
                Id = mentalHealthTreatmentCenterToUpdate.Id,
                Name = mentalHealthTreatmentCenterToUpdate.Name,
                Location = mentalHealthTreatmentCenterToUpdate.Location,
                HoursOfOperation = mentalHealthTreatmentCenterToUpdate.HoursOfOperation,
                TypeId = mentalHealthTreatmentCenterToUpdate.TypeId,
            };

            response.Data = mentalHealthTreatmentCenterToReturn;
            return Ok(response);
        }


        // Delete a center

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var mentalHealthTreatmentCenterToDelete = _dataContext.MentalHealthTreatmentCenter.FirstOrDefault(MentalHealthTreatmentCenter => MentalHealthTreatmentCenter.Id == id);
            if (mentalHealthTreatmentCenterToDelete == null)
            {
                response.AddError("id", "Mental Health Treatment Center Could Not Be Found.");
                return BadRequest(response);
            }

            _dataContext.Remove(mentalHealthTreatmentCenterToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }

    }


} // end of HelpfulNeighbor.web.Controllers

