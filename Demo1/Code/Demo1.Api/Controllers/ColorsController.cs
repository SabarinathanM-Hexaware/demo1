using System.Collections.Generic;
using Demo1.Business.Interfaces;
using Demo1.Entities.Entities;
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

        [HttpPost]
        public ActionResult<Colors> Save(Colors Colors)
        {
            return Ok(_ColorsService.Save(Colors));
        }

        [HttpPut("{id}")]
        public ActionResult<Colors> Update([FromRoute] string id, Colors Colors)
        {
            return Ok(_ColorsService.Update(id, Colors));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            return Ok(_ColorsService.Delete(id));

        }


    }
}
