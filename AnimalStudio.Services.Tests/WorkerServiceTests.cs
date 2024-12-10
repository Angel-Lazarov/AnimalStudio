using AnimalStudio.Data.Models;
using AnimalStudio.Data.Repository.Interfaces;
using AnimalStudio.Services.Data;
using AnimalStudio.Services.Data.Interfaces;
using AnimalStudio.Web.ViewModels.Worker;
using MockQueryable;
using Moq;

namespace AnimalStudio.Services.Tests
{
	[TestFixture]
	public class WorkerTests
	{
		private IList<Worker> workersData = new List<Worker>()
		{
			new Worker { Id = 1, Name = "Alan Jakson", ImageUrl = "/img/workers/Alan_Jakson.jpg", Description = "Dr. Alan Jakson is a skilled veterinarian with years of training and experience in animal wellness, dedicated to making every pet feel their best at our Animal Studio."},
			new Worker { Id = 2, Name = "Ana Lucia", ImageUrl = "/img/workers/Ana_Lucia.jpg", Description = "With a strong background in animal care, Dr. Ana Lucia combines expertise and compassion to offer top-tier treatments at our Animal Studio."},
		};

		private Mock<IRepository<WorkerProcedure, object>> workerProcedureRepository;
		private Mock<IRepository<Worker, int>> workerRepository;

		[SetUp]
		public void Setup()
		{
			workerProcedureRepository = new Mock<IRepository<WorkerProcedure, object>>();
			workerRepository = new Mock<IRepository<Worker, int>>();
		}

		[Test]
		public async Task GetAllWorkersPositive()
		{
			IQueryable<Worker> workersMockQueryable = workersData.BuildMock();
			workerRepository
				.Setup(r => r.GetAllAttached())
				.Returns(workersMockQueryable);

			IWorkerService workerService = new WorkerService(workerRepository.Object, workerProcedureRepository.Object);

			IEnumerable<WorkerViewModel> allWorkersActual = await workerService
				.IndexGetAllWorkersAsync();

			Assert.IsNotNull(allWorkersActual);
			Assert.AreEqual(workersData.Count(), allWorkersActual.Count());

			allWorkersActual = allWorkersActual
				.OrderBy(o => o.Id)
				.ToArray();

			int i = 0;
			foreach (WorkerViewModel model in allWorkersActual)
			{
				var result = workersData.OrderBy(o => o.Id).ToList()[i++].Id;

				Assert.AreEqual(result, model.Id);
			}
		}
	}
}