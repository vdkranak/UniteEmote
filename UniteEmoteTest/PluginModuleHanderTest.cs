using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using UniteEmote;
using Xunit;

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
