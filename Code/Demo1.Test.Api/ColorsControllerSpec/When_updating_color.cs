using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using Demo1.Entities.Entities;

namespace Demo1.Test.Api.ColorsControllerSpec
{
    public class When_updating_color : UsingColorsControllerSpec
    {
        private ActionResult<Colors> _result;
        private Colors _color;

        public override void Context()
        {
            base.Context();

            _color = new Colors
            {
                Id = "Kjfghyt",
                Name = "Blue",
                Desc = "Any"
            };

            _colorsService.Update(_color.Id, _color).Returns(_color);
            
        }
        public override void Because()
        {
            _result = subject.Update(_color.Id, _color);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _colorsService.Received(1).Update(_color.Id, _color);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Colors>();

            var resultList = resultListObject as Colors;

            resultList.ShouldBe(_color);
        }
    }
}
