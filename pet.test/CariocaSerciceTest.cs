using System;
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using pet.dal.Model;
using pet.dal.Model.Entities;
using pet.dal.Model.Entities.Carioca;
using pet.dal.Services.Carioca;

namespace pet.test
{
    internal class CariocaSerciceTest
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
        public void When_AddTipoZona_TipoZona_IsAdded()
        {
            //Arrange
            var tipoZona =
                new TipoZonaBuilder().WithCodigo("ZONA_TIPO_001").WithDescripcion("DESCRIPCION_ZONA_TIPO_001")
                    .WithEmpresa(_context.Empresas.First())
                    .Build();

            //Act
            _sut.AddTipoZona(tipoZona);

            //Assert
            Assert.AreEqual(_context.TiposZona.First().Codigo, tipoZona.Codigo);
        }

        [Test]
        public void When_AddTipoZona_Throws_ApplicationException_If_Codigo_Exists()
        {
            //Arrange
            var tipoZona =
                new TipoZonaBuilder().WithCodigo("ZONA_TIPO_001").WithDescripcion("DESCRIPCION_ZONA_TIPO_001")
                    .WithEmpresa(_context.Empresas.First())
                    .Build();

            //Act
            _sut.AddTipoZona(tipoZona);

            //Assert
            Assert.That(() => _sut.AddTipoZona(tipoZona), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void When_UpdateTipoZona_Throws_ApplicationException_If_Change_Codigo_And_Exists()
        {
            //Arrange
            var tipoZona =
                new TipoZonaBuilder().WithCodigo("ZONA_TIPO_001").WithDescripcion("DESCRIPCION_ZONA_TIPO_001")
                    .WithEmpresa(_context.Empresas.First())
                    .Build();
            _sut.AddTipoZona(tipoZona);
            var tipoZona2 =
                new TipoZonaBuilder().WithCodigo("ZONA_TIPO_002").WithDescripcion("DESCRIPCION_ZONA_TIPO_002")
                    .WithEmpresa(_context.Empresas.First())
                    .Build();
            _sut.AddTipoZona(tipoZona2);

            //Act
            tipoZona2.Codigo = tipoZona.Codigo;

            //Assert
            Assert.That(() => _sut.UpdateTipoZona(tipoZona2), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        [Explicit("No es un test al uso. Es un método que incorpora datos de pruebas")]
        public void Load_Data_To_Test_Database()
        {
            var items = CariocaServiceTestHelper.GetResumenUbicacion().ToList();
            var tiendasParaImportar = CariocaServiceTestHelper.GetTiendasUnicas(items);
            var empresaId = _context.Empresas.Select(p => p.EmpresaId).First();

            foreach (var tiendaParaImportar in tiendasParaImportar)
            {
                var tienda = new Tienda { Nombre = tiendaParaImportar, EmpresaId = empresaId };
                CariocaServiceTestHelper.FillZonas(items, empresaId, tienda);
                _context.Tiendas.Add(tienda);
            }

            _context.SaveChanges();
        }

        private class TipoZonaBuilder
        {
            private readonly TipoZona _tipoZona;

            public TipoZonaBuilder()
            {
                _tipoZona = new TipoZona();
            }

            public TipoZonaBuilder WithCodigo(string codigo)
            {
                _tipoZona.Codigo = codigo;
                return this;
            }

            public TipoZonaBuilder WithDescripcion(string descripcion)
            {
                _tipoZona.Descripcion = descripcion;
                return this;
            }

            public TipoZonaBuilder WithEmpresa(Empresa empresa)
            {
                _tipoZona.Empresa = empresa;
                return this;
            }

            public TipoZona Build()
            {
                return _tipoZona;
            }
        }
    }
}