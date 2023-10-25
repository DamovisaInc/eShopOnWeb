using Microsoft.eShopWeb.ApplicationCore.Entities;
using Xunit;

namespace ApplicationCore.Tests;

public class CatalogTypeTest
{
    [Fact]
    public void CatalogType_CanBeCreated()
    {
        // Arrange
        var catalogType = new CatalogType("Test");

        // Act & Assert
        Assert.NotNull(catalogType);
    }
}