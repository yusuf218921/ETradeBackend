using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebAPI.Controllers;
using Assert = NUnit.Framework.Assert;

[TestFixture]
public class ProductsControllerTests
{
    private Mock<IProductService> _mockProductService;
    private ProductsController _productsController;

    [SetUp]
    public void Setup()
    {
        // Test verilerini kullanarak bir IProductService Mock'u oluþturuyoruz.
        _mockProductService = new Mock<IProductService>();

        // Mock ProductService'ý controller'a enjekte ediyoruz.
        _productsController = new ProductsController(_mockProductService.Object);
    }

    [Test]
    public void GetProduct_ExistingId_ReturnsOkWithProduct()
    {
        // Arrange
        int productId = 1;
        var mockProduct = new Product { ProductID = 1, CategoryID = 1, ProductName = "deneme", UnitPrice= 100, StockAmount = 100, Status = true };
        _mockProductService.Setup(service => service.GetById(productId)).Returns(new SuccessDataResult<Product>(mockProduct));

        // Act
        IActionResult result = _productsController.GetById(productId);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.AreEqual(200, okResult.StatusCode);
        Assert.AreEqual(mockProduct, okResult.Value);
    }

    [Test]
    public void GetProduct_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        int nonExistingId = 999;
        _mockProductService.Setup(service => service.GetById(nonExistingId)).Returns((SuccessDataResult<Product>)null);

        // Act
        IActionResult result = _productsController.GetById(nonExistingId);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
        var notFoundResult = result as NotFoundResult;
        Assert.AreEqual(404, notFoundResult.StatusCode);
    }
    /*
    [Test]
    public void AddProduct_ValidProduct_ReturnsCreatedAtAction()
    {
        // Arrange
        var validProduct = new Product { ProductName = "New Product" };
        int newProductId = 10;
        _mockProductService.Setup(service => service.Add(validProduct)).Returns(newProductId);
        _mockProductService.Setup(service => service.GetById(newProductId)).Returns(validProduct);

        // Act
        IActionResult result = _productsController.Add(validProduct);

        // Assert
        Assert.IsInstanceOf<CreatedAtActionResult>(result);
        var createdResult = result as CreatedAtActionResult;
        Assert.AreEqual(201, createdResult.StatusCode);
        Assert.AreEqual(nameof(ProductsController.Ge), createdResult.ActionName);
        Assert.AreEqual(new { id = newProductId }, createdResult.RouteValues);
        Assert.AreEqual(validProduct, createdResult.Value);
    }
    */

    [Test]
    public void AddProduct_InvalidProduct_ReturnsBadRequest()
    {
        // Arrange
        var invalidProduct = new Product(); // Name is required, so it's invalid
        _productsController.ModelState.AddModelError("Name", "The Name field is required.");

        // Act
        IActionResult result = _productsController.Add(invalidProduct);

        // Assert
        Assert.IsInstanceOf<BadRequestResult>(result);
        var badRequestResult = result as BadRequestResult;
        Assert.AreEqual(400, badRequestResult.StatusCode);
    }
}
