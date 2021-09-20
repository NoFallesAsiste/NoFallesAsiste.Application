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
    public class ProgramasControllerTest
    {
        private readonly Mock<IProgramaRepository> _mockRepository;
        private ProgramasController _ProgramasController;
        public ProgramasControllerTest()
        {
            _mockRepository = new Mock<IProgramaRepository>();
            _ProgramasController = new ProgramasController(_mockRepository.Object);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //Preparar
            //Ejecutar
            var result = _ProgramasController.Index();
            //Comparar

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfProgramas()
        {
            //Preparar
            _mockRepository.Setup(repo => repo.GetAll())
            .Returns(new List<Programa>() { new Programa(), new Programa() });

            //Ejecutar
            var result = _ProgramasController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var Programas = Assert.IsType<List<Programa>>(viewResult.Model);

            //Comprobar
            Assert.Equal(2, Programas.Count);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _ProgramasController.Create();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            //Preparar
            _ProgramasController.ModelState.AddModelError("Name", "Name is required");
            var Programa = new Programa { Description = "Ciclo de vida del software", Version=1, TypeProgramId = 1 };

            //Ejecutar
            var result = _ProgramasController.Create(Programa);

            //Comprobar
            var viewResult = Assert.IsType<ViewResult>(result);
            var testPrograma = Assert.IsType<Programa>(viewResult.Model);
            Assert.Equal(Programa.Description, testPrograma.Description);
            Assert.Equal(Programa.Version, testPrograma.Version);
            Assert.Equal(Programa.TypeProgramId, testPrograma.TypeProgramId);
        }

        //[Fact]
        //public void Create_InvalidModelStateRedirectsIndexAction()
        //{

        //    var Programa = new Programa { Name = "ADSI", Description = "Ciclo de vida del software", Version=1, TypeProgramId = 1 };

        //    //Ejecutar
        //    var result = _ProgramasController.Create(Programa);

        //    //Comprobar
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var testPrograma = Assert.IsType<Programa>(viewResult.Model);
        //    Assert.Equal(Programa.Name, testPrograma.Name);
        //    Assert.Equal(Programa.Description, testPrograma.Description);
        //    Assert.Equal(Programa.Version, testPrograma.Version);
        //    Assert.Equal(Programa.TypeProgramId, testPrograma.TypeProgramId);
        //}
    }
}
