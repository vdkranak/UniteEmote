namespace UniteEmoteTest
{
    public class PluginModuleHandlerTest
    {

        private readonly IFixture _fixture;

        public PluginModuleHandlerTest()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }
        
        [Fact]
        void Init_Load_IconsLoaded()
        {
            //Given
            var sut = new PluginModuleHandler();

            //When
            sut.Load();
            
            //Then

            //Test that load adds the views expected

        }
    }
}
