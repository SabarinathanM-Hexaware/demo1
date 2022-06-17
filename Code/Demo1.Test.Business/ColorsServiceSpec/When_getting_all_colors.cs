using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Demo1.Entities.Entities;

namespace Demo1.Test.Business.ColorsServiceSpec
{
    public class When_getting_all_colors : UsingColorsServiceSpec
    {
        private IEnumerable<Colors> _result;

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
            _colorsRepository.GetAll().Returns(_colors);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _colorsRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Colors>>();

            List<Colors> resultList = _result as List<Colors>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_colors);
        }
    }
}
