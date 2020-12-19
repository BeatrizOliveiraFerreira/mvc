using a.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using PI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace TES
{
    public class CACOTES
    {
        private readonly Mock<DbSet<CA>> _mockSet;
        private readonly Mock<CO> _mockContext;
        private readonly CA _CA;

        public CACOTES()
        {
            _mockSet = new Mock<DbSet<CA>>();
            _mockContext = new Mock<CO>();
            _CA = new CA { Id = 1, Descricao = "TES CA" };

            _mockContext.Setup(m => m.CAS).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.CAS.FindAsync(1))
                .ReturnsAsync(_CA);

            _mockContext.Setup(m => m.SetModified(_CA));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        }

        [Fact]
        public async Task Get_CA()

        {
            var service = new CAsController(_mockContext.Object);

            await service.GetCA(1);

            _mockSet.Verify(m => m.FindAsync(1),
                Times.Once());
        }

        [Fact]
        public async Task Put_CA()
        {
            var service = new CAsController(_mockContext.Object);

            await service.PutCA(1, _CA);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());

        }

        [Fact]
        public async Task Post_CA()
        {
            var service = new CAsController(_mockContext.Object);
            await service.PostCA(_CA);

            _mockSet.Verify(x => x.Add(_CA), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Fact]
        public async Task Delete_CA()
        {
            var service = new CAsController(_mockContext.Object);
            await service.DeleteCA(1);

            _mockSet.Verify(m => m.FindAsync(1),
                Times.Once());
            _mockSet.Verify(x => x.Remove(_CA), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());

        }

    }






   

   

   


   



    

}
