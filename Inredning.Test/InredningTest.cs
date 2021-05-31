using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Inredning.Models;
using Inredning.ViewModels;

namespace Inredning.Test
{
    public class InredningTest
    {
        [Fact]
        public void CanSeedUsers()
        {
            //arrange, act
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "inredning").Options;

            using (var context = new AppDbContext(options))
            {

                UserRepository testRepository = new UserRepository(context);
                OrderPageViewModel testModel = new OrderPageViewModel();
                testModel.Users = testRepository.AllUsers;

                //Assert
                Assert.Equal(3, testModel.Users.Count()); //there are 3 seeded users in total
                Assert.Equal("krille@ballong.se", testModel.Users.ElementAt(0).Email);
                Assert.Equal("pelle@ballong.se", testModel.Users.ElementAt(1).Email);

            }
        }

        [Fact]
        public void CanSeedProjects()
        {
            //arrange, act
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "inredning").Options;

            using (var context = new AppDbContext(options))
            {
                OrderItemRepository testRepository2 = new OrderItemRepository(context);
                ProjectRepository testRepository = new ProjectRepository(context, testRepository2);

                OrderPageViewModel testModel = new OrderPageViewModel();
                testModel.Projects = testRepository.AllProjects;

                //Assert
                Assert.Equal(2, testModel.Projects.Count()); //there are 2 seeded projects in total
                Assert.Equal("Kontorslandskap X", testModel.Projects.ElementAt(0).ProjectName);
                Assert.Equal("Restaurang Y", testModel.Projects.ElementAt(1).ProjectName);
            }
        }
        [Fact]
        public void CanSeedOrderItems()
        {
            //arrange, act
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "inredning").Options;

            using (var context = new AppDbContext(options))
            {
                OrderItemRepository testRepository = new OrderItemRepository(context);
                OrderPageViewModel testModel = new OrderPageViewModel();
                testModel.OrderItems = testRepository.AllOrderItems;

                //Assert
                Assert.Equal(4, testModel.OrderItems.Count()); 
                Assert.Equal("Kontorsstolen Gertrud", testModel.OrderItems.ElementAt(0).Name);
                Assert.Equal("Färgen Megasnygg, 10 liter dunk", testModel.OrderItems.ElementAt(3).Name);
            }
        }
        [Fact]
        public void CanCalculateProjectCost()
        {
            //arrange
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "inredning").Options;

            using (var context = new AppDbContext(options))
            {
                OrderItemRepository testRepository2 = new OrderItemRepository(context);
                //project rep needs an orderitem rep
                ProjectRepository testRepository = new ProjectRepository(context, testRepository2);

                //act
                double projectcost = testRepository.GetProjectCost(1);

                //assert
                //the value to be compared with is the total value of project with id number 1 seeded in appdbcontext

                Assert.Equal(1300, projectcost);       
            }
        }
        [Fact]
        public void CanCalculateTotalCost()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "inredning").Options;

            using (var context = new AppDbContext(options))
            {

                OrderItemRepository testRepository2 = new OrderItemRepository(context);
                //project rep needs an orderitem rep
                ProjectRepository testRepository = new ProjectRepository(context, testRepository2);

                //act
                double totalcost = testRepository.AllProjectsCost;

                //assert
                //the value to be compared with is the independently calculated total value of projects seeded in appdbcontext

                Assert.Equal(6600, totalcost);
            }
        }

        [Fact]
        public void CanCalculateAverageCost()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "inredning").Options;

            using (var context = new AppDbContext(options))
            {

                OrderItemRepository testRepository2 = new OrderItemRepository(context);
                //project rep needs an orderitem rep
                ProjectRepository testRepository = new ProjectRepository(context, testRepository2);

                //act
                double averagecost = testRepository.AverageProjectCost;

                //assert
                //the value to be compared with is the independently calculated average cost of projects seeded in appdbcontext

                Assert.Equal(3300, averagecost);
            }
        }
    }
}
