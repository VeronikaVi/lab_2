using Xunit;
using lab2;

namespace lab2Tests
{
    public class MusicCatalogTests
    {
        [Fact]
        public void AddComposition_ShouldAddToCatalog()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicComposition composition = new MusicComposition("Artist1", "Title1");

            // Act
            catalog.AddComposition(composition);

            // Assert
            Assert.Contains(composition, catalog.GetCatalog());
        }

        [Fact]
        public void DeleteComposition_ShouldRemoveFromCatalog()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicComposition composition = new MusicComposition("Artist1", "Title1");
            catalog.AddComposition(composition);

            // Act
            catalog.DeleteComposition("Artist1", "Title1");

            // Assert
            Assert.DoesNotContain(composition, catalog.GetCatalog());
        }

        [Fact]
        public void SearchComposition_ShouldReturnMatchingResults()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicComposition composition1 = new MusicComposition("Artist1", "Title1");
            MusicComposition composition2 = new MusicComposition("Artist2", "Title2");
            catalog.AddComposition(composition1);
            catalog.AddComposition(composition2);

            // Act
            var results = catalog.SearchComposition("Artist");

            // Assert
            Assert.Contains(composition1, results);
            Assert.Contains(composition2, results);
        }

        [Fact]
        public void ListAllCompositions_ShouldReturnAllCompositions()
        {
            // Arrange
            MusicCatalog catalog = new MusicCatalog();
            MusicComposition composition1 = new MusicComposition("Artist1", "Title1");
            MusicComposition composition2 = new MusicComposition("Artist2", "Title2");
            catalog.AddComposition(composition1);
            catalog.AddComposition(composition2);

            // Act
            var allCompositions = catalog.ListAllCompositions();

            // Assert
            Assert.Contains(composition1, allCompositions);
            Assert.Contains(composition2, allCompositions);
        }
    }
}
