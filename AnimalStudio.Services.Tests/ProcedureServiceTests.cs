using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Procedure;
using MockQueryable;
using Moq;

namespace AnimalStudio.Services.Tests
{
	[TestFixture]
	public class ProcedureServiceTests
	{
		private IList<Procedure> proceduresData = new List<Procedure>()
		{
			new Procedure
			{
				Id = 1, Name = "HairCut",
				Description = "Trimming or styling an animal's fur to maintain hygiene, comfort, and appearance.",
				Price = 20.56m
			},
			new Procedure
			{
				Id = 2, Name = "Vaccination",
				Description =
					"Administering a vaccine to protect the animal from diseases and strengthen its immune system.",
				Price = 45.62m
			}
		};

		private Mock<IRepository<Procedure, int>> procedureRepository;
		private Mock<IRepository<Worker, int>> workerRepository;
		private Mock<IRepository<Order, Guid>> orderRepository;
		private Mock<IRepository<WorkerProcedure, object>> workerProcedureRepository;

		[SetUp]
		public void Setup()
		{
			procedureRepository = new Mock<IRepository<Procedure, int>>();
			workerRepository = new Mock<IRepository<Worker, int>>();
			orderRepository = new Mock<IRepository<Order, Guid>>();
			workerProcedureRepository = new Mock<IRepository<WorkerProcedure, object>>();
		}

		[Test]
		public async Task GetAllProceduresPositive()
		{
			IQueryable<Procedure> proceduresMockQueryable = proceduresData.BuildMock();
			procedureRepository
				.Setup(r => r.GetAllAttached())
				.Returns(proceduresMockQueryable);

			IProcedureService procedureService = new ProcedureService(procedureRepository.Object, workerRepository.Object, workerProcedureRepository.Object, orderRepository.Object);

			IEnumerable<ProcedureIndexViewModel> allProceduresActual = await procedureService
				.IndexGetAllProceduresAsync();

			Assert.IsNotNull(allProceduresActual);
			Assert.AreEqual(proceduresData.Count(), allProceduresActual.Count());

			allProceduresActual = allProceduresActual
				.OrderBy(o => o.Id)
				.ToArray();

			int i = 0;
			foreach (ProcedureIndexViewModel model in allProceduresActual)
			{
				var result = proceduresData.OrderBy(o => o.Id).ToList()[i++].Id;

				Assert.AreEqual(result, model.Id);
			}
		}
	}
}
