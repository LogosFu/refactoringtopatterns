namespace PolymorphicCreationWithFactoryMethod.MyWork
{
    public class XMLBuilderTest : AbstractBuilderTest
    {
        protected override OutputBuilder CreateBuilder()
        {
            return new XMLBuilder("orders");
        }

        protected override void Fail(string failureMessage)
        {
        }
    }
}