using System;
using NUnit.Framework;
using pet.dal.Services.Carioca;
using System.Data.Entity;
using System.Linq;
using pet.dal.Model;
using pet.dal.Model.Entities.Carioca;
using pet.dal.Model.Entities;

namespace pet.test
{
    class CariocaSerciceTest
    {
        private MeContext _context;
        private ICariocaService _sut;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MeContext>());
            _context = new MeContext();
            _context.Database.Initialize(true);

            _sut = new CariocaService(_context);
            var empresa = new Empresa { Nombre = "TAB Consultores" };
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }

        [Test]
        public void When_AddZonaTipo_ZonaTipo_IsAdded()
        {
            //Arrange
            var zonaTipo = new ZonaTipoBuilder()
                .WithCodigo("ZONA_TIPO_001")
                .WithDescripcion("DESCRIPCION_ZONA_TIPO_001")
                .WithEmpresa(_context.Empresas.First())
                .Build();

            //Act
            _sut.AddZonaTipo(zonaTipo);

            //Assert
            Assert.AreEqual(_context.ZonaTipos.First().Codigo, zonaTipo.Codigo);
        }

        [Test]
        public void When_AddZonaTipo_Throws_ApplicationException_If_Codigo_Exists()
        {
            //Arrange
            var zonaTipo = new ZonaTipoBuilder()
                .WithCodigo("ZONA_TIPO_001")
                .WithDescripcion("DESCRIPCION_ZONA_TIPO_001")
                .WithEmpresa(_context.Empresas.First())
                .Build();

            //Act
            _sut.AddZonaTipo(zonaTipo);

            //Assert
            Assert.That(() => _sut.AddZonaTipo(zonaTipo), Throws.Exception.TypeOf<ApplicationException>());

        }

        class ZonaTipoBuilder
        {
            private readonly ZonaTipo _zonaTipo;

            public ZonaTipoBuilder()
            {
                _zonaTipo = new ZonaTipo();
            }

            public ZonaTipoBuilder WithCodigo(string codigo)
            {
                _zonaTipo.Codigo = codigo;
                return this;
            }

            public ZonaTipoBuilder WithDescripcion(string descripcion)
            {
                _zonaTipo.Descripcion = descripcion;
                return this;
            }

            public ZonaTipoBuilder WithEmpresa(Empresa empresa)
            {
                _zonaTipo.Empresa = empresa;
                return this;
            }

            public ZonaTipo Build()
            {
                return _zonaTipo;
            }
        }
    }
}