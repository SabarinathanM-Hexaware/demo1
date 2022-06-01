using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Business.Interfaces;
using Demo1.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorsService _ColorsService;
        public ColorsController(IColorsService ColorsService)
        {
            _ColorsService = ColorsService;
        }

        // GET: api/Colors
        [HttpGet]
        public ActionResult<IEnumerable<Colors>> Get()
        {
            return Ok(_ColorsService.GetAll());
        }


        [HttpGet("GetColorsById/{id}")]
        public ActionResult<IEnumerable<Colors>> GetColorsById([FromRoute] string id)
        {
            return Ok(_ColorsService.GetById(id));
        }


        [HttpPost("Save")]
        public ActionResult<bool> Save(Colors Colors)
        {
            _ColorsService.Save(Colors);

            return Ok(true);
        }

        [HttpPut("Update/{id}")]
        public ActionResult<bool> Update([FromRoute] string id, Colors Colors)
        {
            _ColorsService.Update(id, Colors);

            return Ok(true);
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            _ColorsService.Delete(id);

            return Ok(true);
        }


    }
}
