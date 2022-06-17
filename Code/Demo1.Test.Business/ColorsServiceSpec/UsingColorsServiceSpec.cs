using NSubstitute;
using Demo1.Test.Framework;
using Demo1.Business.Services;
using Demo1.Data.Interfaces;

namespace Demo1.Test.Business.ColorsServiceSpec
{
    public abstract class UsingColorsServiceSpec : SpecFor<ColorsService>
    {
        protected IColorsRepository _colorsRepository;

        public override void Context()
        {
            _colorsRepository = Substitute.For<IColorsRepository>();
            subject = new ColorsService(_colorsRepository);

        }

    }
}
