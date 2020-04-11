namespace PolymorphicCreationWithFactoryMethod.MyWork
{
    public class DOMBuilderTest : AbstractBuilderTest 
    {


        protected override OutputBuilder CreateBuilder()
        {
            return new DOMBuilder("orders");
        }

        protected override void Fail(string failureMessage)
        {
        }
    }
}