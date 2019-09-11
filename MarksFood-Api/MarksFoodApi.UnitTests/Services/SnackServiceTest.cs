using MarksFoodApi.Domain.Commands.Results;
using MarksFoodApi.Domain.Dtos.Outputs;
using MarksFoodApi.Domain.Enums;
using MarksFoodApi.Domain.Repositories;
using MarksFoodApi.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MarksFoodApi.UnitTests.Services
{
    public class SnackServiceTest
    {
        private readonly Mock<ISnackRepository> _snackRepositoryMock;
        private readonly Mock<IDiscountRepository> _discountRepositoryMock;

        private readonly SnackService _snackService;

        public SnackServiceTest()
        {
            _snackRepositoryMock = new Mock<ISnackRepository>();
            _discountRepositoryMock = new Mock<IDiscountRepository>();
            _snackService = new SnackService(_snackRepositoryMock.Object, _discountRepositoryMock.Object);
        }

        [Fact]
        public async void Should_Calculate_The_Snack_Value()
        {
            _snackRepositoryMock
                .Setup(x => x.GetAllSnacks())
                .ReturnsAsync(ListSnacks());

            _snackRepositoryMock
                .Setup(x => x.GetSnackIngredients(It.IsAny<Guid>()))
                .ReturnsAsync(ListSnackIngredients());

            _discountRepositoryMock
                .Setup(x => x.GetByIngredientAllowedId(It.IsAny<Guid>()))
                .ReturnsAsync(ListIngredientsDiscount());

            var snacksResult = await _snackService.GetAllSnacks();

            var snack = snacksResult
                .Where(x => x.Id == new Guid("0448BE35-83F1-464A-B4C6-027022FEA44D"))
                .FirstOrDefault();

            var snackPrice = ListSnackIngredients().Sum(x => x.Price * x.Quantity);

            Assert.Equal(snack.Price, snackPrice);
        }        

        #region Mocks
        public IEnumerable<SnackOutput> ListSnacks()
        {
            var snacks = new List<SnackOutput>{
                new SnackOutput
                {
                    Id = new Guid("0448BE35-83F1-464A-B4C6-027022FEA44D"),
                    Name = "X-Burger"
                }
            };

            return snacks;
        }

        public IEnumerable<IngredientOutput> ListSnackIngredients()
        {
            var ingredients = new List<IngredientOutput>
            {
                new IngredientOutput
                {
                    Id = new Guid("683BE3CE-54C2-4229-8B89-A41A81450A0F"),
                    Name = "Hambúrguer de carne",
                    Quantity = 1,
                    Price = 3
                },
                new IngredientOutput
                {
                    Id = new Guid("4B9EE171-46AD-48B1-B7A1-C7339D8F00C7"),
                    Name = "Queijo",
                    Quantity = 1,
                    Price = (float) 1.5
                }
            };
            return ingredients;
        }

        
        public DiscountOutput ListIngredientsDiscount()
        {
            var discount = new DiscountOutput {
                IdIngredientAllowed = new Guid("4B9EE171-46AD-48B1-B7A1-C7339D8F00C7"),
                IdIngredientNotAllowed = null,
                Quantity = 3,
                Percent = (float)33.33,
                Active = true,
                DiscountRule = EDiscountRule.QuantityBased };

            return discount;
        }
        #endregion
    }
}
