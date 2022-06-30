using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Demo1.Entities.Entities;

namespace Demo1.Test.Business.ColorsServiceSpec
{
    public class When_updating_color : UsingColorsServiceSpec
    {
        private Colors _result;
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

            _colorsRepository.Update(_color.Id, _color).Returns(_color);
            
        }
        public override void Because()
        {
            _result = subject.Update(_color.Id, _color);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _colorsRepository.Received(1).Update(_color.Id, _color);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Colors>();

            _result.ShouldBe(_color);
        }
    }
}
