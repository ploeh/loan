using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ploeh.Samples.Loan;
using Ploeh.Samples.Loan.DataCollection;
using Moq;
using Ploeh.Samples.Loan.Render;

namespace Ploeh.Samples.Loan.UnitTest
{
    public class CompositeMortgageApplicationProcessorTests
    {
        [Fact]
        public void SutIsMortgageApplicationProcessor()
        {
            var sut = new CompositeMortgageApplicationProcessor();
            Assert.IsAssignableFrom<IMortgageApplicationProcessor>(sut);
        }

        [Fact]
        public void ProduceOfferConcatenatesResultFromAllComposedNodes()
        {
            // Arrange
            var application = new MortgageApplication();

            var moqRepo = new MockRepository(MockBehavior.Default);
            var r1 = moqRepo.Create<IRendering>().Object;
            var r2 = moqRepo.Create<IRendering>().Object;
            var r3 = moqRepo.Create<IRendering>().Object;
            var r4 = moqRepo.Create<IRendering>().Object;
            var r5 = moqRepo.Create<IRendering>().Object;
            var r6 = moqRepo.Create<IRendering>().Object;
            var r7 = moqRepo.Create<IRendering>().Object;
            var r8 = moqRepo.Create<IRendering>().Object;
            var r9 = moqRepo.Create<IRendering>().Object;

            var node1 = moqRepo.Create<IMortgageApplicationProcessor>();
            var node2 = moqRepo.Create<IMortgageApplicationProcessor>();
            var node3 = moqRepo.Create<IMortgageApplicationProcessor>();

            node1.Setup(n => n.ProduceOffer(application))
                .Returns(new[] { r1, r2, r3 });
            node2.Setup(n => n.ProduceOffer(application))
                .Returns(new[] { r4, r5, r6 });
            node3.Setup(n => n.ProduceOffer(application))
                .Returns(new[] { r7, r8, r9 });

            var sut = new CompositeMortgageApplicationProcessor();
            sut.Nodes.Add(node1.Object);
            sut.Nodes.Add(node2.Object);
            sut.Nodes.Add(node3.Object);

            // Act
            var actual = sut.ProduceOffer(application);

            // Assert
            var expected = new[] { r1, r2, r3, r4, r5, r6, r7, r8, r9 };
            Assert.Equal(expected, actual);
        }
    }
}
