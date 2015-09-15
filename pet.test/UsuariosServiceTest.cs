using System;
using System.Data.Entity;
using NUnit.Framework;
using pet.dal.Model;
using pet.dal.Model.Entities;
using pet.dal.Services;
using System.Linq;

namespace pet.test
{
    class UsuariosServiceTest
    {
        private MeContext _context;
        private IUsuariosService _sut;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MeContext>());
            _context = new MeContext();
            _context.Database.Initialize(true);

            _sut = new UsuariosService(_context);
            var empresa = new Empresa {Nombre = "TAB Consultores"};
            empresa.Usuarios.Add(new Usuario() { Nombre = "Miguel Angel Martin Hrdez", FechaNacimiento = new DateTime(1977, 1, 13) });
            empresa.Usuarios.Add(new Usuario() { Nombre = "Sergio León", FechaNacimiento = new DateTime(1977, 1, 13) });
            empresa.Usuarios.Add(new Usuario() { Nombre = "Antonio Chamorro", FechaNacimiento = new DateTime(1977, 1, 13) });
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }

        [SetUp]
        public void SetUp()
        {
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }

        [Test]
        public void GetUsuariosTest()
        {
            var usuarios = _sut.GetUsuarios().ToList();
            Assert.AreEqual(3, usuarios.Count);
        }

        [Test]
        public void GetUsuarioTest_Return_Null_When_UsuarioId_NotExists()
        {
            var usuario = _sut.GetUsuario(0);
            Assert.IsNull(usuario);
        }

    }
}
