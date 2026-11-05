namespace Core.Tests.Domain;

using Core.Domain;

public class MediaTest
{
    private Guid id = Guid.CreateVersion7();
    private string path = "path";
    private Guid invalidId = Guid.Empty;
    private string invalidPath = "";

    [Fact]
    public void CreateMediaWorks()
    {
        Media media = new Media(id, path);

        Assert.Equal(id, media.Id);
        Assert.Equal(path, media.Path);
    }

    [Fact]
    public void MediaValidationWorks()
    {
        Assert.Throws<ValidationException>(() => { new Media(invalidId, path); });
        Assert.Throws<ValidationException>(() => { new Media(id, invalidPath); });
    }
}