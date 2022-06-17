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
    public class When_saving_color : UsingColorsControllerSpec
    {
        private ActionResult<bool> _result;

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

            _colorsService.Save(_color).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_color);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _colorsService.Received(1).Save(_color);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<bool>();

            var resultList = (bool)resultListObject;

            resultList.ShouldBe(true);
        }
    }
}
