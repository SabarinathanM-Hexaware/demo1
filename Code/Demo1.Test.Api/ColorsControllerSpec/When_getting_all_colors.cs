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
    public class When_getting_all_colors : UsingColorsControllerSpec
    {
        private ActionResult<IEnumerable<Colors>> _result;

        private IEnumerable<Colors> _colors;
        private Colors _color;

        public override void Context()
        {
            base.Context();

            _color = new Colors{
                Id = "Kjfghyt",
                Name = "Blue",
                Desc = "Any"
            };

            _colors = new List<Colors> { _color};
            _colorsService.GetAll().Returns(_colors);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _colorsService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Colors>>();

            List<Colors> resultList = resultListObject as List<Colors>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_colors);
        }
    }
}
