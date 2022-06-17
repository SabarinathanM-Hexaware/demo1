using NSubstitute;
using Demo1.Test.Framework;
using Demo1.Api.Controllers;
using Demo1.Business.Interfaces;


namespace Demo1.Test.Api.ColorsControllerSpec
{
    public abstract class UsingColorsControllerSpec : SpecFor<ColorsController>
    {
        protected IColorsService _colorsService;

        public override void Context()
        {
            _colorsService = Substitute.For<IColorsService>();
            subject = new ColorsController(_colorsService);

        }

    }
}
