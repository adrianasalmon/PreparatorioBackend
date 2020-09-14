using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIPrueba1.Controllers;
using APIPrueba1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace admPrueba.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetPrueba()
        {
            //Arrange
            PruebasController pruebasController = new PruebasController();
            //Act
            var ListaPrueba = pruebasController.GetPruebas();
            //Asser
            Assert.IsNotNull(ListaPrueba);
        }
        [TestMethod]
        public void TestPostPrueba()
        {
            //Arrange
            PruebasController pruebasController = new PruebasController();
            Prueba pruebaesperada = new Prueba()
            {
                FriendofSalmon = "Adriana Salmon",
                SalmonID = 1,
                Email = "a2019116341@estudiantes.upsa.edu.bo",
                Birthdate = 1,
                Place = CategoryType.Administrativo
            };
            //Act
            IHttpActionResult actionResult = pruebasController.PostPrueba(pruebaesperada);
            var Pruebaactual = actionResult as CreatedAtRouteNegotiatedContentResult<Prueba>;
            //Asser
            Assert.IsNotNull(Pruebaactual);
            Assert.AreEqual("DefaultApi", Pruebaactual.RouteName);
            Assert.AreEqual(pruebaesperada.FriendofSalmon, Pruebaactual.Content.FriendofSalmon);
            Assert.AreEqual(pruebaesperada.Email, Pruebaactual.Content.Email);
            Assert.AreEqual(pruebaesperada.Birthdate, Pruebaactual.Content.Birthdate);
            Assert.AreEqual(pruebaesperada.Place, Pruebaactual.Content.Place);

        }
        [TestMethod]
        public void TestDeletePrueba()
        {
            //Arrange
            PruebasController pruebasController = new PruebasController();
            Prueba pruebaesperada = new Prueba()
            {
                FriendofSalmon = "Adriana Salmon",
                SalmonID = 1,
                Email = "a2019116341@estudiantes.upsa.edu.bo",
                Birthdate = 1,
                Place = CategoryType.Administrativo
            };
            //Act
            IHttpActionResult actionResult = pruebasController.DeletePrueba(pruebaesperada.SalmonID);
            //Asser
            Assert.IsNotInstanceOfType(actionResult,typeof(OkResult));
        }
        [TestMethod]
        public void TestPutPrueba()
        {
            //Arrange
            PruebasController pruebasController = new PruebasController();
            Prueba pruebaesperada = new Prueba()
            {
                FriendofSalmon = "Adriana Salmon",
                SalmonID = 1,
                Email = "a2019116341@estudiantes.upsa.edu.bo",
                Birthdate = 1,
                Place = CategoryType.Administrativo
            };
            string newname = "Fernanda Salmon";
            //Act
            var actionResult = pruebasController.PostPrueba(pruebaesperada);
            pruebaesperada.FriendofSalmon = newname;
            var actionResultPut = pruebasController.PutPrueba(pruebaesperada.SalmonID, pruebaesperada) as StatusCodeResult;
            //Asser
            Assert.IsNotNull(actionResultPut);
            Assert.AreEqual(HttpStatusCode.NoContent, actionResultPut.StatusCode);
            Assert.IsInstanceOfType(actionResultPut, typeof(StatusCodeResult));
        }
    }
    
}
