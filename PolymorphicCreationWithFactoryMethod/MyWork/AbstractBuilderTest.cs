namespace PolymorphicCreationWithFactoryMethod.MyWork
{
    public abstract class AbstractBuilderTest : TestCase
    {
        public OutputBuilder Builder { get; set; }

        protected abstract OutputBuilder CreateBuilder();

        public void TestAddAboveRoot()
        {
            string invalidResult =
                "<orders>" +
                "<order>" +
                "</order>" +
                "</orders>" +
                "<customer>" +
                "</customer>";

            Builder = CreateBuilder();

            Builder.AddBelow("order");

            try
            {
                Builder.AddAbove("customer");
                Fail("expecting RuntimeException");
            }
            catch (RuntimeException ignored)
            {
            }
        }

        protected abstract void Fail(string failureMessage);
    
    }
}