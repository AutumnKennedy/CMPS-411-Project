using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelpfulNeighbor.web.Common;
using HelpfulNeighbor.web.Features.Centers;
using HelpfulNeighbor.web.Data;

namespace HelpfulNeighbor.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubstanceAbuseTreatmentCenterController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public SubstanceAbuseTreatmentCenterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet] 
        public IActionResult GetAll()
        {
            var response = new Response();

            var substanceAbuseTreatmentCenter = _dataContext
                .SubstanceAbuseTreatmentCenter
                .Select(substanceAbuseTreatmentCenter => new SubstanceAbuseTreatmentCenterGetDto
                {
                    Id = substanceAbuseTreatmentCenter.Id,
                    Name = substanceAbuseTreatmentCenter.Name,
                    Location = substanceAbuseTreatmentCenter.Location,
                    HoursOfOperation = substanceAbuseTreatmentCenter.HoursOfOperation,
                    TypeId = substanceAbuseTreatmentCenter.TypeId,
                })
                .ToList();
            response.Data = substanceAbuseTreatmentCenter;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var response = new Response();
            var substanceAbuseTreatmentCenterToReturn = _dataContext.SubstanceAbuseTreatmentCenter.Select(substanceAbuseTreatmentCenter => new SubstanceAbuseTreatmentCenterGetDto
            {
                Id = substanceAbuseTreatmentCenter.Id,
                Name = substanceAbuseTreatmentCenter.Name,
                Location = substanceAbuseTreatmentCenter.Location,
                HoursOfOperation = substanceAbuseTreatmentCenter.HoursOfOperation,
                TypeId = substanceAbuseTreatmentCenter.TypeId,
            })
                .FirstOrDefault(substanceAbuseTreatmentCenter => substanceAbuseTreatmentCenter.Id == id);
            if(substanceAbuseTreatmentCenterToReturn == null)
            {
                response.AddError("id", "Substance Abuse Treatment Center Could Not Be Found.");
                return BadRequest(response);
            }
            response.Data = substanceAbuseTreatmentCenterToReturn;
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create([FromBody] SubstanceAbuseTreatmentCenterCreateDto substanceAbuseTreatmentCenterCreateDto)
        {
            var response = new Response();

            if (string.IsNullOrEmpty(substanceAbuseTreatmentCenterCreateDto.Name))
            {
                response.AddError("name", "Substance Abuse Treatment Center Name Cannot Be Empty.");
            }
            if (response.HasErrors)
            {
                return BadRequest(Response);
            }

            var substanceAbuseTreatmentCenterToAdd = new SubstanceAbuseTreatmentCenterGetDto
            {
                Name = substanceAbuseTreatmentCenterCreateDto.Name,
                Location = substanceAbuseTreatmentCenterCreateDto.Location,
                HoursOfOperation = substanceAbuseTreatmentCenterCreateDto.HoursOfOperation,
                TypeId = substanceAbuseTreatmentCenterCreateDto.TypeId,
            };

            _dataContext.SubstanceAbuseTreatmentCenter.Add(substanceAbuseTreatmentCenterToAdd);
            _dataContext.SaveChanges();

            var substanceAbuseTreatmentCenterToReturn = new SubstanceAbuseTreatmentCenterGetDto
            {
                Name = substanceAbuseTreatmentCenterToAdd.Name,
                Location = substanceAbuseTreatmentCenterToAdd.Location,
                HoursOfOperation = substanceAbuseTreatmentCenterToAdd.HoursOfOperation,
                TypeId = substanceAbuseTreatmentCenterToAdd.TypeId,
            };

            response.Data = substanceAbuseTreatmentCenterToReturn;
            return Created("", Response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] SubstanceAbuseTreatmentCenterUpdateDto substanceAbuseTreatmentCenterUpdateDto)
        {
            var response = new Response();

            var substanceAbuseTreatmentCenterToUpdate = _dataContext.DonationCenter.FirstOrDefault(substanceAbuseTreatmentCenter => substanceAbuseTreatmentCenter.Id == id);
            if (substanceAbuseTreatmentCenterToUpdate == null)
            {
                response.AddError("id", "Substance Abuse Treatment Center Could Not Be Found.");
                return BadRequest(response);
            }

            substanceAbuseTreatmentCenterToUpdate.Name = substanceAbuseTreatmentCenterUpdateDto.Name;
            substanceAbuseTreatmentCenterToUpdate.Location = substanceAbuseTreatmentCenterUpdateDto.Location;
            substanceAbuseTreatmentCenterToUpdate.HoursOfOperation = substanceAbuseTreatmentCenterUpdateDto.HoursOfOperation;
            substanceAbuseTreatmentCenterToUpdate.TypeId = substanceAbuseTreatmentCenterUpdateDto.TypeId;
            _dataContext.SaveChanges();


            var substanceAbuseTreatmentCenterToReturn = new SubstanceAbuseTreatmentCenterGetDto
            {
                Id = substanceAbuseTreatmentCenterToUpdate.Id,
                Name = substanceAbuseTreatmentCenterToUpdate.Name,
                Location = substanceAbuseTreatmentCenterToUpdate.Location,
                HoursOfOperation = substanceAbuseTreatmentCenterToUpdate.HoursOfOperation,
                TypeId = substanceAbuseTreatmentCenterToUpdate.TypeId,
            };

            response.Data = substanceAbuseTreatmentCenterToReturn;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var response = new Response();

            var substanceAbuseTreatmentCenterToDelete = _dataContext.SubstanceAbuseTreatmentCenter.FirstOrDefault(SubstanceAbuseTreatmentCenter => SubstanceAbuseTreatmentCenter.Id == id);
            if (substanceAbuseTreatmentCenterToDelete == null)
            {
                response.AddError("id", "Substance Abuse Treatment Center Could Not Be Found.");
                return BadRequest(response);
            }

            _dataContext.Remove(substanceAbuseTreatmentCenterToDelete);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
}
