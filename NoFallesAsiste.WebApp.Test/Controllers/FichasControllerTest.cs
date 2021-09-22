using Microsoft.AspNetCore.Mvc;
using Moq;
using NoFallesAsiste.WebApp.Contracts;
using NoFallesAsiste.WebApp.Controllers;
using NoFallesAsiste.WebApp.Models;
using NoFallesAsiste.WebAppApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NoFallesAsiste.WebAppTest.Controllers
{
    public class FichasControllerTest
    {
        private readonly Mock<IFichaRepository> _mockRepository;
        private FichasController _FichasController;
        public FichasControllerTest()
        {
            _mockRepository = new Mock<IFichaRepository>();
            _FichasController = new FichasController(_mockRepository.Object);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //Preparar
            //Ejecutar
            var result = _FichasController.Index();
            //Comparar

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfFichas()
        {
            //Preparar
            _mockRepository.Setup(repo => repo.GetAll())
            .Returns(new List<Ficha>() { new Ficha(), new Ficha() });

            //Ejecutar
            var result = _FichasController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var Fichas = Assert.IsType<List<Ficha>>(viewResult.Model);

            //Comprobar
            Assert.Equal(2, Fichas.Count);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _FichasController.Create();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            //Preparar
            _FichasController.ModelState.AddModelError("StartTraining", "La fecha de incio formación es requerida");
            var Ficha = new Ficha {  EndTraining = new DateTime(), StartPractice = new DateTime(), HoraryId = 1, ProgramId =2 };

            //Ejecutar
            var result = _FichasController.Create(Ficha);

            //Comprobar
            var viewResult = Assert.IsType<ViewResult>(result);
            var testFicha = Assert.IsType<Ficha>(viewResult.Model);
            Assert.Equal(Ficha.EndTraining, testFicha.EndTraining);
            Assert.Equal(Ficha.StartPractice, testFicha.StartPractice);
            Assert.Equal(Ficha.HoraryId, testFicha.HoraryId);
            Assert.Equal(Ficha.ProgramId, testFicha.ProgramId);
        }

        //[Fact]
        //public void Create_InvalidModelStateRedirectsIndexAction()
        //{

        //    var Ficha = new Ficha { StartTraining = new DateTime(), EndTraining = new DateTime(), StartPractice = new DateTime(), HoraryId = 1, ProgramId = 2 };

        //    //Ejecutar
        //    var result = _FichasController.Create(Ficha);

        //    //Comprobar
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var testFicha = Assert.IsType<Ficha>(viewResult.Model);
        //    Assert.Equal(Ficha.StartTraining, testFicha.StartTraining);
        //    Assert.Equal(Ficha.EndTraining, testFicha.EndTraining);
        //    Assert.Equal(Ficha.StartPractice, testFicha.StartPractice);
        //    Assert.Equal(Ficha.HoraryId, testFicha.HoraryId);
        //    Assert.Equal(Ficha.ProgramId, testFicha.ProgramId);
        //}
    }
}
