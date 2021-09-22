using Microsoft.AspNetCore.Mvc;
using Moq;
using NoFallesAsiste.Application.Contracts;
using NoFallesAsiste.Application.Controllers;
using NoFallesAsiste.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NoFallesAsiste.ApplicationTest.Controllers
{
    public class ProgramssControllerTest
    {
        private readonly Mock<IProgramsRepository> _mockRepository;
        private ProgramssController _ProgramsController;
        public ProgramssControllerTest()
        {
            _mockRepository = new Mock<IProgramsRepository>();
            _ProgramsController = new ProgramssController(_mockRepository.Object);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //Preparar
            //Ejecutar
            var result = _ProgramsController.Index();
            //Comparar

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfPrograms()
        {
            //Preparar
            _mockRepository.Setup(repo => repo.GetAll())
            .Returns(new List<Programs>() { new Programs(), new Programs() });

            //Ejecutar
            var result = _ProgramsController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var Programs = Assert.IsType<List<Programs>>(viewResult.Model);

            //Comprobar
            Assert.Equal(2, Programs.Count);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _ProgramsController.Create();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            //Preparar
            _ProgramsController.ModelState.AddModelError("Name", "Name is required");
            var Programs = new Programs { Description = "Ciclo de vida del software", Version=1, TypeProgramId = 1 };

            //Ejecutar
            var result = _ProgramsController.Create(Programs);

            //Comprobar
            var viewResult = Assert.IsType<ViewResult>(result);
            var testPrograms = Assert.IsType<Programs>(viewResult.Model);
            Assert.Equal(Programs.Description, testPrograms.Description);
            Assert.Equal(Programs.Version, testPrograms.Version);
            Assert.Equal(Programs.TypeProgramId, testPrograms.TypeProgramId);
        }

        //[Fact]
        //public void Create_InvalidModelStateRedirectsIndexAction()
        //{

        //    var Programs = new Programs { Name = "ADSI", Description = "Ciclo de vida del software", Version=1, TypeProgramId = 1 };

        //    //Ejecutar
        //    var result = _ProgramsController.Create(Programs);

        //    //Comprobar
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var testPrograms = Assert.IsType<Programs>(viewResult.Model);
        //    Assert.Equal(Programs.Name, testPrograms.Name);
        //    Assert.Equal(Programs.Description, testPrograms.Description);
        //    Assert.Equal(Programs.Version, testPrograms.Version);
        //    Assert.Equal(Programs.TypeProgramId, testPrograms.TypeProgramId);
        //}
    }
}
