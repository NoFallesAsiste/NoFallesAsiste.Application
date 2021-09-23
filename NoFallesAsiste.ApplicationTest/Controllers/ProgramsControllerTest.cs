using Microsoft.AspNetCore.Mvc;
using Moq;
using NoFallesAsiste.Application.Contracts;
using NoFallesAsiste.Application.Controllers;
using NoFallesAsiste.Application.Models;
using NoFallesAsiste.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NoFallesAsiste.ApplicationTest.Controllers
{
    public class ProgramsControllerTest
    {
        private readonly Mock<IProgramsRepository> _mockRepository;
        private ProgramsController _programssController;
        public ProgramsControllerTest()
        {
            _mockRepository = new Mock<IProgramsRepository>();
            _programssController = new ProgramsController(_mockRepository.Object);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //Preparar
            //Ejecutar
            var result = _programssController.Index();
            //Comparar

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfprogramss()
        {
            //Preparar
            _mockRepository.Setup(repo => repo.GetAll())
            .Returns(new List<Programs>() { new Programs(), new Programs() });

            //Ejecutar
            var result = _programssController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var programss = Assert.IsType<List<Programs>>(viewResult.Model);

            //Comprobar
            Assert.Equal(2, programss.Count);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _programssController.Create();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            //Preparar
            _programssController.ModelState.AddModelError("Name", "Name is required");
            var programs = new Programs { Description = "Ciclo de vida del software", Version=1, TypeProgramId = 1 };

            //Ejecutar
            var result = _programssController.Create(programs);

            //Comprobar
            var viewResult = Assert.IsType<ViewResult>(result);
            var testprograms = Assert.IsType<Programs>(viewResult.Model);
            Assert.Equal(programs.Description, testprograms.Description);
            Assert.Equal(programs.Version, testprograms.Version);
            Assert.Equal(programs.TypeProgramId, testprograms.TypeProgramId);
        }

        //[Fact]
        //public void Create_InvalidModelStateRedirectsIndexAction()
        //{

        //    var programs = new programs { Name = "ADSI", Description = "Ciclo de vida del software", Version=1, TypeProgramId = 1 };

        //    //Ejecutar
        //    var result = _programssController.Create(programs);

        //    //Comprobar
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var testprograms = Assert.IsType<programs>(viewResult.Model);
        //    Assert.Equal(programs.Name, testprograms.Name);
        //    Assert.Equal(programs.Description, testprograms.Description);
        //    Assert.Equal(programs.Version, testprograms.Version);
        //    Assert.Equal(programs.TypeProgramId, testprograms.TypeProgramId);
        //}
    }
}
